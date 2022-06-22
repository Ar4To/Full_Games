using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    
    private Transform enemyTransform;
    public Transform soldierTransform, bazookaTransform, tankTransform, shipTransform, planeTransform;
    public Transform allySoldier, allyBazooka, allyTank, allyShip, allyPlane;
    public NavMeshAgent moves;
    public float damage, life;
    private bool attacking;
    private Animator anim;

    void Start()
    {
        moves = GetComponent<NavMeshAgent>();

        enemyTransform = GameObject.Find("PLAYER 2").transform;

        
    }
    // Update is called once per frame
    void Update()
    {


        moves.destination = enemyTransform.position;


        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject, 0.1f);
<<<<<<< HEAD
            
=======
>>>>>>> parent of 966d28d6 (20/06/modelagem de um cara)
        }
    }





    private void OnTriggerStay(Collider other)
    {
        #region interação tropas inimigas
        if (other.gameObject.CompareTag("Soldier2"))
        {
<<<<<<< HEAD
            Debug.Log("stopiing");
            anim.SetBool("StopEnemy", true);
            anim.SetBool("atirar",true);
=======
>>>>>>> parent of 966d28d6 (20/06/modelagem de um cara)
            
            soldierTransform = other.gameObject.GetComponent<Transform>();
           
            moves.SetDestination(transform.position);


<<<<<<< HEAD
        }
        else
        {
            anim.SetBool("StopEnemy", false);
            anim.SetBool("atirar", false);
            Debug.Log("run");
        }
        
=======
        } 
>>>>>>> parent of 966d28d6 (20/06/modelagem de um cara)
        #endregion[
    }



    
    void Ally()
    {
        if (Vector3.Distance(transform.position, soldierTransform.position) <= moves.stoppingDistance + 5)
        {
            this.GetComponent<NavMeshAgent>().speed = 0.2f;
            
        }

        if (Vector3.Distance(transform.position, bazookaTransform.position) <= moves.stoppingDistance + 5)
        {
            this.GetComponent<NavMeshAgent>().speed = 0.2f;

        }

        if (Vector3.Distance(transform.position, tankTransform.position) <= moves.stoppingDistance + 5)
        {
            this.GetComponent<NavMeshAgent>().speed = 0.2f;

        }

        if (Vector3.Distance(transform.position, shipTransform.position) <= moves.stoppingDistance + 5)
        {
            this.GetComponent<NavMeshAgent>().speed = 0.2f;

        }

        if (Vector3.Distance(transform.position, planeTransform.position) <= moves.stoppingDistance + 5)
        {
            this.GetComponent<NavMeshAgent>().speed = 0.2f;

        }
    }

}

