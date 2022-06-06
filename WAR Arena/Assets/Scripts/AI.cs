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
        soldierTransform = GameObject.Find("Soldier2").transform;
        bazookaTransform = GameObject.Find("Bazooka2").transform;
        tankTransform = GameObject.Find("Tank2").transform;
        shipTransform = GameObject.Find("Ship2").transform;
        planeTransform = GameObject.Find("Plane2").transform;

    }
        // Update is called once per frame
        void Update()
        {

            moves.destination = enemyTransform.position;
            Fight();
       
    }

         private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player2"))
            {
                Destroy(gameObject, 0.1f);
            }
        }

    void Fight()
    {
        if (Vector3.Distance(transform.position, soldierTransform.position) <= moves.stoppingDistance + 2)
        {
            print("aaaaaaa");
            moves.speed = 0;
            moves.angularSpeed = 0;
            anim.SetBool("ataque", true);
        } else
        {
            moves.speed = 1.5f;
            moves.angularSpeed = 0;
        }

        if (Vector3.Distance(transform.position, bazookaTransform.position) <= moves.stoppingDistance + 2)
        {
            print("aaaaaaa");
            moves.speed = 0;
            moves.angularSpeed = 0;
            anim.SetBool("ataque", true);
        }
        else
        {
            moves.speed = 1.5f;
            moves.angularSpeed = 0;
        }

        if (Vector3.Distance(transform.position, tankTransform.position) <= moves.stoppingDistance + 2)
        {
            print("aaaaaaa");
            moves.speed = 0;
            moves.angularSpeed = 0;
            anim.SetBool("ataque", true);
        }
        else
        {
            moves.speed = 1.5f;
            moves.angularSpeed = 0;
        }

        if (Vector3.Distance(transform.position, shipTransform.position) <= moves.stoppingDistance + 2)
        {
            print("aaaaaaa");
            moves.speed = 0;
            moves.angularSpeed = 0;
            anim.SetBool("ataque", true);

        }
        else
        {
            moves.speed = 1.5f;
            moves.angularSpeed = 0;
        }

        if (Vector3.Distance(transform.position, planeTransform.position) <= moves.stoppingDistance + 2)
        {
            print("aaaaaaa");
            moves.speed = 0;
            moves.angularSpeed = 0;
            anim.SetBool("ataque", true);

        }
        else
        {
            moves.speed = 1.5f;
            moves.angularSpeed = 0;
        }
    }
    
}
