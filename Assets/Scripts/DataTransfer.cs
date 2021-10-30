using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataTransfer : MonoBehaviour
{
    public static DataTransfer Instance;
    public string username;
    public int hscore;
    public string highscore;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
// end of new code

    Instance = this;
    DontDestroyOnLoad(gameObject);
        Debug.Log(username);
        LoadRecord();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public class SaveData
    {
        public string username;
        public int hscore;
        public string highscore;
    }
    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.hscore = hscore;
        data.username = username;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hscore = data.hscore;
            username = data.username;
            highscore = data.highscore;
        }

    }
}
