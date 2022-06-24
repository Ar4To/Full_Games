using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAStopDistance : MonoBehaviour
{
    public AI scriptAI;
    public GameObject AI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //print(scriptAI.moves.destination);
        //print(scriptAI.soldierTransform.position);


    }

    private void OnTriggerEnter(Collider other)
    {
        print("Collision");
        if (other.gameObject.CompareTag("Soldier2"))
        {
            //soldierTransform = GameObject.FindWithTag("Soldier2").transform;
            //scriptAI.soldierTransform = other.gameObject.GetComponent<Transform>();
            //moves.SetDestination(soldierTransform.position);
            //scriptAI.moves.SetDestination(scriptAI.soldierTransform.position);
            print(scriptAI.moves.destination);


        }
    }

    
}
