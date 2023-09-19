using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/New Player", order = 1)]
public class PlayerScriptableObject : ScriptableObject
{
    public PlayerClass playerType;
    public GameObject playerPrefab;
    public RuntimeAnimatorController animatorController;
    public string attackBoolAnimator;
}

public enum PlayerClass
{
    CavaleiroDoSaber,
    CientistaAlquimico,
    GuerreiroMatematico,
    LadinoDasSombas
}
