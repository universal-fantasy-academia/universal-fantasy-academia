using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public abstract void Move();

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




