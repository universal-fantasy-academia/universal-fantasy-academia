using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : Interactable
{
    public ItemScriptableObject Item;
    public GameObject prefab;
    [Range(1, 10)]
    public int quantity = 1;

    public Animator animator;
    public string actionBoolAnimator;

    private GameObject droppedItem;

    private bool isDropped = false;

    private Player player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void PlayActionAnimator()
    {
        animator.SetTrigger(actionBoolAnimator);
    }



    void Start()
    {
        interactDelegate += OnDrop;
    }

    public void OnDrop()
    {

        if (isDropped)
        {
            return;
        }

        if(animator != null)
        {
            PlayActionAnimator();
        }

        for (int i = 0; i < quantity; i++)
        {
//            Vector3 playerPosition = player.gameObject.transform.position;
//
//            float x = Random.Range(playerPosition.x - 2, playerPosition.x + 2);
//            float z = Random.Range(playerPosition.z - 2, playerPosition.z + 2);
//
//            Vector3 dropPosition = new Vector3(x, playerPosition.y + 1, z);

            Vector3 dropPosition = gameObject.transform.GetChild(1).position;

            prefab.GetComponent<Animator>().enabled = true;

            droppedItem = Instantiate(prefab, dropPosition, Quaternion.identity);
            droppedItem.GetComponent<ItemObject>().Item = Item;
            droppedItem.GetComponent<ItemObject>().Id = droppedItem.transform.position.sqrMagnitude.ToString("0000000000000000.0000000000000000");

            if (droppedItem.gameObject.IsObjectDestroyed(droppedItem.GetComponent<ItemObject>().Id))
            {
                Destroy(droppedItem);
            }
        }

        isDropped = true;
        
    }


    void OnDisable()
    {
        interactDelegate -= OnDrop;
    }
}
