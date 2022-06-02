using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Transform enemyTransform;
    private NavMeshAgent moves;
    public float damage, life;
    void Start()
    {
        moves = GetComponent<NavMeshAgent>();
        enemyTransform = GameObject.Find("PLAYER 2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //moves = GetComponent<NavMeshAgent>();
        moves.destination = enemyTransform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject);
        }
    }
}
