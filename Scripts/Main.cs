using Raft_Hack.Utils;
using UnityEngine;

namespace Raft_Hack.Scripts
{
	class Main : MonoBehaviour
	{
		//private bool m_Initialized = false;
		private Player m_Player;
		private PlayerStats m_PlayerStats;
		private Stat_Health m_PlayerHealth;
		public static ConsoleWriter _console = new ConsoleWriter();

		public void Start()
		{
			_console.Log("Cheat Initialized", LOG_TYPE.WARNING);
			m_Player = FindObjectOfType<Player>();
			if(m_Player == null)
			{
				//m_Initialized = false;
			}

			m_PlayerStats = m_Player?.GetComponent<PlayerStats>();
			m_PlayerHealth = m_PlayerStats?.stat_health;

			_console.Log($"Player HP: {m_PlayerStats?.stat_health.Value} \n Max HP: {m_PlayerStats?.stat_health.Max}", LOG_TYPE.INFO);
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
				m_PlayerStats.stat_health.Value += 15f;
				_console.Log($"New Player HP: {m_PlayerStats?.stat_health.Value}", LOG_TYPE.INFO);
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
			GUI.Label(new Rect(25, 10, 150f, 50f), "GAME INJECTED", style);
		}

		public void OnDestroy()
		{
			_console.Destroy();
		}
	}
}