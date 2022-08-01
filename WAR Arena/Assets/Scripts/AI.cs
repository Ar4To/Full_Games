using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    
    public Transform enemyTransform;
    private AI2 enemyAI2;
    private AI allyAI;
    public NavMeshAgent moves;
    public float damage, life;
    [SerializeField]
    private float timeDamage1;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject actualEnemy;

    void Start()
    {
        moves = GetComponent<NavMeshAgent>();
        
        enemyTransform = GameObject.Find("PLAYER 2").transform;
        anim = GetComponent<Animator>();
       
    }
    // Update is called once per frame
    void Update()
    {

        timeDamage1 -= Time.deltaTime;
        moves.destination = enemyTransform.position;

        if (life <= 0)
            Destroy(gameObject);
        
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

            enemyAI2 = other.gameObject.GetComponent<AI2>();
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            anim.SetTrigger("atirar");

            if (timeDamage1 <= 0)
            {
                life = life - enemyAI2.damage;
                timeDamage1 = 1;
            }


            if (other.gameObject.CompareTag("Soldier2"))
            {
                anim.SetBool("StopEnemy", true);
            }

        }
    }





    private void OnTriggerStay(Collider other)
    {
        
        #region interação tropas inimigas
        /*if (other.gameObject.CompareTag("Soldier2"))
        {
            if (!actualEnemy)
            {
                actualEnemy = other.gameObject;
            }

            enemyAI2 = other.GetComponent<AI2>();
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            anim.SetTrigger("atirar");
           
            if (timeDamage <= 0)
            {
                life = life - enemyAI2.damage;
                timeDamage = 1;
            }
          
            
           
         
        }
      */
        #endregion[

        #region interação tropas aliadas

        if (other.gameObject.CompareTag("Soldier"))
        {
            
            
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
          

        }
       

        #endregion

        
       
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Soldier2"))
        {
            anim.SetBool("StopEnemy", false);
        }
            Debug.Log("triggerexit");
        
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Soldier2"))
        {
            anim.SetBool("StopEnemy", true);
        }

         
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

