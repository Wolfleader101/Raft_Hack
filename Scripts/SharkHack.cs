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
	class SharkHack : MonoBehaviour
	{

		private AI_StateMachine_Shark m_Shark;

		private bool _friendlyShark = true;
		public bool friendlyShark => _friendlyShark;

		private IEnumerator coroutine;


		void Start()
		{
			coroutine = FindShark();
			StartCoroutine(coroutine);
		}

		void Update()
		{
			//m_Shark = (AI_StateMachine_Shark)ObjectFinder.CacheObject<AI_StateMachine_Shark>(Time.time, 5f);

			if (m_Shark != null && friendlyShark)
			{
				m_Shark.targetToAttack = null;
			}
		}

		void OnGUI()
		{
			if (this.gameObject.GetComponent<Main>().showMenu) MenuMaker.MakeToggle("Friendly Shark", new Vector2(100, 20), new Vector2(20, 70), _friendlyShark, out _friendlyShark);
		}

		private IEnumerator FindShark()
		{
			while (m_Shark == null)
			{
				m_Shark = FindObjectOfType<AI_StateMachine_Shark>();
				yield return new WaitForSeconds(5f);
				m_Shark = FindObjectOfType<AI_StateMachine_Shark>();
			}
			StopCoroutine(coroutine);
			Debug.LogWarning("Shark Object Found");

		}
	}
}
