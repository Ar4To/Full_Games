using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    
     public Transform enemyTransform;
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
        anim = GetComponent<Animator>();
        
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
            Debug.Log("gozei");
        }
      
    }





    private void OnTriggerEnter(Collider other)
    {
        #region interação tropas inimigas
        if (other.gameObject.CompareTag("Soldier2"))
        {

            anim.SetBool("StopEnemy", true);
            anim.SetTrigger("atirar");
            
            soldierTransform = other.gameObject.GetComponent<Transform>();

            //moves.SetDestination(transform.position);
            

        }
        
        #endregion[
    }



    
    void Ally()
    {
        if (Vector3.Distance(transform.position, soldierTransform.position) <= moves.stoppingDistance + 5)
        {
            this.GetComponent<NavMeshAgent>().speed = 0.2f;
            
        }

       
    }
    

}

