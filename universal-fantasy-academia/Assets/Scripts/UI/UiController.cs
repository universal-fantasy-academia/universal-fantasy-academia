using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiController : MonoBehaviour
{

    public GameObject InventoryPanel, InventoryContent, PrefabItem;
    public GameObject movPlayer, camera;



    #region Button Actions

    public void Awake()
    {
        InventoryPanel.SetActive(false);
    }


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
