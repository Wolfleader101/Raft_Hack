using Raft_Hack.Utils;
using System;
using System.Collections;
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

		private AI_StateMachine_Shark m_Shark;

		private IEnumerator coroutine;

		void Start()
		{
			_console = this.gameObject.GetComponent<Main>()._console;

			_console.Log("Shark ESP Initialized", LOG_TYPE.INFO);

			coroutine = FindShark();
			StartCoroutine(coroutine);
		}

		void Update()
		{

		}

		void OnGUI()
		{
			var mainCam = Camera.main;

			if (!m_Shark) return;

			var pos = m_Shark.gameObject.transform.position;
			var worldToScreen = mainCam.WorldToScreenPoint(pos);

			Drawer.DrawText(m_Shark.gameObject.name, new Vector2(worldToScreen.x, Screen.height - worldToScreen.y + 45), false, 16, Color.green);
			Drawer.DrawBox(new Vector2(worldToScreen.x, Screen.height - worldToScreen.y), 25, 40, Color.red);

		}

		private IEnumerator FindShark()
		{
			while (m_Shark == null)
			{
				m_Shark = FindObjectOfType<AI_StateMachine_Shark>();
				yield return new WaitForSeconds(2f);
				m_Shark = FindObjectOfType<AI_StateMachine_Shark>();
			}
			StopCoroutine(coroutine);
			_console.Log("Shark Object Found", LOG_TYPE.WARNING);

		}
	}
}
