using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Raft_Hack.Utils
{
	class ObjectFinder
	{
		private static float timeCache;

		public static Object CacheObject<T>(float curTime, float waitTime) where T : Object
		{
			Object _obj = null;

			if (curTime >= timeCache)
			{
				timeCache = curTime + waitTime;
				_obj = Object.FindObjectOfType<T>();
			}

			return _obj;
		}

		public static List<T> CacheObjects<T>(float curTime, float waitTime) where T : Object
		{
			List<T> _obj = null;

			if (curTime >= timeCache)
			{
				timeCache = curTime + waitTime;
				_obj = Object.FindObjectsOfType<T>().ToList();
			}

			return _obj;
		}
	}
}
