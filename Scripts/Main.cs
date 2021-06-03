﻿using Raft_Hack.Utils;
using UnityEngine;

namespace Raft_Hack.Scripts
{
	class Main : MonoBehaviour
	{
		//private bool m_Initialized = false;
		private Player m_Player;
		private PlayerStats m_PlayerStats;
		private Stat_Health m_PlayerHealth;
		//public static ConsoleWriter _console;

		public void Start()
		{
			//_console = new ConsoleWriter();


			//_console.Log("Cheat Initialized", LOG_TYPE.WARNING);
			m_Player = FindObjectOfType<Player>();
			if(m_Player == null)
			{
				//m_Initialized = false;
			}

			m_PlayerStats = m_Player?.GetComponent<PlayerStats>();
			m_PlayerHealth = m_PlayerStats?.stat_health;

			//_console.Log($"Player HP: {m_PlayerStats?.stat_health.Value} \nMax HP: {m_PlayerStats?.stat_health.Max}", LOG_TYPE.INFO);
		}
		public void Update()
		{
			//while(!m_Initialized)
			//{
			//	m_Player = FindObjectOfType<Player>();
			//	if (m_Player) m_Initialized = true;
			//}

			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				IncreaseHealth();
				//_console.Log($"New Player HP: {m_PlayerStats?.stat_health.Value}", LOG_TYPE.INFO);
			}

			if (Input.GetKeyDown(KeyCode.Delete))
			{
				Loader.Unload();
			}
		}

		public void OnGUI()
		{
			GUIStyle style = new GUIStyle();
			style.fontSize = 20;
			style.normal.textColor = Color.red;
			GUI.Label(new Rect(Screen.width / 2, 10, 150f, 50f), "Raft Hack", style);

			MenuMaker.MakeBox("Raft Trainer", new Vector2(10, 10), new Vector2(100,100));
			MenuMaker.MakeButton("Increase HP", new Vector2(20, 40), new Vector2(80, 20), IncreaseHealth)
;		}

		public void OnDestroy()
		{
			//_console.Destroy();
		}

		private void IncreaseHealth()
		{
			m_PlayerStats.stat_health.Value += 15f;
		}
	}
}