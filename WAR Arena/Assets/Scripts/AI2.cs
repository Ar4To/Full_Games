using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class AI2 : MonoBehaviour
{

    public Transform enemyTransform;
    private AI enemyAI;
    private AI2 allyAI;
    public NavMeshAgent moves;
    public float damage, life;
    [SerializeField]
    private float timeDamage;
    private Animator anim;
    private GameObject actualEnemy;

    void Start()
    {
        moves = GetComponent<NavMeshAgent>();

        enemyTransform = GameObject.Find("PLAYER 1").transform;
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {

        timeDamage -= Time.deltaTime;
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

            enemyAI = other.gameObject.GetComponent<AI>();
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            anim.SetTrigger("atirar");

            if (timeDamage <= 0)
            {
                life = life - enemyAI.damage;
                timeDamage = 1;
            }


            if (other.gameObject.CompareTag("Soldier2"))
            {
                anim.SetBool("StopEnemy", true);
            }

        }
    }





    private void OnTriggerStay(Collider other)
    {

        #region intera��o tropas inimigas
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

        #region intera��o tropas aliadas

        if (other.gameObject.CompareTag("Soldier2"))
        {


            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);


        }


        #endregion



    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Soldier"))
        {
            anim.SetBool("StopEnemy", false);
        }
        Debug.Log("triggerexit");

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Soldier"))
        {
            anim.SetBool("StopEnemy", true);
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

