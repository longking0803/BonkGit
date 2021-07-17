using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    private PlayerData data;
    private GameObject player;
    //[SerializeField] private Transform player;
    [SerializeField] private string fileName = "save_game.json";

    public void NextLevel()
    {
        Load();
        switch (data.currentLevel)
        {
            case "The Level":
                data.currentLevel = "The Level 2";
                Save();
                break;
            case "The Level 2":
                data.currentLevel = "TheBonkMenu";
                Save();
                break;
            case "null":
                break;
        }
        SceneManager.LoadScene(data.currentLevel);
    }

    private void Start()
    {
        Load();
        player = GameObject.FindWithTag("Player");
        if (player!=null && data.mode=="continue" && data.currentLevel == SceneManager.GetActiveScene().name)
        {
            player.transform.position = data.position;
        }
        Time.timeScale = 1f;
    }
    //private void PlacePlayerAfterLoad()
    //{
    //    Load();
    //    player = GameObject.FindWithTag("Player");
    //    player.transform.position = data.position;
    //}

    public void NewGame()
    {
        Load();
        data.mode = "new_game";
        data.currentLevel = "The Level";
        Save();
        SceneManager.LoadScene("The Level");
    }
    public void ContinueGame()
    {
        if (Load())
        {
            data.mode = "continue";
            Save();
            //SceneManager.LoadScene("The Level");
            SceneManager.LoadScene(data.currentLevel);
            //PlacePlayerAfterLoad();
        }
        else
        {
            data = new PlayerData();
            Save();
            NewGame();
        }
    }
    public void SaveGame()
    {
        Load();
        player = GameObject.FindWithTag("Player");
        data.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        //data = new PlayerData();
        //Debug.Log(data);
        data.currentLevel = SceneManager.GetActiveScene().name;
        data.mode = "continue";
        Save();
        //Debug.Log("ok");
        SceneManager.LoadScene("TheBonkMenu");
    }
    //private void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject);
    //}
    public void Save() {
        string json = JsonUtility.ToJson(data);
        WriteToFile(fileName, json); 
    }
    public bool Load() {        
        data = new PlayerData();
        string json = ReadFromFile(fileName);
        if (json == "") {
            return false;
        }
        JsonUtility.FromJsonOverwrite(json, data);
        return true;
        //Debug.Log(data);
    }
    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream)) {
            writer.Write(json);
        }
    }
    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName); 
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else 
            Debug.LogWarning("File not found!");
        return "";
    }
    private string GetFilePath(string fileName) {
        return Application.dataPath + "/SaveGame/" + fileName; 
    }
}

