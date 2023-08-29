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
    private float speed, jumpHeight, gravityValue, rotation;
    [SerializeField]
    private Transform cameraTransform, playerTransform, orientation;
    [SerializeField]
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool playerIsGrounded;
    private Vector2 moveInput;

    void Awake()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
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
        Vector3 viewDir = playerTransform.position - new Vector3(cameraTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
        orientation.rotation = Quaternion.LookRotation(viewDir.normalized, Vector3.up);
        
        Vector3 dir = orientation.forward * moveInput.y + orientation.right * moveInput.x;
        controller.Move(dir.normalized * speed * Time.fixedDeltaTime);

        if(dir != Vector3.zero)
        {
            playerTransform.forward = Vector3.Slerp(playerTransform.forward, dir.normalized, Time.fixedDeltaTime * rotation);
        }

        playerVelocity.y += gravityValue * Time.fixedDeltaTime; 
        controller.Move(playerVelocity * Time.fixedDeltaTime);
        
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

    public virtual void Respawn()
    {

    }


    public virtual void TakeDamage(int damage)
    {

    }

    public virtual void Heal(int healAmount)
    {

    }


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




