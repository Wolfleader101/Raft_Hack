using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Raft_Hack.Utils
{
	class Drawer
	{
		public static GUIStyle TextStyle { get; set; } = new GUIStyle(GUI.skin.label);

		private const int _defaultFontSize = 14;
		private const FontStyle _defaultFontStyle = FontStyle.Normal;

		public static void DrawText(string name, Vector2 position)
		{
			_DrawText(name, position, false, _defaultFontSize, _defaultFontStyle, null);
		}

		public static void DrawText(string name, Vector2 position, bool centered)
		{
			_DrawText(name, position, centered, _defaultFontSize, _defaultFontStyle, null);
		}


		public static void DrawText(string name, Vector2 position, bool centered, int fontSize = _defaultFontSize)
		{
			_DrawText(name, position, centered, fontSize, _defaultFontStyle, null);
		}


		public static void DrawText(string name, Vector2 position, bool centered, int fontSize = _defaultFontSize, Color? color = null)
		{
			_DrawText(name, position, centered, fontSize, _defaultFontStyle, color);
		}


		public static void DrawText(string name, Vector2 position, bool centered, int fontSize = _defaultFontSize, FontStyle fontStyle = _defaultFontStyle)
		{
			_DrawText(name, position, centered, fontSize, fontStyle, null);
		}

		public static void DrawText(string name, Vector2 position, bool centered, int fontSize = _defaultFontSize, FontStyle fontStyle = _defaultFontStyle, Color? color = null)
		{
			_DrawText(name, position, centered, fontSize, fontStyle, color);
		}


		private static void _DrawText(string name, Vector2 position, bool centered, int fontSize, FontStyle fontStyle, Color? color)
		{
			TextStyle.normal.textColor = color.GetValueOrDefault(Color.black);
			TextStyle.fontSize = fontSize;
			TextStyle.fontStyle = fontStyle;


			var label = new GUIContent(name);
			var size = TextStyle.CalcSize(label);
			var _pos = centered ? position - size / 2f : position;

			GUI.Label(new Rect(_pos, size), "Raft Hack", TextStyle);
		}

		public static void DrawBox() { }

		public static void DrawLine() { }
	}
}
