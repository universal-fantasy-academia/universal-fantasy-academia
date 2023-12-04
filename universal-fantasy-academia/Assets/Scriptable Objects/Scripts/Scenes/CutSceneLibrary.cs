using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutSceneLibrary : MonoBehaviour
{
    public GameObject eyes;
    public TextMeshProUGUI textElement;

    public float typeSpeed = 0.1f;

    public float waitTime = 3f;

    public float finishTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = "";
        eyes.SetActive(false);

        StartCoroutine(WriteText("Continua..."));
    }

    IEnumerator WriteText(string sentence)
    {

        yield return new WaitForSeconds(waitTime);

        textElement.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textElement.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return new WaitForSeconds(waitTime);

        eyes.SetActive(true);

        yield return new WaitForSeconds(finishTime);

        textElement.text = "";

        yield return new WaitForSeconds(finishTime);

        eyes.SetActive(false);

        yield return new WaitForSeconds(finishTime);

        //Show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
