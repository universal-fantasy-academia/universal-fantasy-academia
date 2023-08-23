using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{   
    [SerializeField]
    protected float speed, rotation;
    private Vector2 moveInput;

    void FixedUpdate()
    {
        // transform.Translate(Vector3.forward * moveInput.y * speed * Time.deltaTime);

        // if(moveInput.x != 0)
        // {
        //     transform.Rotate(0, rotation*moveInput.x, 0);
        // }
        Debug.Log("teste: "+ moveInput.x);
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




