using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BestScoreSaver : MonoBehaviour
{
    public static BestScoreSaver Instance;

    public float BestScore;
    public string name;
    public string bestName;
    private void Awake()
    {
       // DeleteData();
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
  /*  public void DeleteData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        File.Delete(path);
    } */
    public void GetName(string s)
    {
        name = s;
    }
    [System.Serializable]
    class SaveData
    {
        public float bestScore;
        public string Name;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = BestScore;
        data.Name = bestName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.bestScore;
            bestName = data.Name;
        }
    }
}
