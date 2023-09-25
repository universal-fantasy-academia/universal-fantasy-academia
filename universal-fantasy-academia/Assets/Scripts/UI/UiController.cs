using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiController : MonoBehaviour
{   

    [Header("Options")]
    public GameObject OptionsPanel;
    public GameObject saveConfirmationMessage;
    public AudioController audioController;


    [Header("InventoryHud")]
    public GameObject InventoryPanel, InventoryContent, PrefabItem;
    public GameObject movPlayer, camera;

    [Header("XP and HP Hud")]
    public TextMeshProUGUI XP;
    public TextMeshProUGUI HP;

    [Header("System")]
    public GameController gameController;

    private TextMeshProUGUI saveConfirmationTextMeshPro;

    
    void Start()
    {

        if (saveConfirmationMessage)
        {
            saveConfirmationTextMeshPro = saveConfirmationMessage.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void Awake()
    {
        if (InventoryPanel)
        {
            InventoryPanel.SetActive(false);
        }

        if (OptionsPanel)
        {
            OptionsPanel.SetActive(false);
        }
    }


    public void OnChangeHp(int hp)
    {
        PlayerPrefs.SetInt("HP", hp);
        HP.text = hp.ToString();
    }

    public void OnChangeXp(int xp)
    {
        //PlayerPrefs.SetInt("XP", xp);
        XP.text = xp.ToString();
    }

    #region Button Actions

//    public void StartInput(InputAction.CallbackContext context)
//    {
//        if(context.performed)
//        {
//            if (InventoryPanel.activeSelf)
//            {
//                movPlayer.GetComponent<PlayerInput>().enabled = true;
//                camera.SetActive(true);
//                InventoryPanel.SetActive(false);
//
//            }
//            else
//            {
//                movPlayer.GetComponent<PlayerInput>().enabled = false;
//                camera.SetActive(false);
//                InventoryPanel.SetActive(true);
//            }
//        }
//    }


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


    public void SaveGame()
    {
        try
        {
            gameController.SaveGame();
            
            //Change text
            saveConfirmationTextMeshPro.text = "Salvo!";
            //Change color
            saveConfirmationTextMeshPro.color = Color.green;
            //Show message
            saveConfirmationMessage.SetActive(true);
            //Hide message after 2 seconds
            StartCoroutine(VisibilityUtils.HideGameObjectAfterTime(saveConfirmationMessage, 2f));

        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            //Change text
            saveConfirmationTextMeshPro.text = "Erro ao salvar!";
            //Change color
            saveConfirmationTextMeshPro.color = Color.red;
            //Show message
            saveConfirmationMessage.SetActive(true);
            //Hide message after 2 seconds
            StartCoroutine(VisibilityUtils.HideGameObjectAfterTime(saveConfirmationMessage, 2f));
        }
    }

    


    public void OpenOptionsMenu()
    {
        if (OptionsPanel)
        {
            if (audioController)
            {
                audioController.SetSliderValues();
            }

            if (movPlayer)
            {
                movPlayer.GetComponent<PlayerInput>().enabled = false;
                camera.SetActive(false);
            }
            
            OptionsPanel.SetActive(true);
        }
    }

    public void CloseOptionsMenu()
    {
        if (OptionsPanel)
        {
            OptionsPanel.SetActive(false);

            if (movPlayer)
            {
                movPlayer.GetComponent<PlayerInput>().enabled = true;
                camera.SetActive(true);
            }
        }
    }


    #endregion Button Actions
}
