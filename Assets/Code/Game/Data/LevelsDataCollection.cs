using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Game.Data
{
    [Serializable]
    public class LevelsDataCollection
    {
        public List<RawLevelData> levels;
    }

    [Serializable]
    public class RawLevelData
    {
        public string name; // Matches "name" in JSON
        public List<GameObjectData> objects; // Matches "objects" in JSON
    }

// Represents each object inside the "objects" array
    [Serializable]
    public class GameObjectData
    {
        public string name; // Matches "name" in JSON
        public Vector3 position; // Matches "position" in JSON
        public Quaternion rotation; // Matches "rotation" in JSON
        public Vector3 scale; // Matches "scale" in JSON
        public List<GameObjectData> children; // Matches "children" in JSON
    }

// Wrapper class for Vector3
    [Serializable]
    public class SerializableVector3
    {
        public float x, y, z;
        public SerializableVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

// Wrapper class for Quaternion
    [Serializable]
    public class SerializableQuaternion
    {
        public float x, y, z, w;
        
        public SerializableQuaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }
}