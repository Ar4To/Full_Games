using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class PlayerController : MonoBehaviourPunCallbacks
{
    
    public int money = 100; //dinheiro
    [SerializeField]
    private float moneyTime = 5, buyTime = 0.8f; //tempo de receber dinheiro
    public Text moneyTxt; //texto do dinheiro
    public float life = 100f; //vida
    public Image lifeMAX; //vida maxima
    public GameObject [] soldiers; //prefab dos soldados
    public PhotonView pV;
    private int team;
    public GameObject player;
    private LobbyManager lM;
    private GameObject _player1Canvas;
    private GameObject _player2Canvas;

    [SerializeField]
    private Transform spawner; //posição do spawner
    
    // Start is called before the first frame update
    void Start()
    {
        money = 100;
        pV = GetComponent<PhotonView>();
    
        _player1Canvas = GameObject.Find("Canvas1");
        _player2Canvas = GameObject.Find("Canvas2");

        _player1Canvas.SetActive(true);
        _player2Canvas.SetActive(true);
        
        

        if (pV.IsMine)
        {
            team = lM.team;
            if(pV.ViewID == 1)
            {
                _player1Canvas.SetActive(true);
                _player2Canvas.SetActive(false);
            } else if(pV.ViewID == 2)
            {
                _player2Canvas.SetActive(true);
                _player1Canvas.SetActive(false);

            }
            Soldier();
            Bazooka();
            Tank();

            DontDestroyOnLoad(this.gameObject);
        } 

        

         
       if (gameObject.CompareTag("Player2"))
        {
            spawner = GameObject.Find("Spawner2").transform;
        } else if(gameObject.CompareTag("Player"))

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
   /* public void Soldier()
    {
        if (money >= 30)
        {
            if (buyTime <= 0)
            {
                money -= 30;
                GameObject soldier = Instantiate(soldiers[0]) as GameObject;
                soldier.transform.position = spawner.position;
                buyTime = 1.2f;
               
            }
        }

    }*/
/*
    public void Bazooka()
    {
        if (money >= 80)
        { 
            if (buyTime <= 0)
            {
                money -= 80;
                GameObject bazooka = Instantiate(soldiers[1]) as GameObject;
                bazooka.transform.position = spawner.position;
                buyTime = 1.2f;
            }
        }
    }
*/
    /*public void Tank()
    {
        if (money >= 160)
        {
            
            if (buyTime <= 0)
            {
                money -= 160;
                GameObject tank = Instantiate(soldiers[2]) as GameObject;
                tank.transform.position = spawner.position;
                buyTime = 1.3f;
            }
        }
    }
    */
    public void Ship()
    {
        if (money >= 320)
        { 
            if (buyTime <= 0)
            {
                money -= 320;
                GameObject tank = Instantiate(soldiers[3]) as GameObject;
                tank.transform.position = spawner.position;
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

    #region colisão
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (gameObject.CompareTag("Player2"))
        {
            if (collision.gameObject.CompareTag("Soldier"))
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

        if (gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Soldier2"))
            {
                life -= 5;
            }

            if (collision.gameObject.CompareTag("Bazooka2"))
            {
                life -= 10;
            }

            if (collision.gameObject.CompareTag("Tank2"))
            {
                life -= 27;
            }

            if (collision.gameObject.CompareTag("Ship2"))
            {
                life -= 38;
            }

            if (collision.gameObject.CompareTag("Plane2"))
            {
                life -= 50;
            }
        
        }
        */
    }
    #endregion

    [PunRPC]
     public void  Soldier()
    {
        if (money >= 30)
        {
            if (buyTime <= 0)
            {
                money -= 30;
                // GameObject soldier = PhotonNetwork.Instantiate(soldiers[0]), spawner.position;
                GameObject soldier = PhotonNetwork.Instantiate(soldiers[0].name, soldiers[0].transform.position, Quaternion.identity);
                soldier.transform.position = spawner.position;

                buyTime = 1.2f;
                photonView.RPC("Soldier", RpcTarget.AllViaServer, soldier);
            }
        }

    }
    [PunRPC]
    public void Bazooka()
    {
        if (money >= 80)
        {
            if (buyTime <= 0)
            {
                money -= 80;
                //GameObject bazooka = PhotonNetwork.Instantiate(soldiers[UnityEngine.Random.Range(0, BlockingInstances.Length)], transform.position, Quaternion.identity);
                //GameObject bazooka = Instantiate(soldiers[1]) as GameObject;
                GameObject bazooka = PhotonNetwork.Instantiate(soldiers[1].name, soldiers[1].transform.position, Quaternion.identity);
                bazooka.transform.position = spawner.position;
                buyTime = 1.2f;
                photonView.RPC("Bazooka", RpcTarget.AllViaServer, bazooka);

            }
        }
    }
    [PunRPC]
    public void Tank()
    {
        if (money >= 160)
        {

            if (buyTime <= 0)
            {
                money -= 160;
                //GameObject tank = Instantiate(soldiers[2]) as GameObject;
                GameObject tank = PhotonNetwork.Instantiate(soldiers[2].name, soldiers[2].transform.position, Quaternion.identity);
                tank.transform.position = spawner.position;
                buyTime = 1.3f;
                photonView.RPC("Tank", RpcTarget.AllViaServer, tank);
            }
        }
    }
}

