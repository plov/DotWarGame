using System;

namespace Code.Game.Data
{
    [Serializable]
    public class WayData
    {
        public int WayId;
        public DotData FirstDotData;
        public DotData SecondDotData;
    }
}