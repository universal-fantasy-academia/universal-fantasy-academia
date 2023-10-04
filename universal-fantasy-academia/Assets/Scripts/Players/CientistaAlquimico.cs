using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CientistaAlquimico : Player
{
    // [SerializeField]
    // private Animator animatorSword;
    
    // [SerializeField]
    // private string attackBoolAnimator; 
    //private bool isAttacking;


    public override void Attack(InputAction.CallbackContext context)
    {
        if(context.performed && Time.time > shot.nextFire)
        {
            shot.nextFire = Time.time + shot.fireRate;
            shot.Shooter();
            Debug.Log("Atacando com a pedra filosofal");
            base.PlayAttackAnimation();
        }
        
    }

    public override void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Bloqueando com a pedra filosofal");
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
