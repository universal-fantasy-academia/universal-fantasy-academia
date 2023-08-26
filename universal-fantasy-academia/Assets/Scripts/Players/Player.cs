using System.Collections;
using System.Collections.Generic;
using System.Data;
//using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{   
    [SerializeField]
    protected float speed, jumpHeight, gravityValue, rotation;
    [SerializeField]
    protected CharacterController controller;
    protected Vector3 playerVelocity;
    private bool playerIsGrounded;
    private Vector2 moveInput;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        playerIsGrounded = controller.isGrounded; 

        if(playerIsGrounded && playerVelocity.y < 0) //Pega a informação do player sobre ele está no chão, se estiver zera o vetor y 
        {
            playerVelocity.y = 0;
        }
    }

    void FixedUpdate()
    {
       Vector3 dir = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(dir * speed * Time.deltaTime);
        
        if(dir != Vector3.zero)
        {
            gameObject.transform.forward = dir * rotation;
        }
        
        playerVelocity.y += gravityValue * Time.deltaTime; 
        controller.Move(playerVelocity * Time.deltaTime);
        
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
        if (context.performed && playerIsGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
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




