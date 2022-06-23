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
            
        }
      
    }





    private void OnTriggerEnter(Collider other)
    {
        #region interação tropas inimigas
        if (other.gameObject.CompareTag("Soldier2"))
        {
            Debug.Log("stopiing");
            anim.SetBool("StopEnemy", true);
            anim.SetBool("atirar",true);
            
            soldierTransform = other.gameObject.GetComponent<Transform>();

            //moves.SetDestination(transform.position);
            

        }
        else
        {
            anim.SetBool("StopEnemy", false);
            anim.SetBool("atirar", false);
            Debug.Log("run");
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

