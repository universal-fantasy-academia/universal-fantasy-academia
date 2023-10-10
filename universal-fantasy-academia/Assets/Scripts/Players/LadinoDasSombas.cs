using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LadinoDasSombas : PlayerClasses
{
    public override void Attack(InputAction.CallbackContext context, ShotController shot)
    {
        if(context.performed)
        {            
            Debug.Log("Atacando na calada");
            //base.PlayAttackAnimation();
            
        }
        
    }

    public override void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Bloqueando na calada");
        }
        
    }
}
