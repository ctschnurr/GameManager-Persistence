using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary; // NEED THIS IN ORDER TO SERIALIZE INTO BINARY
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager control;
    public static int gameManagerCount;

    public float health;
    public float experience;
    public float score;
    public float gold;
    public float potions;
    public float kills;
    // Start is called before the first frame update
    public int saveSceneIndex;
    void Awake()
    {
        if(control == null)
        {
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SceneManager.LoadScene(0); // press 1
        if (Input.GetKeyDown(KeyCode.Alpha2)) SceneManager.LoadScene(1); // press 2
        if (Input.GetKeyDown(KeyCode.Alpha3)) SceneManager.LoadScene(2); // press 3
        if (Input.GetKeyDown(KeyCode.Alpha4)) SceneManager.LoadScene(3); // press 4

        CountGameManagers();
    }

    private void CountGameManagers()
    {
        GameObject[] gameManagers;
        gameManagers = GameObject.FindGameObjectsWithTag("GameManager");

        gameManagerCount = gameManagers.Length;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
        GUI.Label(new Rect(10, 40, 100, 30), "XP: " + experience);
        GUI.Label(new Rect(10, 70, 100, 30), "Score " + score);
        GUI.Label(new Rect(10, 100, 100, 30), "Gold: " + gold);
        GUI.Label(new Rect(10, 130, 100, 30), "Potions: " + potions);
        GUI.Label(new Rect(10, 160, 100, 30), "Kills: " + kills);

        GUI.Label(new Rect(10, 200, 150, 30), "Game Managers: " + gameManagerCount);

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

        PlayerData data = new PlayerData();
        data.health = health;
        data.experience = experience;
        data.score = score;
        data.gold = gold;
        data.potions = potions;
        data.kills = kills;
        data.saveSceneIndex = SceneManager.GetActiveScene().buildIndex;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            experience = data.experience;
            score = data.score;
            gold = data.gold;
            potions = data.potions;
            kills = data.kills;
            SceneManager.LoadScene(data.saveSceneIndex);
        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float experience;
    public float score;
    public float gold;
    public float potions;
    public float kills;
    public int saveSceneIndex;
}
