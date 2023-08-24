using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public string interactMessage;
    public GameObject interactMessageObject;
    public GameObject interactMessageTextObject;
    public GameObject interactMessageBackgroundObject;
    public GameObject interactMessageIconObject;
    public Sprite interactMessageIcon;
    public bool isInteractable = true;

    //Delegate to be called when the player interacts with this object
    public delegate void InteractDelegate();
    public InteractDelegate interactDelegate;

    private void Start()
    {
        if (interactMessageObject != null)
        {
            interactMessageObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey) && isInteractable)
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interagindo com " + gameObject.name);
        if (interactDelegate != null)
        {
            interactDelegate();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            if (interactMessageObject != null)
            {
                interactMessageObject.SetActive(true);
                interactMessageTextObject.GetComponent<TMPro.TextMeshProUGUI>().text = interactMessage;
                interactMessageIconObject.GetComponent<SpriteRenderer>().sprite = interactMessageIcon;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            if (interactMessageObject != null)
            {
                interactMessageObject.SetActive(false);
            }
        }
    }
}
