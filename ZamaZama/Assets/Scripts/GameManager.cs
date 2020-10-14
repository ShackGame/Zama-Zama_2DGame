using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float Score;
    public float Health = 5f;

    public string level;
    public string gameplaySoundName;

    public GameObject loadGameBtn;

    //Cache
    private AudioManager audioManager;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        
        loadGameBtn.SetActive(false);
       

        //caching
        audioManager = AudioManager.instance;

        if(audioManager == null)
        {
            Debug.LogError("No audio manager found in the scene");
        }
        
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData_S data = new PlayerData_S();
        data.health = Health;
        data.experienceCoins = Score;
        data.level = SceneManager.GetActiveScene().name;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_S data = (PlayerData_S)bf.Deserialize(file);
            file.Close();

            Health = data.health;
            Score = data.experienceCoins;
            level = data.level;

            StartCoroutine(QuitGame.instance.LoadLevel(level));
        }
        else
        {
            loadGameBtn.SetActive(true);
            StartCoroutine(NoGameSavedMessage());
        }
    }

    IEnumerator NoGameSavedMessage()
    {
        yield return new WaitForSeconds(2);
        loadGameBtn.SetActive(false);
    }
}

[Serializable]
class PlayerData_S
{
    public float health;
    public float experienceCoins;
    public string level;
}






