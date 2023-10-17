using UnityEngine.UI;
using UnityEngine;


public class Equipaments : MonoBehaviour
{
    //[SerializeField] private Image weapon, accessory, armor;
    [SerializeField] private GameObject weapon, accessory, armor;
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

    public bool ChangeEquip(ItemScriptableObjectEquipment itemEquipment)
    {
        if (itemEquipment.classRestriction != ClassRestriction.CavaleiroDoSaber) // pega  classe atual(CavaleirodS)
        {
            Debug.Log("Item inválido");
            return false;
        }

        Image weaponImg = weapon.GetComponent<Image>();
        Image accessoryImg = accessory.GetComponent<Image>();
        Image armorImg = armor.GetComponent<Image>();


        switch (itemEquipment.equipmentType)
        {
            case EquipmentType.Weapon:
                weaponImg.overrideSprite = itemEquipment.Icon;
                weaponImg.enabled = true;
                weapon.GetComponent<Button>().onClick.AddListener(() => ChangeUnquip(itemEquipment));
                break;

            case EquipmentType.Accessory:
                accessoryImg.overrideSprite = itemEquipment.Icon;
                accessoryImg.enabled = true;
                accessory.GetComponent<Button>().onClick.AddListener(() => ChangeUnquip(itemEquipment));
                break;

            case EquipmentType.Armor:
                armorImg.overrideSprite = itemEquipment.Icon;
                armorImg.enabled = true;
                armor.GetComponent<Button>().onClick.AddListener(() => ChangeUnquip(itemEquipment));
                break;

        }

        return true;
    }

    public void ChangeUnquip(ItemScriptableObjectEquipment item)
    {
        Inventory.Instance.AddItem(item);

        switch (item.equipmentType)
        {
            case EquipmentType.Weapon:
                Destroy(weapon.GetComponent<Image>().sprite);
                weapon.GetComponent<Image>().enabled = false;
                break;

            case EquipmentType.Accessory:
                Destroy(accessory.GetComponent<Image>().sprite);
                accessory.GetComponent<Image>().enabled = false;
                break;

            case EquipmentType.Armor:
                Destroy(armor.GetComponent<Image>().sprite);
                armor.GetComponent<Image>().enabled = false;
                break;
        }
    }



}
