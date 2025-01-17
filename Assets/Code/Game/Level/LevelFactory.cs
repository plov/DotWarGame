using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Code.Game.Data;
using UnityEngine;

namespace Code.Game.Level
{
    public class LevelFactory
    {
        public List<LevelData> BuildLevelData()
        {
            string jsonPath = Application.dataPath + "/SavedLevels/LevelsData.json";
            string json = System.IO.File.ReadAllText(jsonPath);
            var container = JsonUtility.FromJson<LevelsDataCollection>(json);
            
            foreach (var level in container.levels)
            {
                foreach (var obj in level.objects)
                {
                    obj.position = new Vector3(obj.position.x, obj.position.y, obj.position.z);
                    obj.rotation = new Quaternion(obj.rotation.x, obj.rotation.y, obj.rotation.z, obj.rotation.w);
                    obj.scale = new Vector3(obj.scale.x, obj.scale.y, obj.scale.z);
                }
            }
            
            return ConvertToLevelDataList(container);
        }

        private List<LevelData>  ConvertToLevelDataList(LevelsDataCollection rawData)
        {
            var data = new List<LevelData>();
            foreach (var level in rawData.levels)
            {
                var levelData = new LevelData();
                levelData.LevelId = int.Parse(level.name.Last().ToString());
                levelData.Dots = new List<DotData>();
                levelData.Ways = new List<WayData>();
                foreach (var gameObject in level.objects)
                {
                    if (gameObject.name.Contains("Dot"))
                    {
                        var dot = new DotData();
                        dot.Id = Guid.NewGuid().ToString();
                        dot.position = gameObject.position;
                        dot.rotation = gameObject.rotation;
                        dot.scale = gameObject.scale;
                        dot.Owner = 0;
                        dot.CurrentSize = 0;
                        dot.MaxSize = 30;
                        dot.IsAutoIncrement = false;
                        levelData.Dots.Add(dot);
                    }
                }
                data.Add(levelData);
            }
            return data;
        }
    }
}