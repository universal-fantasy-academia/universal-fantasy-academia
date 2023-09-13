using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public string interactMessage;
    public GameObject interactUIObject;
    public TextMeshProUGUI interactMessageTextObject;
    //public GameObject interactMessageBackgroundObject;
    public GameObject interactMessageIconObject;
    public Sprite interactMessageIcon;
    public bool isInteractable = true;

    //Delegate to be called when the player interacts with this object
    public delegate void InteractDelegate();
    public InteractDelegate interactDelegate;

    private void Start() {
        if (interactUIObject != null)
        {
            interactUIObject.SetActive(false);
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

}
