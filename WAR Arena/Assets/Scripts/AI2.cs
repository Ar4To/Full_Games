using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using Photon.Pun;

public class AI2 : MonoBehaviourPunCallbacks
{

    public Transform enemyTransform;
    private AI enemyAI;
    private AI2 allyAI;
    public NavMeshAgent moves;
    public PlayerController Pcontroller;
    public GameObject Player;
    public float damage, life, speedFloat;
    [SerializeField]
    private float timeDamage = 2;
    private Animator anim;
    
    public GameObject actualEnemy;

    void Start()
    {

        Player = GameObject.Find("PLAYER 1");
        moves = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Pcontroller = Player.GetComponent<PlayerController>();

    }
    // Update is called once per frame
    void Update()
    {
        enemyTransform = GameObject.Find("PLAYER 1").transform;

        speedFloat -= Time.deltaTime;
        timeDamage -= Time.deltaTime;
        moves.destination = enemyTransform.position;

        if (life <= 0)
        {
            Pcontroller.money += 15;
            PhotonNetwork.Destroy(gameObject);
        }

        if (speedFloat <= 0)
        {
            if (anim.GetBool("StopEnemy"))
            {
                anim.SetBool("StopEnemy", false);
                GetComponent<NavMeshAgent>().speed = 0.8f;
                speedFloat = 2;
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Pcontroller.life -= damage;
            Destroy(gameObject, 0.1f);

        }

        if (other.gameObject.CompareTag("Soldier"))
        {
            if (!actualEnemy)
            {
                actualEnemy = other.gameObject;
            }


            if (other.gameObject.CompareTag("Soldier "))
            {
                anim.SetBool("StopEnemy", true);
            }

        }

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Soldier"))
        {
            if (!actualEnemy)
            {
                actualEnemy = other.gameObject;
            }

            enemyAI = other.gameObject.GetComponent<AI>();
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            anim.SetTrigger("atirar");

            if (timeDamage <= 0)
            {
                life = life - enemyAI.damage;
                timeDamage = 2;
            }

           
        }
        
        
    }
       private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soldier"))
        {
            anim.SetBool("StopEnemy", false);
        }
        Debug.Log("triggerexit");
    }





}

