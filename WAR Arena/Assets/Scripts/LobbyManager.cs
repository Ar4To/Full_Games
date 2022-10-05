using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LobbyManager : MonoBehaviourPunCallbacks
{

    public int team;
    // Start is called before the first frame update
    [SerializeField]
    GameObject findMatchBtn, lobbyMatch;
    public GameObject _myPlayer1;
    public GameObject _myPlayer2;
    public GameObject prePlayer1;
    public GameObject prePlayer2;
    //public InputField _intPlayerName;
    public TMP_InputField _intPlayerName;
    public string _strPlayerName;
    void Start()
    {
        findMatchBtn.SetActive(false);
        //lobbyMatch.SetActive(false);

        //_strPlayerName = "Player" + Random.Range(100, 999);

        //PhotonNetwork.ConnectUsingSettings();

        _intPlayerName.text = _strPlayerName;

        prePlayer1.SetActive(false);
        prePlayer2.SetActive(false);
    }
     
    public override void OnConnectedToMaster()
    {
        print("Connected");
        
        lobbyMatch.SetActive(false);
        findMatchBtn.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.AutomaticallySyncScene = true;


    }
    public void FindMatch()
    {
        if (_intPlayerName.text != "")
        {
            PhotonNetwork.NickName = _intPlayerName.text;
        }
        else
        {
            PhotonNetwork.NickName = _strPlayerName;
        }

        findMatchBtn.SetActive(true);
        lobbyMatch.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        
        print("Procurando por server");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        MakeRoom();
    }

    public void StopSearch()
    {
        findMatchBtn.SetActive(false);
        lobbyMatch.SetActive(true);

        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        print("Conexão cancelada");
    }


   
    void MakeRoom()
    {
        int randomRoomName = Random.Range(0, 5000);
        RoomOptions roomOptions =
        new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2            
        };


        PhotonNetwork.CreateRoom("RoomName_" + randomRoomName, roomOptions);
        print("Sala criada");
        team = 1;
        
        /*if (PhotonNetwork.CurrentRoom.PlayerCount < 2 && PhotonNetwork.IsMasterClient)
        {
            print(PhotonNetwork.CurrentRoom.PlayerCount + "/2 Starting Game"); 
            team = 1;
            PhotonNetwork.LoadLevel(1);

        }*/

        
    }
    
   public override void OnPlayerEnteredRoom(Player newplayer)
    {
        

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient)
        {

            print(PhotonNetwork.CurrentRoom.PlayerCount + "/2 Starting Game");
            DontDestroyOnLoad(this.gameObject);

            team = 2;
            PhotonNetwork.LoadLevel(1);
            
            /*
                PhotonNetwork.Instantiate(_myPlayer2.name, _myPlayer2.transform.position, _myPlayer2.transform.rotation, 0);
                print(_myPlayer2);
                PhotonNetwork.Instantiate(_myPlayer1.name, _myPlayer1.transform.position, _myPlayer1.transform.rotation, 0);
                print(_myPlayer1);
            */
                prePlayer1.SetActive(true);
                prePlayer2.SetActive(true);
            
        }
        
    }

}

