using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Transform enemyTransform;
    public Transform soldierTransform, bazookaTransform, tankTransform, shipTransform, planeTransform;
    private NavMeshAgent moves;
    public float damage, life;
    private bool attacking;
    private Animator anim;

    void Start()
    {
        moves = GetComponent<NavMeshAgent>();
        
        enemyTransform = GameObject.Find("PLAYER 2").transform;
        /*
        soldierTransform = GameObject.Find("Soldier2").transform;
        bazookaTransform = GameObject.Find("Bazooka2").transform;
        tankTransform = GameObject.Find("Tank2").transform;
        shipTransform = GameObject.Find("Ship2").transform;
        planeTransform = GameObject.Find("Plane2").transform;
        */

        
        bazookaTransform = GameObject.FindWithTag("Bazooka2").transform;
        tankTransform = GameObject.FindWithTag("Tank2").transform;
        shipTransform = GameObject.FindWithTag("Ship2").transform;
        planeTransform = GameObject.FindWithTag("Plane2").transform;



    }
        // Update is called once per frame
        void Update()
        {

            moves.destination = enemyTransform.position;
        //Fight();
        

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
        if (other.gameObject.CompareTag("Soldier2"))
        {
            soldierTransform = GameObject.FindWithTag("Soldier2").transform;
            Fight();
        } else 
        { 
            moves.destination = enemyTransform.position;
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
        }

        if (other.gameObject.CompareTag("Bazooka2"))
        {
            bazookaTransform = GameObject.FindWithTag("Bazooka2").transform;
            Fight();
        }
        else
        {
            moves.destination = enemyTransform.position;
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
        }

        if (other.gameObject.CompareTag("Tank2"))
        {
            tankTransform = GameObject.FindWithTag("Tank2").transform;
            Fight();
        }
        else
        {
            moves.destination = enemyTransform.position;
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
        }

        if (other.gameObject.CompareTag("Ship2"))
        {
            shipTransform = GameObject.FindWithTag("Ship2").transform;
            Fight();
        }
        else
        {
            moves.destination = enemyTransform.position;
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
        }

        if (other.gameObject.CompareTag("Plane2"))
        {
            soldierTransform = GameObject.FindWithTag("Plane2").transform;
            Fight();
        }
        else
        {
            moves.destination = enemyTransform.position;
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
        }
    }


    void Fight()
    {
        
        if (Vector3.Distance(transform.position, soldierTransform.position) <= moves.stoppingDistance + 5)
        {
            print("aaaaaaa");
            this.GetComponent<NavMeshAgent>().speed = 0f;
           // anim.SetBool("ataque", true);
            
        }
        
        if (Vector3.Distance(transform.position, bazookaTransform.position) <= moves.stoppingDistance + 5)
        {
            print("aaaaaaa");
            this.GetComponent<NavMeshAgent>().speed = 0f;
            
            anim.SetBool("ataque", true);
        }
       

        if (Vector3.Distance(transform.position, tankTransform.position) <= moves.stoppingDistance + 5)
        {
            print("aaaaaaa");
            this.GetComponent<NavMeshAgent>().speed = 0f;
            anim.SetBool("ataque", true);
        }
        

        if (Vector3.Distance(transform.position, shipTransform.position) <= moves.stoppingDistance + 5)
        {
            print("aaaaaaa");
            this.GetComponent<NavMeshAgent>().speed = 0f;
            anim.SetBool("ataque", true);

        }
        

        if (Vector3.Distance(transform.position, planeTransform.position) <= moves.stoppingDistance + 5)
        {
            print("aaaaaaa");
            this.GetComponent<NavMeshAgent>().speed = 0f;
            anim.SetBool("ataque", true);

        }
        
    }
    
    void ExitFight()
    {
        if (Vector3.Distance(transform.position, soldierTransform.position) >= moves.stoppingDistance )
        { 
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
            anim.SetBool("walk", true);
        }

        if (Vector3.Distance(transform.position, bazookaTransform.position) >= moves.stoppingDistance )
        {
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
            anim.SetBool("walk", true);
        }

        if (Vector3.Distance(transform.position, tankTransform.position) >= moves.stoppingDistance )
        {
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
            anim.SetBool("walk", true);
        }

        if (Vector3.Distance(transform.position, shipTransform.position) >= moves.stoppingDistance )
        {
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
            anim.SetBool("walk", true);
        }

        if (Vector3.Distance(transform.position, planeTransform.position) >= moves.stoppingDistance )
        {
            this.GetComponent<NavMeshAgent>().speed = 1.5f;
            anim.SetBool("walk", true);
        }
    }
}
