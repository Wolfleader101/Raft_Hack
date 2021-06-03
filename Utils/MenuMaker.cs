using UnityEngine;
using System.Collections;
using System;

namespace Raft_Hack.Utils
{
	class MenuMaker
	{
		public static void MakeBox(string name, Vector2 size, Vector2 position)
		{
			GUI.Box(new Rect(size.x,size.y,position.x,position.y), name);
		}

		public static void MakeButton(string name, Vector2 size, Vector2 position, Action callback)
		{
			if (GUI.Button(new Rect(size.x, size.y, position.x, position.y), name))
			{
				callback();
			}
		}
	}
}
