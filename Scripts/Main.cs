﻿using Raft_Hack.Utils;
using UnityEngine;
using System.Collections;
using HarmonyLib;

namespace Raft_Hack.Scripts
{
	class Main : MonoBehaviour
	{
		private Player m_Player;
		private PlayerStats m_PlayerStats;
		private Stat_Health m_PlayerHealth;
		private AI_StateMachine_Shark _Shark;

		public Camera mainCam;
		
		void Start()
		{

			Debug.LogError("Main Initialized");

			this.gameObject.AddComponent<SharkHack>();


			mainCam = Camera.main;
		}

		void Update()
		{
			mainCam = (Camera)ObjectFinder.CacheObject<Camera>(Time.time, 5f);
			m_Player = (Player)ObjectFinder.CacheObject<Player>(Time.time, 5f);
			if(m_Player != null)
			{
				Debug.LogWarning("Player Object Found");
				GetPlayerStats();
				PrintPlayerStats();
			}

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

	[HarmonyPatch(typeof(AI_StateMachine_Shark))]
	class State_Machine_SharkPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch("FindAndSetTargetToAttack")]
		static bool Prefix1()
		{
			return false;
		}
	}

	[HarmonyPatch(typeof(AI_State_Attack_Entity_Shark))]
	class State_Attack_Entity_SharkPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch("TriggerAttackAnimation")]
		static bool Prefix1()
		{
			return false;
		}

		[HarmonyPrefix]
		[HarmonyPatch("AttemptAttack")]
		static bool Prefix2()
		{
			return false;
		}
	}

	[HarmonyPatch(typeof(AI_State_Attack_Block_Shark))]
	class State_Attack_Block_SharkPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch("FindBlockToAttack")]
		static bool Prefix()
		{
			return false;
		}
	}
}