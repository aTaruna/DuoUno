using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public Color WarnaBal;
    public GameObject ball;
    public Renderer ballRend;

    private void Awake()
    {
        if (instance != null )
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ballRend=ball.GetComponent<Renderer>();
    }
    public void ChangeMaterial()
    {
        ballRend.material.color= WarnaBal;
    }
    public void SaveColor()
    {
        SaveData data=new SaveData();
        data.WarnaBal = WarnaBal;
        string json=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data=JsonUtility.FromJson<SaveData>(json);
            WarnaBal= data.WarnaBal;
        }
    }

    [Serializable]
    public class SaveData
    {
        public Color WarnaBal;
    }
}
