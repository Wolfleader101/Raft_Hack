using Raft_Hack.Utils;
using UnityEngine;

namespace Raft_Hack.Scripts
{
	class Main : MonoBehaviour
	{
		private Player m_Player;
		public static ConsoleWriter _console = new ConsoleWriter();

		public void Start()
		{
			m_Player = FindObjectOfType<Player>();

		   PlayerStats stats = m_Player?.GetComponent<PlayerStats>();

			_console.WriteLine($"Player HP: {stats?.stat_health}");
			_console.WriteLine("Game Injected");

		}
		public void Update()
		{
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