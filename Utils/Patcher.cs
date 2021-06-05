using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace Raft_Hack.Utils
{
	class Patcher
	{
		public static void doPatching()
		{
			var harmony = new Harmony("com.raft.hack");
			harmony.PatchAll();
		}
	}
}
