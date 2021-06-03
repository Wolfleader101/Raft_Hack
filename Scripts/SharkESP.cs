using Raft_Hack.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Raft_Hack.Scripts
{
	class SharkESP : MonoBehaviour
	{

		public static ConsoleWriter _console;

		private Shark m_Shark;

		void Start()
		{
			_console = Main._console;

			_console.Log("Shark ESP Initialized", LOG_TYPE.INFO);
		}

		void Update()
		{

		}

		void OnGUI()
		{
			var mainCam = Camera.main;

			foreach()
		}
	}
}
