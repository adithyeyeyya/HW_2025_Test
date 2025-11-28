using UnityEngine;
using System.IO;

public class ConfigLoader : MonoBehaviour {
    public static ConfigLoader Instance;
    public GameConfig config;

    void Awake() {
        if (Instance == null) Instance = this;
        LoadConfig();
    }

    void LoadConfig() {
        string path = Path.Combine(Application.streamingAssetsPath, "doofus_diary.json");
        Debug.Log("LOOKING FOR JSON HERE: " + path);
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            config = JsonUtility.FromJson<GameConfig>(json);
            
            if(config != null) {
                Debug.Log("SUCCESS: JSON loaded and parsed!");
            } else {
                Debug.LogError("ERROR: File found, but the JSON format is invalid.");
            }
        } else {
            Debug.LogError("ERROR: File NOT found.");
        }
    }
}
