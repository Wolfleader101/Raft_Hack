using Raft_Hack.Utils;
using UnityEngine;
using System.Collections;

namespace Raft_Hack.Scripts
{
	class Main : MonoBehaviour
	{
		private Player m_Player;
		private PlayerStats m_PlayerStats;
		private Stat_Health m_PlayerHealth;
		private AI_StateMachine_Shark _Shark;



		private IEnumerator coroutine;

		void Start()
		{

			Debug.Log("<color=green>Main Initialized</color");

			this.gameObject.AddComponent<SharkESP>();
			

			coroutine = FindPlayer();
			StartCoroutine(coroutine);
		}
		void Update()
		{
			if(Input.GetKeyDown(KeyCode.UpArrow) && m_Player != null)
			{
				IncreaseHealth();
			}

			if(Input.GetKeyDown(KeyCode.K) && m_Player != null)
			{
				KillShark();
			}

			if (Input.GetKeyDown(KeyCode.Delete))
			{
				//Loader.Unload();
			}
		}

		void OnGUI()
		{
			Drawer.DrawText("Raft Trainer", new Vector2(Screen.width / 2, 10), false, 20, FontStyle.Bold, Color.cyan);

			MenuMaker.MakeBox("Raft Trainer", new Vector2(10, 10), new Vector2(100,100));
			MenuMaker.MakeButton("Increase HP", new Vector2(20, 40), new Vector2(80, 20), IncreaseHealth)
;		}

		// eventually rewrite this as a module that can be implemented anywhere
		private IEnumerator FindPlayer()
		{
			while (m_Player == null)
			{
				m_Player = FindObjectOfType<Player>();
				yield return new WaitForSeconds(2f);
				m_Player = FindObjectOfType<Player>();
			}
			StopCoroutine(coroutine);
			Debug.LogWarning("Player Object Found");
			GetPlayerStats();
			PrintPlayerStats();

		}

		private void GetPlayerStats() 
		{
			m_PlayerStats = m_Player?.GetComponent<PlayerStats>();
			m_PlayerHealth = m_PlayerStats?.stat_health;
		}
		private void PrintPlayerStats() 
		{
			Debug.Log($"Player HP: {m_PlayerStats?.stat_health.Value} \nMax HP: {m_PlayerStats?.stat_health.Max}");
		}

		private void IncreaseHealth()
		{
			m_PlayerStats.stat_health.Value += 15f;
			Debug.Log($"New Player HP: {m_PlayerStats?.stat_health.Value}");
		}

		private void KillShark()
		{
			_Shark = FindObjectOfType<AI_StateMachine_Shark>();
			if (_Shark != null)
			{
				Destroy(_Shark);
				Debug.LogError("SHARK HAS BEEN DESTROYED");
			}
		}
	}
}