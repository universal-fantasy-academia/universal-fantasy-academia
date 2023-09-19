using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VisibilityUtils
{
    public static IEnumerator HideGameObjectAfterTime(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
    
}
