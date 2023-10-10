using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CavaleiroDoSaber : PlayerClasses
{   

    public override void Attack(InputAction.CallbackContext context, ShotController shot)
    {
        if(context.performed)
        {
            Debug.Log("Atacando com a espada");
            //animatorSword.SetTrigger(attackBoolAnimator);
            //base.PlayAttackAnimation();
        }
    }

    public override void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Bloqueando com a espada");
        }
        
    }


}
