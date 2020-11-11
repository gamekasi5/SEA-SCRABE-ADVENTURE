using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine.UI;

public class GameCtrl2 : MonoBehaviour
{
    public GameData data;
    string DataFilePath;
    BinaryFormatter bf;

    public Text txtCionCount;
    public void UpdateCoinCount()
    {
        data.Coin += 1;
        txtCionCount.text = data.Coin.ToString();
    }

    void Awake()
    {
        bf = new BinaryFormatter();
        DataFilePath = Application.persistentDataPath + "/game.dat";
        Debug.Log(DataFilePath);
    }

    public void SaveData()
    {
        FileStream fs = new FileStream(DataFilePath, FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close();
    }

    public void LoadData()
    {
        if (File.Exists(DataFilePath))
        {
            FileStream fs = new FileStream(DataFilePath, FileMode.Open);
            data = (GameData)bf.Deserialize(fs);
            fs.Close();
            Debug.Log("Number of coin =" + data.Coin);
            txtCionCount.text = data.Coin.ToString();
        }

    }

    private void OnEnable()
    {
        Debug.Log("Data Loaded");
        LoadData();
    }

    private void OnDisable()
    {
        Debug.Log("Data Saved");
        SaveData();
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.E))
        {
            UpdateCoinCount();
        }
    }

}
