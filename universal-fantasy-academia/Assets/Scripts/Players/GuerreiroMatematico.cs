using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GuerreiroMatematico : PlayerClasses
{

    public override void Attack(InputAction.CallbackContext context, ShotController shot)
    {
        if(context.performed)
        {            
            Debug.Log("Atacando com o 3.14");
            //base.PlayAttackAnimation();

        }

    }

    public override void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Bloqueando com o 3.14");
        }
        
    }
}
