using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Debug.Log(moveInput);
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public abstract void Jump();

    public abstract void Attack();

    public abstract void Block();


    public abstract void Die();

    public abstract void Respawn();


    public abstract void TakeDamage(int damage);

    public abstract void Heal(int healAmount);


    // public abstract void CollectItem(Item item);

    // public abstract void UseItem(Item item);


    //public abstract void Interact(Interactable interactable);



    
}




