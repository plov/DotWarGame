using System.Collections.Generic;
using UnityEngine;

namespace Code.LevelEditor
{
    [System.Serializable]
    public class EditorObject
    {
        public string name;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        
        public List<EditorObject> children = new List<EditorObject>();
        
    }
}