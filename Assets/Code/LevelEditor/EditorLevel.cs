using System.Collections.Generic;

namespace Code.LevelEditor
{
    [System.Serializable]
    public class EditorLevel
    {
        public string name;
        public List<EditorObject> objects = new List<EditorObject>();
    }
}