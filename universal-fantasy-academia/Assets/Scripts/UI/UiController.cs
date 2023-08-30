using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    public GameObject InventoryPanel, InventoryContent, PrefabItem;
    



    #region Button Actions


    public void OpenInventory()
    {
        if (InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(false);
        }
        else
        {
            InventoryPanel.SetActive(true);
        }
    }


    #endregion Button Actions
}
