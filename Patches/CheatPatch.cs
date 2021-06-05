using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raft_Hack.Patches
{
	[HarmonyPatch(typeof(Cheat))]
	class CheatPatch
	{

		// # - for terminal commands
		// / - for chat commands
		[HarmonyPostfix]
		[HarmonyPatch("AllowCheatsForLocalPlayer")]
		static void Prefix1(ref bool __result)
		{
			__result = true;
		}

		[HarmonyPostfix]
		[HarmonyPatch("AllowCheatsForUser")]
		static void Prefix2(ref bool __result)
		{
			__result = true;
		}

		[HarmonyPostfix]
		[HarmonyPatch("IsUserDev")]
		static void Prefix3(ref bool __result)
		{
			__result = true;
		}
	}

	[HarmonyPatch(typeof(RemoteConfigManager))]
	class RemoteConfigPatch
	{
		[HarmonyPostfix]
		[HarmonyPatch("ExternalLocalUserIsDevCheck")]
		static void Prefix1(ref bool __result)
		{
			__result = true;
		}

		[HarmonyPostfix]
		[HarmonyPatch("CheckIfUserIsDev")]
		static void Prefix2(ref bool __result)
		{
			__result = true;
		}
	}
}
