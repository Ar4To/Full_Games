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
        #region interação tropas inimigas
        if (other.gameObject.CompareTag("Soldier"))
        {
            enemyAI = other.GetComponent<AI>();
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);

            anim.SetBool("atirar", true);
            attacking = true;
            if (timeDamage <= 0)
            {
                life = life - enemyAI.damage;
                timeDamage = 1;
            }


            //soldierTransform = other.gameObject.GetComponent<Transform>();

            //moves.SetDestination(transform.position);

        }
        else
        {
            anim.SetBool("StopEnemy", false);
            anim.SetBool("atirar", false);
            attacking = false;
            Debug.Log("run");
        }
        /*
                if (other.gameObject.CompareTag("Bazooka2"))
                {
                    Debug.Log(other.gameObject);
                    anim.SetBool("StopEnemy", true);
                    anim.SetBool("atirar", true);


                    //soldierTransform = other.gameObject.GetComponent<Transform>();

                    //moves.SetDestination(transform.position);



                }
                else
                {
                    anim.SetBool("StopEnemy", false);
                    anim.SetBool("atirar", false);
                    Debug.Log("run");
                }

                if (other.gameObject.CompareTag("Tank2"))
                {
                    Debug.Log(other.gameObject);
                    anim.SetBool("StopEnemy", true);
                    anim.SetBool("atirar", true);


                    //soldierTransform = other.gameObject.GetComponent<Transform>();

                    //moves.SetDestination(transform.position);



                }
                else
                {
                    anim.SetBool("StopEnemy", false);
                    anim.SetBool("atirar", false);
                    Debug.Log("run");
                }

                if (other.gameObject.CompareTag("Ship2"))
                {
                    Debug.Log(other.gameObject);
                    anim.SetBool("StopEnemy", true);
                    anim.SetBool("atirar", true);


                    //soldierTransform = other.gameObject.GetComponent<Transform>();

                    //moves.SetDestination(transform.position);



                }
                else
                {
                    anim.SetBool("StopEnemy", false);
                    anim.SetBool("atirar", false);
                    Debug.Log("run");
                }

                if (other.gameObject.CompareTag("Plane2"))
                {
                    Debug.Log(other.gameObject);
                    anim.SetBool("StopEnemy", true);
                    anim.SetBool("atirar", true);


                   // soldierTransform = other.gameObject.GetComponent<Transform>();

                    //moves.SetDestination(transform.position);



                }
                else
                {
                    anim.SetBool("StopEnemy", false);
                    anim.SetBool("atirar", false);
                    Debug.Log("run");
                }
        */
        #endregion[

        #region interação tropas aliadas

        if (other.gameObject.CompareTag("Soldier2"))
        {
            allyAI = other.gameObject.GetComponent<AI2>();
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            //anim.SetBool("atirar", true);


            //soldierTransform = other.gameObject.GetComponent<Transform>();

            //moves.SetDestination(transform.position);



        }
        else if (allyAI.attacking == false)
        {
            anim.SetBool("StopEnemy", false);
            anim.SetBool("atirar", false);
            Debug.Log("run");
        }
        /*
        if (other.gameObject.CompareTag("Bazooka"))
        {
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            //anim.SetBool("atirar", true);


            //soldierTransform = other.gameObject.GetComponent<Transform>();

            //moves.SetDestination(transform.position);



        }
        else
        {
            anim.SetBool("StopEnemy", false);
            anim.SetBool("atirar", false);
            Debug.Log("run");
        }

        if (other.gameObject.CompareTag("Tank"))
        {
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            //anim.SetBool("atirar", true);


           // soldierTransform = other.gameObject.GetComponent<Transform>();

            //moves.SetDestination(transform.position);



        }
        else
        {
            anim.SetBool("StopEnemy", false);
            anim.SetBool("atirar", false);
            Debug.Log("run");
        }

        if (other.gameObject.CompareTag("Ship"))
        {
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            //anim.SetBool("atirar", true);


            //soldierTransform = other.gameObject.GetComponent<Transform>();

            //moves.SetDestination(transform.position);



        }
        else
        {
            anim.SetBool("StopEnemy", false);
            anim.SetBool("atirar", false);
            Debug.Log("run");
        }

        if (other.gameObject.CompareTag("Plane"))
        {
            Debug.Log(other.gameObject);
            anim.SetBool("StopEnemy", true);
            //anim.SetBool("atirar", true);


            //soldierTransform = other.gameObject.GetComponent<Transform>();

            //moves.SetDestination(transform.position);



        }
        else
        {
            anim.SetBool("StopEnemy", false);
            anim.SetBool("atirar", false);
            Debug.Log("run");
        }

        */

        #endregion
    }









}

