using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogUtils
{
    public static bool CheckCondition(DialogCondition condition, int value)
    {
        switch (condition)
        {
            case DialogCondition.hasMoney:
                return PlayerPrefs.GetInt("Coins") >= value;
            case DialogCondition.hasXP:
                return PlayerPrefs.GetInt("XP") >= value;
            case DialogCondition.hasHP:
                return PlayerPrefs.GetInt("HP") >= value;
            default:
                return false;
        }
    }
}