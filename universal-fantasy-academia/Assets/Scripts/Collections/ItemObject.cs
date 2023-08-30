using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemScriptableObject Item;

    void Start()
    {
        if (Item != null)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture = Item.Icon.texture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the object
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
