using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    
    public Transform enemyTransform;
    private AI2 enemyAI;
    private AI allyAI;
    public NavMeshAgent moves;
    public float damage, life;
    [SerializeField]
    private float timeDamage;
    private Animator anim;
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

        timeDamage -= Time.deltaTime;
        moves.destination = enemyTransform.position;

        if (life <= 0)
            Destroy(gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject, 0.1f);
            
        }
      
    }





    private void OnTriggerStay(Collider other)
    {
        #region intera��o tropas inimigas
        if (other.gameObject.CompareTag("Soldier2"))
        {
            if (!actualEnemy)
            {
                actualEnemy = other.gameObject;
            }

            enemyAI = other.GetComponent<AI2>();
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
           
            anim.SetTrigger("atirar");
           
            if (timeDamage <= 0)
            {
                life = life - enemyAI.damage;
                timeDamage = 1;
            }
          
            
           
         
        }
      
        #endregion[

        #region intera��o tropas aliadas

        if (other.gameObject.CompareTag("Soldier"))
        {
            
            
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
          

        }
       

        #endregion


       
    }
    private void OnTriggerExit(Collider other)
    {
        

            anim.SetBool("StopEnemy", false);
           
            Debug.Log("run");
        
    }

    private void OnDestroy()
    {
        actualEnemy.GetComponentInParent<Animator>().SetBool("StopEnemy", false);
        

        Debug.Log("run");
    }






}

