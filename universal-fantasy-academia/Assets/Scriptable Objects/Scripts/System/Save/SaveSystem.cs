using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static string playerPath = Application.persistentDataPath + "/player.ufa";
    public static string scenePath = Application.persistentDataPath + "/scene.ufa";
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = SaveSystem.playerPath;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = SaveSystem.playerPath;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


    public static void SaveScene()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController != null)
        {
            FileStream stream = new FileStream(scenePath, FileMode.Create);

            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            SceneData data = new SceneData(sceneName, gameController.destroyedObjectsIds);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static SceneData LoadScene()
    {
        if (File.Exists(scenePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(scenePath, FileMode.Open);

            SceneData data = formatter.Deserialize(stream) as SceneData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + scenePath);
            return null;
        }
    }

    public static void DeleteSave()
    {
        if (File.Exists(playerPath))
        {
            File.Delete(playerPath);
        }
        else
        {
            Debug.LogError("Save file not found in " + playerPath);
        }

        if (File.Exists(scenePath))
        {
            File.Delete(scenePath);
        }
        else
        {
            Debug.LogError("Save file not found in " + scenePath);
        }
    }
}
