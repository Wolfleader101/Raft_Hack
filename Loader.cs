using UnityEngine;
using Raft_Hack.Scripts;
using System;
using System.Reflection;

namespace Raft_Hack
{
    public class Loader
    {
        private static GameObject _gameObject;

        public static void Init()
        {
            _gameObject = new GameObject();
            _gameObject.AddComponent<Main>();
			UnityEngine.Object.DontDestroyOnLoad(_gameObject);
        }

        public static void Unload()
        {
            _Unload();
        }
        private static void _Unload()
        {
            UnityEngine.Object.Destroy(_gameObject.GetComponent<Main>());
            GameObject.Destroy(_gameObject);
        }
    }
}
