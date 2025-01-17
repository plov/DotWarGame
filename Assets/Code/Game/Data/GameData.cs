using System.Collections.Generic;
using System.Linq;

namespace Code.Game.Data
{
    public class GameData
    {
        public int CurrentLevel;
        public bool IsPaused;
        public List<LevelData>  LevelsData;
        
        public LevelData GetLevelDataById(int levelId)
        {
            return LevelsData.FirstOrDefault(level => level.LevelId == levelId);
        }
        
        public LevelData GetCurrentLevelData()
        {
            return LevelsData.FirstOrDefault(level => level.LevelId == CurrentLevel);
        }
        
        // public WayData GetWayByDots(DotData firstDot, DotData secondDot)
        // {
        //     return LevelsData.SelectMany(level => level.Ways)
        //         .FirstOrDefault(way => 
        //             (way.FirstDotData == firstDot && way.SecondDotData == secondDot) ||
        //             (way.FirstDotData == secondDot && way.SecondDotData == firstDot));
        // }
    }
}