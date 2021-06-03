using Raft_Hack.Utils;
using UnityEngine;

namespace Raft_Hack.Scripts
{
	class Main : MonoBehaviour
	{
		private Player m_Player;
		private PlayerStats m_PlayerStats;
		private Stat_Health m_PlayerHealth;
		public static ConsoleWriter _console;

		public void Start()
		{
			_console = new ConsoleWriter();


			_console.Log("Cheat Initialized", LOG_TYPE.WARNING);
			m_Player = FindObjectOfType<Player>();

			m_PlayerStats = m_Player?.GetComponent<PlayerStats>();
			m_PlayerHealth = m_PlayerStats?.stat_health;

			_console.Log($"Player HP: {m_PlayerStats?.stat_health.Value} \nMax HP: {m_PlayerStats?.stat_health.Max}", LOG_TYPE.INFO);
		}
		public void Update()
		{

			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				IncreaseHealth();
			}

			if (Input.GetKeyDown(KeyCode.Delete))
			{
				Loader.Unload();
			}
		}

		public void OnGUI()
		{
			Drawer.DrawText("Raft Trainer", new Vector2(Screen.width / 2, 10), false, 20, FontStyle.Bold, Color.cyan);

			MenuMaker.MakeBox("Raft Trainer", new Vector2(10, 10), new Vector2(100,100));
			MenuMaker.MakeButton("Increase HP", new Vector2(20, 40), new Vector2(80, 20), IncreaseHealth)
;		}

		public void OnDestroy()
		{
			_console.Destroy();
		}

		private void IncreaseHealth()
		{
			m_PlayerStats.stat_health.Value += 15f;
			_console.Log($"New Player HP: {m_PlayerStats?.stat_health.Value}", LOG_TYPE.INFO);
		}
	}
}