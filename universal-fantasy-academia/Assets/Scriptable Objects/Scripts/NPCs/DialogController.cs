using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


[System.Serializable]
public class DialogLine
{
    public string characterName;
    public Sprite characterImage;
    public string sentence;
}

public enum DialogCondition
{
    None,
    hasMoney,
    hasXP,
    hasHP
}

public class DialogController : MonoBehaviour
{
    public GameObject dialogBox;
    [SerializeField]
    public Image characterImage;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogText;
    public GameObject alertNext;
    [SerializeField]
    public DialogLine[] sentences = new DialogLine[20];
    private int index = 0;
    public float dialogSpeed = 0.02f;

    private bool isInteracting;
    public GameObject interactIndicator;
    public TextMeshProUGUI interactText;

    public GameObject dropItem = null;
    private bool isDropped = false;

    public bool isConditional = false;
    public DialogCondition dialogCondition;
    public DialogLine[] sentencesConditionTrue;
    public DialogLine[] sentencesConditionFalse;

    public UiController uiController;

    private Vector3 playerPosition;

    bool isWriting = false;


    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        isInteracting = false;
        alertNext.SetActive(false);

        //uiController = GameObject.Find("UIController").GetComponent<UiController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting && Input.GetKeyDown(KeyCode.E) && !isWriting)
        {
            if (!dialogBox.activeSelf)
            {
                dialogBox.SetActive(true);
                interactIndicator.SetActive(false);
                NextSentence();
            }
            else
            {
                NextSentence();
            }
        }
    }

    void NextSentence()
    {
        DialogLine[] dialogLines = new DialogLine[20];
        for (int i = 0; i < sentences.Length; i++)
        {
            dialogLines[i] = sentences[i];
        }

        //Se tiver algum condicional, adiciona a sentenças ao dialogLines
        int indexConditional = 0;
        int totalSentences = sentences.Length;
        bool isTrue = false;
        if (isConditional)
        {
            indexConditional = sentences.Length + 1;
            switch (dialogCondition)
            {
                case DialogCondition.hasMoney:
                    if (PlayerPrefs.GetInt("Coins") >= 10)
                    {
                        isTrue = true;
                        totalSentences += sentencesConditionTrue.Length;
                        for (int i = 0; i < sentencesConditionTrue.Length; i++)
                        {
                            dialogLines[i + sentences.Length] = sentencesConditionTrue[i];
                        }
                    }
                    else
                    {
                        totalSentences += sentencesConditionFalse.Length;
                        for (int i = 0; i < sentencesConditionFalse.Length; i++)
                        {
                            dialogLines[i + sentences.Length] = sentencesConditionFalse[i];
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        alertNext.SetActive(false);
        if (index < totalSentences)
        {
            dialogText.text = "";
            StartCoroutine(WriteSentence(dialogLines[index]));

            if (isConditional && index == indexConditional)
            {
                switch (dialogCondition)
                {
                    case DialogCondition.hasMoney:
                        if (isTrue)
                        {
                            uiController.OnChangeCoins(PlayerPrefs.GetInt("Coins") - 10);
                        }
                        break;
                    default:
                        break;
                }
            }

            index++;

            if (index == totalSentences)
            {
                if (dropItem != null && !isDropped)
                {
                    Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    //Rotate to face player
                    Vector3 lookDirection = dropPosition - playerPosition;
                    Quaternion rotation = Quaternion.LookRotation(lookDirection);
                    Instantiate(dropItem, dropPosition, rotation);
                    isDropped = true;
                }
            }

        }
        else
        {
            dialogBox.SetActive(false);
            index = 0;
        }

        alertNext.SetActive(true);
    }

    IEnumerator WriteSentence(DialogLine dialogLine)
    {
        isWriting = true;

        characterImage.sprite = dialogLine.characterImage;
        characterName.text = dialogLine.characterName;

        foreach (char letter in dialogLine.sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(dialogSpeed);
        }

        isWriting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactIndicator.SetActive(true);
            interactText.text = "Conversar";
            isInteracting = true;

            playerPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactIndicator.SetActive(false);
            if (dialogBox.activeSelf)
            {
                dialogBox.SetActive(false);
            }
            index = 0;
            isInteracting = false;
        }
    }

}
