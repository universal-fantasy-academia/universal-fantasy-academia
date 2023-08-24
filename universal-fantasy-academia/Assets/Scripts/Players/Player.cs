using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{   
    [SerializeField]
    protected float speed, rotation, jumpForce;
    private Vector2 moveInput;

    protected Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveInput.x, 0, moveInput.y) * speed * Time.fixedDeltaTime);
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Método para pular.
    /// </summary>
    /// <remarks>
    /// O método é implementado como virtual para que a classe filha possa sobrescrever com pulo duplo, por exemplo.
    /// </remarks>
    /// <param name="context"></param>
    public virtual void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(Vector3.up * jumpForce);//, ForceMode.Impulse);
        }
    }

    public abstract void Attack(InputAction.CallbackContext context);

    public abstract void Block(InputAction.CallbackContext context);


    public void Die() 
    {
        //TODO: Implementar morte
    }

    public abstract void Respawn();


    public abstract void TakeDamage(int damage);

    public abstract void Heal(int healAmount);


    // public abstract void CollectItem(Item item);

    // public abstract void UseItem(Item item);


    public virtual void Interact(InputAction.CallbackContext context)
    {
        //TODO: Verificar se entrou no trigger de algum objeto interagível
        // Se sim, pegar o script Interactable e chamar o método Interact()

        if (context.performed)
        {
            Debug.Log("Interagindo");
        }
    }



    
}




