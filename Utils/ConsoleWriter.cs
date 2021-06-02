using System.IO;

namespace Raft_Hack.Utils
{
	public enum LOG_TYPE
	{
		INFO,
		WARNING,
		ERROR
	}
	public class ConsoleWriter
	{
		[System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
		static extern bool AllocConsole();

		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		private static extern bool AttachConsole(int dwProcessId);

		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		private static extern bool FreeConsole();

		private const int ATTACH_PARENT_PROCESS = -1;

		StreamWriter _stdOutWriter;

		public ConsoleWriter()
		{
			AllocConsole();
			var stdout = System.Console.OpenStandardOutput();
			_stdOutWriter = new StreamWriter(stdout);
			_stdOutWriter.AutoFlush = true;

			AttachConsole(ATTACH_PARENT_PROCESS);
		}

		public void Destroy()
		{
			_stdOutWriter.Dispose();
			_stdOutWriter.Close();
			FreeConsole();
		}

		public void Log(string message)
		{
			System.Console.ForegroundColor = System.ConsoleColor.White;
			_stdOutWriter.WriteLine(message);
			System.Console.WriteLine(message);
		}

		public void Log(string message, LOG_TYPE MESSAGE_TYPE)
		{
			switch(MESSAGE_TYPE)
			{
				case LOG_TYPE.INFO:
					System.Console.ForegroundColor = System.ConsoleColor.Green;
					break;
				case LOG_TYPE.WARNING:
					System.Console.ForegroundColor = System.ConsoleColor.Yellow;
					break;
				case LOG_TYPE.ERROR:
					System.Console.ForegroundColor = System.ConsoleColor.Red;
					break;
			}

			_stdOutWriter.WriteLine(message);
			System.Console.WriteLine(message);
		}
		
		// log what called this method, line number, time in format
		// [TIME] FILE:LINE METHOD
		public void DebugLog(string message)
		{
		}

		public void DebugLog(string message, LOG_TYPE MESSAGE_TYPE)
		{ }
		
	}
}
