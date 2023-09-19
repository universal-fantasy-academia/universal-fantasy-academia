using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Life = 3, Xp = 0;

    public Player player;

    public void SaveGame()
    {  
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


    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
