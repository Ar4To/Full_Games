using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int money = 100; //dinheiro
    [SerializeField]
    private float moneyTime = 5, buyTime = 0.8f; //tempo de receber dinheiro
    public Text moneyTxt; //texto do dinheiro
    public float life = 100f; //vida
    public Image lifeMAX; //vida maxima
    public GameObject [] soldiers; //prefab dos soldados
    private Transform spawner; //posição do spawner

    // Start is called before the first frame update
    void Start()
    {
       spawner = GameObject.Find("Spawner1").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Sistema de dinheiro
        moneyTime -= Time.deltaTime;
        if (moneyTime <= 0)
        {
            money += 5;
            moneyTime = 5;
        }
        moneyTxt.text = money.ToString();
        #endregion

        buyTime -= Time.deltaTime;
        

    }

    #region Tropas
    public void Soldier()
    {
        if (money >= 30)
        {
            if (buyTime <= 0)
            {
                money -= 30;
                GameObject soldier = Instantiate(soldiers[0]) as GameObject;
                soldier.transform.position = spawner.position;
                buyTime = 0.8f;
               
            }
        }

    }

    public void Bazooka()
    {
        if (money >= 80)
        { 
            if (buyTime <= 0)
            {
                money -= 80;
                GameObject soldier = Instantiate(soldiers[1]) as GameObject;
                soldier.transform.position = spawner.position;
                buyTime = 0.8f;
            }
        }
    }

    public void Tank()
    {
        if (money >= 160)
        {
            
            if (buyTime <= 0)
            {
                money -= 160;
                GameObject soldier = Instantiate(soldiers[2]) as GameObject;
                soldier.transform.position = spawner.position;
                buyTime = 0.8f;
            }
        }
    }

    public void Ship()
    {
        if (money >= 320)
        { 
            if (buyTime <= 0)
            {
                money -= 320;
                GameObject soldier = Instantiate(soldiers[3]) as GameObject;
                soldier.transform.position = spawner.position;
                buyTime = 0.8f;
            }
        }
    }

    public void Plane()
    {
        if (money >= 740)
        {
            if (buyTime <= 0)
            {
                money -= 740;
                GameObject soldier = Instantiate(soldiers[4]) as GameObject;
                soldier.transform.position = spawner.position;
                buyTime = 0.8f;
            }
        }
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Soldier"))
        {
            life -= 5;
        }

        if (collision.gameObject.CompareTag("Bazooka"))
        {
            life -= 10;
        }

        if (collision.gameObject.CompareTag("Tank"))
        {
            life -= 27;
        }

        if (collision.gameObject.CompareTag("Ship"))
        {
            life -= 38;
        }

        if (collision.gameObject.CompareTag("Plane"))
        {
            life -= 50;
        }
    }

}

