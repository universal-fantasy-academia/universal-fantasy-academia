using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemScriptableObject Item;

 
    public string Id; //{ get; private set;}

    void Start()
    {
        Id = transform.position.sqrMagnitude.ToString("0000000000000000.0000000000000000");
        //Debug.Log(Id);
    
        if (Item != null)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture = Item.Icon.texture;
            Item.quantity = 0;
        }

        if (gameObject.IsObjectDestroyed(this.Id))
        {
            Destroy(gameObject);
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
            if (Item.quantity < Item.maxQuantity)
            {
                Item.Collect();
                gameObject.NotifyDeletedObject(this.Id);
                Destroy(gameObject);
            }
            
        }
    }
}
