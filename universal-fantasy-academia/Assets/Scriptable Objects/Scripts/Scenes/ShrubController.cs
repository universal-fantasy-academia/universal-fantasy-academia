using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrubController : MonoBehaviour
{
    public GameObject shrubs;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Shake shrub");
            StartCoroutine(ShakeShrub());

        }
    }

    IEnumerator ShakeShrub()
    {
        shrubs.transform.position = new Vector3(shrubs.transform.position.x + 0.5f, shrubs.transform.position.y + 0.1f, shrubs.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        shrubs.transform.position = new Vector3(shrubs.transform.position.x - 0.5f, shrubs.transform.position.y - 0.1f, shrubs.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        shrubs.transform.position = new Vector3(shrubs.transform.position.x, shrubs.transform.position.y + 0.2f, shrubs.transform.position.z + 0.5f);
        yield return new WaitForSeconds(0.1f);
        shrubs.transform.position = new Vector3(shrubs.transform.position.x, shrubs.transform.position.y - 0.2f, shrubs.transform.position.z - 0.5f);
        yield return new WaitForSeconds(0.1f);
    }
}
