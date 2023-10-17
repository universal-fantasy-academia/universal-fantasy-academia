using UnityEngine.UI;
using UnityEngine;


public class Equipaments : MonoBehaviour
{
    [SerializeField] private Image weapon, accessory, armor;

    public static Equipaments equipaments;

    void Awake()
    {
        if(equipaments != null)
        {
            Destroy(gameObject);
        }
        else
        {
            equipaments = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void AddEquipament(ScriptableObject item)
    {

    }

    public bool ChangeEquip(ItemScriptableObjectEquipment itemEquipment)
    {
        if (itemEquipment.classRestriction != ClassRestriction.CavaleiroDoSaber) // pega  classe atual(CavaleirodS)
        {
            Debug.Log("Item inválido");
            return false;
        }

        switch (itemEquipment.equipmentType)
        {
            case EquipmentType.Weapon:
                weapon.overrideSprite = itemEquipment.Icon;
                weapon.enabled = true;
                break;

            case EquipmentType.Accessory:
                accessory.overrideSprite = itemEquipment.Icon;
                accessory.enabled = true;
                break;

            case EquipmentType.Armor:
                armor.overrideSprite = itemEquipment.Icon;
                armor.enabled = true;
                break;

        }

        return true;
    }



}
