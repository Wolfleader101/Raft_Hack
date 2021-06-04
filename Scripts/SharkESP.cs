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

		private AI_StateMachine_Shark m_Shark;

		private IEnumerator coroutine;

		void Start()
		{
			Debug.Log("Shark ESP Initialized");

			coroutine = FindShark();
			StartCoroutine(coroutine);
		}

		void Update()
		{
			if(m_Shark != null)
			{
				m_Shark.targetToAttack = null;
			}
		}

		void OnGUI()
		{
			var mainCam = Camera.main;

			if (!m_Shark) return;

			var pos = m_Shark.transform.position;
			var worldToScreen = mainCam.WorldToScreenPoint(pos);
			if (worldToScreen.z < 0) return;

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
			Debug.LogWarning("Shark Object Found");

		}
	}
}
