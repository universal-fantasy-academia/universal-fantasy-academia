using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSensor : MonoBehaviour
{
    private List<Interactable> interact = new List<Interactable>(10);
    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Interactable>(out Interactable interactable))
        {
            interact.Add(interactable);
            InteractView();
            Debug.Log(interact);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Interactable>(out Interactable interactable) && interact.Contains(interactable))
        {
            interact.Remove(interactable);
            if (interactable.interactUIObject != null)
            {
                interactable.interactUIObject.SetActive(false);
            }
            InteractView();
        }
    }

    void InteractView()
    {
        for(int i = 0; i < interact.Count; i++)
        {
            if(i == 0)
            {
                if (interact[i].interactUIObject != null)
                {
                    interact[i].interactUIObject.SetActive(true);
                    interact[i].interactMessageTextObject.text = interact[i].interactMessage;
                    //interactMessageIconObject.GetComponent<SpriteRenderer>().sprite = interactMessageIcon;
                }
            }
            else
            {
                if (interact[i].interactUIObject != null)
                {
                    interact[i].interactUIObject.SetActive(false);
                }
            }

        }
    }

    public Interactable GetInteractable()
    {
        if(interact.Count > 0)
        {
            return interact[0];
        }
        return null;
    }

}
