using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string playerName;
    public string highScoreName;
    public int highScore;

    private string path;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            path = Application.persistentDataPath + "save.json";
            DontDestroyOnLoad(gameObject);
            LoadGameData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetHighScore(int score)
    {
        if(score > highScore)
        {
            highScoreName = playerName;
            highScore = score;
            SaveGameData();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveGameData()
    {
        var data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void LoadGameData()
    {
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScoreName = data.playerName;
            highScore = data.highScore;
        }
    }
}
