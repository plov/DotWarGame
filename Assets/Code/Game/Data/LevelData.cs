using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Game.Data
{
    [Serializable]
    public class LevelData
    {
        public int LevelId { get; set; }
        public List<DotData> Dots { get; set; }
        public List<WayData> Ways { get; set; }
        
        public WayData GetWayByDots(DotData firstDot, DotData secondDot)
        {
            return Ways.FirstOrDefault(way => 
                (way.FirstDotData == firstDot && way.SecondDotData == secondDot));
        }
    }
}