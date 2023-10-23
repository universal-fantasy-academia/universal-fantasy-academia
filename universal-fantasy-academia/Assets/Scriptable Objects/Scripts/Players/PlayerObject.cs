using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObject : Player
{   
    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            base.selectedPlayerClass = playerSlot.GetComponentInChildren<PlayerClasses>();
            base.selectedPlayerClass.Attack(context, shot);
            base.PlayAttackAnimation();
        }
    }

    public void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            base.selectedPlayerClass = playerSlot.GetComponentInChildren<PlayerClasses>();
            base.selectedPlayerClass.Block(context);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fantasma"))
        {
            TakeDamage(5);
        }
    }


}
