using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using Photon.Pun;

public class AI : MonoBehaviourPunCallbacks
{
    
    public Transform enemyTransform;
    private AI2 enemyAI2;
    private AI allyAI;
    private PlayerController Pcontroller;
    public NavMeshAgent moves;
    public float damage, life, speedFloat;
    [SerializeField]
    private float timeDamage= 2;
   
    private Animator anim;
    
    [SerializeField]
    private GameObject actualEnemy;

    void Start()
    {
        moves = GetComponent<NavMeshAgent>();
        
        
        
        anim = GetComponent<Animator>();
       
    }
    // Update is called once per frame
    void Update()
    {
        enemyTransform = GameObject.Find("PLAYER 2").transform;

        speedFloat -= Time.deltaTime;
        timeDamage -= Time.deltaTime;
        moves.destination = enemyTransform.position;

        if (life <= 0)
        {
            Pcontroller.money += 15;
            Destroy(gameObject);
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
        if (other.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject, 0.1f);
            
        }
        
        if (other.gameObject.CompareTag("Soldier2"))
        {
            if (!actualEnemy)
            {
                actualEnemy = other.gameObject;
            }


            if (other.gameObject.CompareTag("Soldier2"))
            {
                anim.SetBool("StopEnemy", true);
            }
       
        }
        
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Soldier2"))
        {
            if (!actualEnemy)
            {
                actualEnemy = other.gameObject;
            }

            enemyAI2 = other.gameObject.GetComponent<AI2>();
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            anim.SetTrigger("atirar");

            if (timeDamage <= 0)
            {
                life = life - enemyAI2.damage;
                timeDamage = 2;
            }


           /* if (other.gameObject.CompareTag("Soldier2"))
            {
                anim.SetBool("StopEnemy", true);
            }
           */
        }
       /* else
            anim.SetBool("StopEnemy", false);*/

        
    }
        



   

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soldier2"))
        {
            anim.SetBool("StopEnemy", false);
        }
        Debug.Log("triggerexit");
    }






}

