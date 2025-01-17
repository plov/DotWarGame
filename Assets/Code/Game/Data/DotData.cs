using System;
using UnityEngine;

namespace Code.Game.Data
{
    [Serializable]
    public class DotData
    {
        public string Id;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public bool IsAutoIncrement;
        public int MaxSize;
        public int CurrentSize;
        public int Owner;
    }
}