﻿using HarmonyLib;
using Raft_Hack.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Raft_Hack.Patches
{
	[HarmonyPatch(typeof(AI_State_Attack_Block_Shark))]
	class SharkAttackBlockPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch("FindBlockToAttack")]
		static bool Prefix()
		{
			if(Loader.Load.GetComponent<SharkHack>().friendlyShark)	return false;
			return true;
		}
	}
}

