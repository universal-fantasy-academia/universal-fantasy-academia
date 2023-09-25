using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LadinoDasSombas : Player
{
    // [SerializeField]
    // private Animator animatorSword;
    
    // [SerializeField]
    // private string attackBoolAnimator; 
    // //private bool isAttacking;


    public override void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {            
            Debug.Log("Atacando na calada");
            base.PlayAttackAnimation();
            
        }
        
    }

    public override void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Bloqueando na calada");
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
