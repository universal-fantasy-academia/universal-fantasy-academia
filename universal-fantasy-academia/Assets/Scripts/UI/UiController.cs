using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiController : MonoBehaviour
{   
    [Header("InventoryHud")]
    public GameObject InventoryPanel, InventoryContent, PrefabItem;
    public GameObject movPlayer, camera;

    [Header("XP and HP Hud")]
    public TextMeshProUGUI XP;
    public TextMeshProUGUI HP;

    

    public void Awake()
    {
        InventoryPanel.SetActive(false);
    }


    public void OnChangeHp(int hp)
    {
        //PlayerPrefs.SetInt("HP", hp);
        HP.text = hp.ToString();
    }

    public void OnChangeXp(int xp)
    {
        //PlayerPrefs.SetInt("XP", xp);
        XP.text = xp.ToString();
    }

    #region Button Actions

    public void OpenInventory()
    {
        if (InventoryPanel.activeSelf)
        {
            movPlayer.GetComponent<PlayerInput>().enabled = true;
            camera.SetActive(true);
            InventoryPanel.SetActive(false);
        }
        else
        {
            movPlayer.GetComponent<PlayerInput>().enabled = false;
            camera.SetActive(false);
            InventoryPanel.SetActive(true);
        }
    }


    #endregion Button Actions
}
