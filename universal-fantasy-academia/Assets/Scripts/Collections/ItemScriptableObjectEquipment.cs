using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ClassRestriction
{
    CavaleiroDoSaber,
    CientistaAlquimico,
    GuerreiroMatematico,
    LadinoDasSombras
}

public enum EquipmentType
{
    Weapon,
    Accessory,
    Armor
}

[CreateAssetMenu(fileName = "New Equipment", menuName = "Game Items/Equipment")]
public class ItemScriptableObjectEquipment : ItemScriptableObject
{


    public ClassRestriction classRestriction;
    public EquipmentType equipmentType;

    public override bool Use(Player playerScript)
    {
        return Equipaments.equipaments.ChangeEquip(this);
    }

}
