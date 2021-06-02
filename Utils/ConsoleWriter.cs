using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Raft_Hack.Utils
{
	public enum LOG_TYPE
	{
		DEFAULT,
		INFO,
		WARNING,
		ERROR
	}
	public class ConsoleWriter
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: System.Runtime.InteropServices.MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();

		[DllImport("kernel32.dll")]
		private static extern bool AttachConsole(int dwProcessId);

		[DllImport("kernel32.dll")]
		private static extern bool FreeConsole();

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetStdHandle(int nStdHandle);

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetStdHandle(int nStdHandle, IntPtr hHandle);

		private const int ATTACH_PARENT_PROCESS = -1;
		private const int STD_OUTPUT_HANDLE = -11;

		StreamWriter _stdOutWriter;
		IntPtr _HANDLE;

		public ConsoleWriter()
		{

			AllocConsole();
			var stdout = Console.OpenStandardOutput();
			_stdOutWriter = new StreamWriter(stdout);
			_stdOutWriter.AutoFlush = true;

			AttachConsole(ATTACH_PARENT_PROCESS);

			_HANDLE = GetStdHandle(STD_OUTPUT_HANDLE);

			Log($"HANDLE: {_HANDLE.ToInt32()}", LOG_TYPE.INFO);
		}

		public void Destroy()
		{
			_stdOutWriter.Dispose();
			_stdOutWriter.Close();
			FreeConsole();

			SetStdHandle(STD_OUTPUT_HANDLE, _HANDLE);
		}

		public void Log(string message, LOG_TYPE MESSAGE_TYPE = LOG_TYPE.DEFAULT)
		{
			switch(MESSAGE_TYPE)
			{
				case LOG_TYPE.INFO:
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case LOG_TYPE.WARNING:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case LOG_TYPE.ERROR:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				default:
					Console.ForegroundColor = ConsoleColor.White;
					break;
			}
			LogMessage(message);
		}

		private void LogMessage(string message)
		{
			_stdOutWriter.WriteLine(message);
			Console.WriteLine(message);
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
