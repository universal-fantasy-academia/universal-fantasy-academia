using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{   
    [SerializeField]
    public float speed, runSpeed, jumpHeight, gravityValue, rotation;
    [SerializeField]
    public Transform cameraTransform, playerTransform, orientation;
    [SerializeField]
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool playerIsGrounded;
    private Vector2 moveInput;

    public InteractSensor interactSensor;
    public ShotController shot;

    [NonSerialized]
    public Transform respawn;

    public GameObject playerSlot;
    public PlayerClasses selectedPlayerClass;
    public PlayerScriptableObject playerSelected;
    public PlayerScriptableObject cavaleiroDoSaber;
    public PlayerScriptableObject cientistaAlquimico;
    public PlayerScriptableObject guerreiroMatematico;
    public PlayerScriptableObject ladinoDasSombas;

    public int XP = 1;
    public int HP = 50;

    public UiController uiController;


    private Animator animator;
    private string attackBoolAnimator;

    private  PlayerData playerData = null;


    private string PLAYER_PREFS_PLAYER_SELECTED = "PlayerSelected";


    void Start()
    {
//        Cursor.lockState = CursorLockMode.Locked;

        playerData = SaveSystem.LoadPlayer();
        if(playerData != null)
        {
            CharacterController controller = transform.GetComponent<CharacterController>();

            controller.enabled = false;
            SetPlayerData(playerData);
            controller.enabled = true;

            selectedPlayerClass = playerSlot.GetComponentInChildren<PlayerClasses>();
        }

        // int playerId = PlayerPrefs.GetInt(PLAYER_PREFS_PLAYER_SELECTED, 0);
        // switch (playerId)
        // {
        //     case 0:
        //         ChangePlayer(cavaleiroDoSaber);
        //         break;
        //     case 1:
        //         ChangePlayer(cientistaAlquimico);
        //         break;
        //     case 2:
        //         ChangePlayer(guerreiroMatematico);
        //         break;
        //     case 3:
        //         ChangePlayer(ladinoDasSombas);
        //         break;
        //     default:
        //         ChangePlayer(cavaleiroDoSaber);
        //         break;
        // }

        UpdateAnimator();
        
    }

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


        if(Input.GetKeyDown(KeyCode.F2))
        {
            int currentPlayer = (int)playerSelected.playerType;
            int nextPlayer = (currentPlayer + 1) % 4;
            //Get name from enum
            string name = Enum.GetName(typeof(PlayerClass), nextPlayer);
            Debug.Log("Player: " + name);
            switch (nextPlayer)
            {
                case 0:
                    ChangePlayer(cavaleiroDoSaber);
                    break;
                case 1:
                    ChangePlayer(cientistaAlquimico);
                    break;
                case 2:
                    ChangePlayer(guerreiroMatematico);
                    break;
                case 3:
                    ChangePlayer(ladinoDasSombas);
                    break;
                default:
                    ChangePlayer(cavaleiroDoSaber);
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        VerifyHp();


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
        {    
            Respawn();
        }


    }


    public void SetPlayerData(PlayerData playerData)
    {
        ChangeXP(playerData.xp);
        ChangeHp(playerData.hp);
        speed = playerData.speed;
        runSpeed = playerData.runSpeed;
        jumpHeight = playerData.jumpHeight;
        gravityValue = playerData.gravityValue;
        rotation = playerData.rotation;

        Debug.Log(playerData.position[0] + " " + playerData.position[1] + " " + playerData.position[2]);

        transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
        transform.rotation = Quaternion.Euler(playerData.rotationPlayer[0], playerData.rotationPlayer[1], playerData.rotationPlayer[2]);

        // cameraTransform.position = new Vector3(playerData.positionCamera[0], playerData.positionCamera[1], playerData.positionCamera[2]);
        // cameraTransform.rotation = new Quaternion(playerData.rotationCamera[0], playerData.rotationCamera[1], playerData.rotationCamera[2], 0);

        switch (playerData.playerId)
        {
            case 0:
                ChangePlayer(cavaleiroDoSaber);
                break;
            case 1:
                ChangePlayer(cientistaAlquimico);
                break;
            case 2:
                ChangePlayer(guerreiroMatematico);
                break;
            case 3:
                ChangePlayer(ladinoDasSombas);
                break;
            default:
                ChangePlayer(cavaleiroDoSaber);
                break;
        }
    }


    private void UpdateAnimator()
    {
        animator = GetComponentInChildren<Animator>();
        //Debug.Log(animator);
        animator.runtimeAnimatorController = playerSelected.animatorController;
        attackBoolAnimator = playerSelected.attackBoolAnimator;
    }

    public void PlayAttackAnimation()
    {
        if (!animator)
        {
            UpdateAnimator();
        }
        animator.SetTrigger(attackBoolAnimator);
    }



    public void ChangePlayer(PlayerScriptableObject player)
    {
        playerSlot.SetActive(false);
        Destroy(playerSlot.transform.GetChild(0).gameObject);
        Instantiate(player.playerPrefab, playerSlot.transform.position, playerSlot.transform.rotation, playerSlot.transform);
        playerSlot.SetActive(true);

        UpdateAnimator();

        //PlayerPrefs.SetInt("Player", Array.IndexOf(new PlayerScriptableObject[] { cavaleiroDoSaber, cientistaAlquimico, guerreiroMatematico, ladinoDasSombas }, player.GetComponent<PlayerScriptableObject>()));
        PlayerPrefs.SetInt(PLAYER_PREFS_PLAYER_SELECTED, (int)player.playerType);
        playerSelected = player;
        
        selectedPlayerClass = playerSlot.GetComponentInChildren<PlayerClasses>();
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

    // public abstract void Attack(InputAction.CallbackContext context);

    // public abstract void Block(InputAction.CallbackContext context);


    public void Die()
    {
        Debug.Log("No céu tem pão? E morreu!");
        //DeathScreen.Play;
        Respawn();
        HP = 50;
        PlayerPrefs.SetInt("HP", HP);
        ChangeHp(HP);
    }





    public virtual void Respawn()
    {

        CharacterController controller = transform.GetComponent<CharacterController>();
        controller.enabled = false;
        Debug.Log(respawn.position);

        //coin -= coin * 0.10f;
        //PlayerPrefs.SetInt("HP", 50);
        playerTransform.position = respawn.position;
        playerTransform.forward = respawn.forward;
        Debug.Log("Respawnando - " + playerTransform.position);

        controller.enabled = true;
    }

    public void ChangeHp(int hp)
    {
        HP = Mathf.Min(hp, 100);
        uiController.OnChangeHp(HP);
    }

    private void VerifyHp()
    {
        if (HP <= 0)
        {
            Die();
        }
    }


    public virtual void TakeDamage(int damage)
    {
        // if (HP - damage <= 0)
        // {
        //     Die();
        // }
        // else
        // {
        //     ChangeHp(HP - damage);
        // }

        ChangeHp(HP - damage);
    }

    public virtual void Heal(int healAmount)
    {
//        if (HP + healAmount > 100)
//        {
//            HP = 100;
//        }


        ChangeHp(HP + healAmount);

    }

    public void LevelUp(int xpAmount)
    {
        uiController.OnChangeXp(XP + xpAmount);
        XP += xpAmount;
    }

    public void ChangeXP(int xp)
    {
        uiController.OnChangeXp(xp);
        XP = xp;
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Interactable interactable = interactSensor.GetInteractable();
            if(interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    //Coloca a arma na mão do player
    public void EquipWeapon(ItemScriptableObjectWeapon weapon)
    {
    }


    // public abstract void CollectItem(Item item);

    // public abstract void UseItem(Item item);






}




