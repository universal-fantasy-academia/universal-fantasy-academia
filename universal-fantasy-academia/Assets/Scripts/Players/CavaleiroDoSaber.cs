using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CavaleiroDoSaber : Player
{   
    [SerializeField]
    private Animator animatorSword;
    
    [SerializeField]
    private string attackBoolAnimator; 
    //private bool isAttacking;


    public override void Attack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {            
            Debug.Log("Atacando com a espada");
            animatorSword.SetTrigger(attackBoolAnimator);
        }
        
    }

    public override void Block(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Bloqueando com a espada");
        }
        
    }

    public override void Heal(int healAmount)
    {
        Debug.Log("Curando");
    }

    public override void Respawn()
    {
        Debug.Log("Revivendo");
    }

    public override void TakeDamage(int damage)
    {
        Debug.Log("Tomando dano");
    }

}
