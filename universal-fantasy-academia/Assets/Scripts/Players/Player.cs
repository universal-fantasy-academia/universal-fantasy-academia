using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{   
    [SerializeField]
    private float speed, runSpeed, jumpHeight, gravityValue, rotation;
    [SerializeField]
    private Transform cameraTransform, playerTransform, orientation;
    [SerializeField]
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool playerIsGrounded;
    private float playerMagnitude;
    private Vector2 moveInput;

    private Interactable interactable;

    public Transform respawn;

    public int XP { get; private set; }
    public int HP { get; private set; }

    public UiController uiController;

    void Awake()
    {
        //Pega p valor do XP e HP do player no playerprefs
        int xp = PlayerPrefs.GetInt("XP", 1);
        LevelUp(xp);
        int hp = PlayerPrefs.GetInt("HP", 50);
        ChangeHp(hp);

        controller = GetComponent<CharacterController>();

        respawn = GameObject.FindGameObjectWithTag("Respawn").transform;
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


        if(Input.GetKeyDown(KeyCode.F1))
        Respawn();

    }

    void StopRun()
    {
        if(speed >= 10)
        speed -= 5;
        else
        return;


    }

    public void Run(InputAction.CallbackContext context)
    {
        if(context.performed && playerIsGrounded && speed <= 5)
        {
            speed *= runSpeed;
            Invoke(nameof(StopRun), 10);
        }
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
        int hp = PlayerPrefs.GetInt("HP", 50);
        ChangeHp(hp);
        //DeathScreen.Play;
        Respawn();
        //HP = 50;
        Debug.Log("Morreu");
    }


    public virtual void Respawn()
    {
        Debug.Log(respawn.position);

        //coin -= coin * 0.10f;
        //PlayerPrefs.SetInt("HP", 50);
        playerTransform.position = respawn.position;
        playerTransform.forward = respawn.forward;
        Debug.Log("Respawnando - " + playerTransform.position);
    }

    public void ChangeHp(int hp)
    {
        HP = hp;
        uiController.OnChangeHp(hp);
    }


    public virtual void TakeDamage(int damage)
    {
        if (HP - damage <= 0)
        {
            Die();
        }
        else
        {
            ChangeHp(HP - damage);
        }
    }

    public virtual void Heal(int healAmount)
    {
        if (HP + healAmount > 100)
        {
            HP = 100;
        }
        else
        {
            ChangeHp(HP + healAmount);
        }
    }

    public void LevelUp(int xpAmount)
    {
        uiController.OnChangeXp(XP + xpAmount);
        XP += xpAmount;
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if(context.performed && interactable.isInRange && interactable.isInteractable)
        {
            Debug.Log("Test");
            interactable.Interact();
        }
    }

    //Coloca a arma na mão do player
    public void EquipWeapon(ItemScriptableObjectWeapon weapon)
    {

    }


    // public abstract void CollectItem(Item item);

    // public abstract void UseItem(Item item);






}




