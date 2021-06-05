using System.Collections;
using UnityEngine;

namespace Raft_Hack.Utils
{
	class ObjectFinder : MonoBehaviour
	{
		private Object m_Object;
		private IEnumerator coroutine;
		public float waitTime = 5f;

		public void Initialize(Object obj)
		{
			m_Object = obj;
		}
		public IEnumerator SearchForObjectUntilFound()
		{
			coroutine = this.SearchForObjectUntilFound();
			while (m_Object == null)
			{
				m_Object = FindObjectOfType<AI_StateMachine_Shark>();
				yield return new WaitForSeconds(waitTime);
				m_Object = FindObjectOfType<AI_StateMachine_Shark>();
			}
			StopCoroutine(coroutine);
			Debug.LogWarning("Shark Object Found");
		}

		public IEnumerator CacheObject()
		{
			coroutine = this.CacheObject();
			for (;;)
			{
				m_Object = Object.FindObjectOfType<Player>();

				yield return new WaitForSeconds(waitTime);
			}
		}

	}
}
