using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviourPunCallbacks
{

    public int money = 100; //dinheiro
    [SerializeField]
    private float moneyTime = 5, buyTime = 0.8f; //tempo de receber dinheiro
    public Text moneyTxt; //texto do dinheiro
    public float life = 100f, lifeMax = 100f; //vida
    public Image lifeBAR; //vida maxima
    public GameObject[] soldiers; //prefab dos soldados
    public PhotonView pV;
    public int team;
    public GameObject player;
    private LobbyManager lM;
    public GameObject _playerCanvas;
    public Text player1Nick, player2Nick;
    public PlayerController playerScript;


    [SerializeField]
    private Transform spawner; //posição do spawner
    
    // Start is called before the first frame update
    void Start()
    {
        player1Nick.text = pV.Owner.NickName;
        player2Nick.text = PhotonNetwork.NickName;  


        money = 100;
        pV = GetComponent<PhotonView>();
        
        if (gameObject.CompareTag("Player2"))
        {
            spawner = GameObject.Find("Spawner2").transform;
        } else if(gameObject.CompareTag("Player"))

         spawner = GameObject.Find("Spawner1").transform;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        Vida();
        #region Sistema de dinheiro
        moneyTime -= Time.deltaTime;
        if (moneyTime <= 0)
        {
            money += 12;
            moneyTime = 3;
        }
        moneyTxt.text = money.ToString();
        #endregion

        buyTime -= Time.deltaTime;

       
        

        if (pV.IsMine)
        {

            if (team == 1)
            {
                _playerCanvas.SetActive(true);
                playerScript._playerCanvas.SetActive(false);
                
            }
        }
        if (!pV.IsMine)
        {
            if (team == 2)
            {
                _playerCanvas.SetActive(true);
                playerScript._playerCanvas.SetActive(false);
                player2Nick.text = PhotonNetwork.NickName;
                

            }

            if (team == 1)
            {
                player2Nick.text = playerScript.player2Nick.text;
            }


                //DontDestroyOnLoad(this.gameObject);
        }

    }

    
    private void Vida()
    {
        lifeBAR.fillAmount = life / lifeMax;
        
    }
   
    [PunRPC]
     public void  Soldier()
    {
        if (money >= 30)
        {
            if (buyTime <= 0)
            {
                money -= 30;
                
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
               
                GameObject tank = PhotonNetwork.Instantiate(soldiers[2].name, soldiers[2].transform.position, Quaternion.identity);
                tank.transform.position = spawner.position;
                buyTime = 1.3f;
                photonView.RPC("Tank", RpcTarget.AllViaServer, tank);
            }
        }
    }
    
    
    
}

