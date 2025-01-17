using System.Collections.Generic;
using Code.SmartDebug;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace Code.LevelEditor
{
    public class SaveLevelsToFile: MonoBehaviour
    {
        public GameObject saveButton;
        private Button _saveBtn;
        
        [SerializeField] private GameObject[] levels; 

        public void Start()
        {
            _saveBtn = saveButton.GetComponent<Button>();
            _saveBtn.onClick.AddListener(CloseBtnClick);
        }

        protected void CloseBtnClick()
        { 
            DLogger.Message(DSenders.EDITOR).WithText("Settings CloseBtn clicked").Log();
            SaveDataToJson();
        }

        private void SaveDataToJson()
        {
            var allLevelsData = new EditorLevels();
            
            foreach (GameObject level in levels)
            {
                if (level != null)
                {
                    EditorLevel levelData = SaveGameObject(level);
                    allLevelsData.levels.Add(levelData);
                }
            }
            
            string filePath = Application.dataPath + MainConfig.LevelDataPath;
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            string json = JsonUtility.ToJson(allLevelsData, true);
            File.WriteAllText(filePath, json);
            Debug.Log($"Data: {json}");
            Debug.Log($"Level data saved to {filePath}");
        }
        
        private EditorLevel SaveGameObject(GameObject obj)
        {
            var level = new EditorLevel();
            level.name = obj.name;
            foreach (Transform child in obj.transform)
            {
                var data = new EditorObject
                {
                    name = child.name,
                    position = child.transform.position,
                    rotation = child.transform.rotation,
                    scale = child.transform.localScale
                };
                level.objects.Add(data);
            }

            return level;
        }
    }
}