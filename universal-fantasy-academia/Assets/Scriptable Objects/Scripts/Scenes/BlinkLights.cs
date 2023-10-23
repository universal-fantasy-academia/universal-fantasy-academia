using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLights : MonoBehaviour
{
    public GameObject[] lights;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
    }

    //Blink lights randomly in a random delay between 0.5 and 1.5 seconds
    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.05f, 0.5f));
            int lightIndex = Random.Range(0, lights.Length);
            lights[lightIndex].SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.01f, 0.3f));
            lights[lightIndex].SetActive(false);       
        }
    }
}
