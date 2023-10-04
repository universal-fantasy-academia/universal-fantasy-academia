using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GameObjectUtils
{
    public static void NotifyDeletedObject(this GameObject gameObject, string id)
    {
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.destroyedObjectsIds.Add(id);
        }
        else
        {
            Debug.LogError("GameController not found");
            throw new System.Exception("GameController not found");
        }
    }

    public static bool IsObjectDestroyed(this GameObject gameObject, string id)
    {
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController != null)
        {
            foreach (string destroyedObjectId in gameController.destroyedObjectsIds)
            {
                if (destroyedObjectId == id)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            Debug.LogError("GameController not found");
            throw new System.Exception("GameController not found");
        }
    }


}
