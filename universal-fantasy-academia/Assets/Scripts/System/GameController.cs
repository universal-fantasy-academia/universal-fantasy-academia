using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Life = 3, Xp = 0;

    public List<string> destroyedObjectsIds = new List<string>();

    public Player player;

    void Awake()
    {
        LoadGame();
    }


    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.F5))
        // {
        //     SaveGame();
        // }
        // if (Input.GetKeyDown(KeyCode.F9))
        // {
        //     LoadGame();
        // }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Debug.Log("Clearing deleted objects");
            destroyedObjectsIds = new List<string>();
            SaveGame(true);
        }
    }

    public void SaveGame(bool allButPlayer = false)
    {
        SaveSystem.SaveScene();
        if (allButPlayer)
        {
            return;
        }

        if (player != null)
        {
            SaveSystem.SavePlayer(player);
        }
        else
        {
            Debug.LogError("Player not found");
            throw new System.Exception("Player not found");
        }
    }

    public void LoadGame()
    {   
        SceneData sceneData = SaveSystem.LoadScene();
        if (sceneData != null)
        {
            destroyedObjectsIds = sceneData.destroyedObjectsIds;
        }
        else
        {
            Debug.LogError("SceneData not found");
        }
    }


    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
