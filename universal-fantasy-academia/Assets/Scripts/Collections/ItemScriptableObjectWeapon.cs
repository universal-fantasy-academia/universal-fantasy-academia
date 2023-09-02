using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Game Items/Weapon")]
public class ItemScriptableObjectWeapon : ItemScriptableObject
{
    public enum WeaponType
    {
        Sword,
        Axe,
        Bow,
        Staff,
        Wand,
        Shield
    }

    public WeaponType weaponType;

    public override void Use(Player playerScript)
    {
        Debug.Log("Weapon Item");
    }

}
