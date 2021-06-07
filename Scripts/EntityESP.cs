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
	class EntityESP : MonoBehaviour
	{
		private List<AI_StateMachine_Animal> m_Animals;
		private IEnumerator findEntitiesCoroutine;

		private bool _showESP = true;

		void Start()
		{
			findEntitiesCoroutine = FindEntities();
			StartCoroutine(findEntitiesCoroutine);
		}

		void OnGUI()
		{
			if(this.gameObject.GetComponent<Main>().showMenu) MenuMaker.MakeToggle("Entity ESP", new Vector2(100, 20), new Vector2(20, 100), _showESP, out _showESP);
			if(_showESP) ESP();
		}

		private void ESP()
		{
			var mainCam = Camera.main;//this.GetComponent<Main>().mainCam;

			if (m_Animals == null) return;
			foreach (var animal in m_Animals)
			{
				var pos = animal.transform.position;
				var worldToScreen = mainCam.WorldToScreenPoint(pos);

				if (worldToScreen.z < 0 || worldToScreen.z > 150) return;

				Drawer.DrawText($"{animal.name} {worldToScreen.z.ToString("0.")}m", new Vector2(worldToScreen.x, Screen.height - worldToScreen.y + 45), false, 16, Color.green);

				Drawer.DrawBox(new Vector2(worldToScreen.x, Screen.height - worldToScreen.y), 25, 40, Color.red);
			}
		}

		private IEnumerator FindEntities()
		{
			for (; ; )
			{
				m_Animals = FindObjectsOfType<AI_StateMachine_Animal>().ToList();
				yield return new WaitForSeconds(5f);
				m_Animals = FindObjectsOfType<AI_StateMachine_Animal>().ToList();
				if (m_Animals.Count > 0)
				{
					//StopCoroutine(findEntitiesCoroutine);
					foreach (var animal in m_Animals)
					{
						Debug.LogWarning($"{animal.name} Object Found");
					}
				}
			}

		}
	}


}
