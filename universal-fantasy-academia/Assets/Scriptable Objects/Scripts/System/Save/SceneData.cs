using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public string sceneName;
    public List<string> destroyedObjectsIds;

    public SceneData(string sceneName, List<string> destroyedObjectsIds)
    {
        this.sceneName = sceneName;
        this.destroyedObjectsIds = destroyedObjectsIds;
    }

    
}
