using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CientistaAlquimico : PlayerClasses
{

    public override void Attack(InputAction.CallbackContext context, ShotController shot)
    {
        if(context.performed && Time.time > shot.nextFire)
        {
            shot.nextFire = Time.time + shot.fireRate;
            shot.Shooter();
            Debug.Log("Atacando com a pedra filosofal");
            //base.PlayAttackAnimation();
        }
        
    }

    public override void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Bloqueando com a pedra filosofal");
        }
        
    }
}
