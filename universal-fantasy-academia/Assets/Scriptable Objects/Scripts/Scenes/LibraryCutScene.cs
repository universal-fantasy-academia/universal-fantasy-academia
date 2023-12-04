using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryCutScene : MonoBehaviour
{
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(CallCutScene());
        }
    }

    IEnumerator CallCutScene()
    {
        yield return new WaitForSeconds(1.5f);
        gameController.LoadScene("Cutscene_Library");
    }
}
