using Raft_Hack.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Raft_Hack
{
	class Loader
	{
		public enum InjectionMethod
		{
			Injector,
			BepInEx,
		}

		private static GameObject _load;
		public static GameObject Load
		{
			get
			{
				return Loader._load;
			}
			set
			{
				Loader._load = value;
			}
		}

		public static Loader.InjectionMethod injectionMethod;

		public static bool initialized;

		public static void Init()
		{
			Application.runInBackground = true;
			Loader._load = new GameObject("Raft_Hack");
			Loader.Load.transform.parent = null;
			Transform root = Loader.Load.transform.root;
			if (root != null && root.gameObject != Loader.Load)
			{
				root.parent = Loader.Load.transform;
			}
			Loader._load.AddComponent<Main>();
			UnityEngine.Object.DontDestroyOnLoad(Loader._load);
			Loader.initialized = true;
		}

		//public static void Unload()
		//{
		//	_Unload();
		//}

		//private static void _Unload()
		//{
		//	UnityEngine.Object.Destroy(_load.GetComponent<Main>());
		//	GameObject.Destroy(_load);
		//}

	}
}
