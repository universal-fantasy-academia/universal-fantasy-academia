using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class BombTest : MonoBehaviour
{
    public AudioSource initialSound;
    public AudioSource explodionSound;
    public GameObject player;
    public Player playerController;
    public float speed = 2 , rotation;
    private Transform transformEnemy;
    public int life = 2;
    public int minMagnitude;

    public float attackMin = 0f;
    public float attackMax = 65f;
    public float runAwayMin = 45f;
    public float runAwayMax = 100f;

    private NavMeshAgent navMeshAgent;


    void Awake()
    {
        transformEnemy = GetComponent<Transform>();
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        playerController = player.GetComponent<Player>();
    }


    void FixedUpdate()
    {
        //Verifica se o player está no mesmo andar que o inimigo
        if(Mathf.Abs(player.transform.position.y - transformEnemy.position.y) > 2)
        {
            return;
        }

        Vector3 dir;
        dir = player.transform.position - transformEnemy.position;

        float m = dir.magnitude;

        if(m < minMagnitude)
        {
            // transformEnemy.position += dir * Time.fixedDeltaTime * speed;
            // if(dir != Vector3.zero)
            // {
            //     transformEnemy.forward = Vector3.Slerp(transformEnemy.forward, dir.normalized, Time.fixedDeltaTime * rotation);
            // }

            EvaluateFuzzyLogic(playerController.HP);

            //Debug.Log("Magnitude: " + m);


            //Invoke(nameof(DeathGhost), 10f);
        }
    }


    void EvaluateFuzzyLogic(float playerHP)
    {
        //--0-------45----------65----------100-|
        //  Attack   |   Fuzzy   |    Run Away

        if (playerHP >= attackMin && playerHP <= runAwayMin) //Estado de ataque
        {
            Debug.Log("Inimigo: Estado de ataque - Atacando!!!");
            Attack();
        }
        else if (playerHP >= attackMax && playerHP <= runAwayMax) //Estado de fuga
        {
            Debug.Log("Inimigo: Estado de fuga - Fugindo!!!");
            RunAway();
        }
        else //Estado fuzzy
        {
            //Sorteia um valor entre 0 e 1 para decidir se vai atacar ou fugir
            float randomValue = UnityEngine.Random.Range(0f, 1f);
            if (randomValue >= 0.5f)
            {
                Debug.Log("Inimigo: Estado fuzzy - Atacando!!!");
                Attack();
            }
            else
            {
                Debug.Log("Inimigo: Estado fuzzy - Fugindo!!!");
                RunAway();
            }
        }
    }


    void Attack()
    {
        navMeshAgent.destination = player.transform.position;
    }

    void RunAway()
    {
        //Fugir do player
        Vector3 dirAway = (transformEnemy.position - player.transform.position).normalized * minMagnitude;
        if ((transformEnemy.position - player.transform.position).magnitude < minMagnitude / 2)
        {
            //Rotacionar o vetor quando o inimigo estiver muito perto do player
            dirAway = Quaternion.Euler(0, 15, 0) * dirAway;
        }
        navMeshAgent.destination = transformEnemy.position + dirAway;
    }

        


    void Damage(GameObject other, bool isDestroy = false)
    {   
        if (isDestroy)
        {
            Destroy(other);
        }

        Debug.Log("Toma otário!!!");
        life--;
        if(life <= 0)
        {
            DeathGhost();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DeathGhost();
        }

        if(other.CompareTag("Weapon"))
        {
            Damage(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            Damage(gameObject);
        }
    }

    void DeathGhost()
    {
        playerController.LevelUp(20);
        explodionSound.Play();
        Destroy(gameObject);
    }

}
