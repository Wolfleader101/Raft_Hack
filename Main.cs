using UnityEngine;

namespace Raft_Hack
{
	class Main : MonoBehaviour
	{
        private Player m_Player;
        public static ConsoleWriter console = new ConsoleWriter();

        public void Start()
        {
            m_Player = FindObjectOfType<Player>();

           PlayerStats stats = m_Player?.GetComponent<PlayerStats>();

            console.WriteLine($"Player HP: {stats?.stat_health}");

        }
        public void Update()
        {
            //if (Input.GetKeyDown(KeyCode.U))
            //{
            //    _player.upgradeHealth();
            //}

            if (Input.GetKeyDown(KeyCode.Delete)) // Will just unload our DLL
            {
                Loader.Unload();
            }
        }
        public void OnGUI()
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 150f, 50f), "Game Injected");
        }
    }
}