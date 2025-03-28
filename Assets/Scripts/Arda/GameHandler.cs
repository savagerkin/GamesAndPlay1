/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{



    public GameObject player;
    public Level_Manager level_manager;

    void Start()
    {
        level_manager = FindObjectOfType<Level_Manager>();
    }

    private void Awake()
    {

        SaveSystem.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ResetSave();
        }
    }

    private void Save()
    {
        // Save
        GameObject lastCheckpoint = level_manager.currentCheckpoint;
        int scoreT = Score_Manager.score;

        SaveObject saveObject = new SaveObject
        {

            lastCheckpoint = lastCheckpoint
        };
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);

        Debug.Log("Saved!");
    }

    private void Load()
    {
        // Load
        string saveString = SaveSystem.Load();
        if (saveString != null)
        {
            Debug.Log("Loaded: " + saveString);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            player.transform.position = saveObject.lastCheckpoint.transform.position;
            //  unit.SetPosition(saveObject.playerPosition);
        }
        else
        {
            Debug.Log("No save");
        }
    }
    private void ResetSave()
    {
        System.IO.DirectoryInfo di = new DirectoryInfo( Application.dataPath + "/Saves/");

        foreach (FileInfo file in di.GetFiles())
        {
            file.Delete();
        }
        foreach (DirectoryInfo dir in di.GetDirectories())
        {
            dir.Delete(true);
        }
    }


    private class SaveObject
    {
        public GameObject lastCheckpoint;
    }
}