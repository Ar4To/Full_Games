using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviourPunCallbacks
{
    public byte maxPlayersRoom = 4; // numero de jgadores maximos
    [HideInInspector]
    public string _appVersion = "0.1"; // versão do jogo
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartConnection(string _nickName)
    {
        // Antes de conectar com servidores

        PhotonNetwork.GameVersion = _appVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = _nickName;
        //_uiController.ShowLog("Conectando...");
    }

    public void CreateRoom(string _roomName, bool _create = true)
    {
        // Criar uma sala

        RoomOptions _ro = new RoomOptions();
        _ro.MaxPlayers = maxPlayersRoom;
        PhotonNetwork.JoinOrCreateRoom(_roomName, _ro, TypedLobby.Default);
        //_uiController.ShowLobbyPanel(false);

        #region criando sala
        if (_create)
        {
            //_uiController.ShowMessage("Creating...");
        }
        else
        {
            //_uiController.ShowMessage("Joining...");
        }
        #endregion
    }

    public void BtnExitGame()
    {
        // Sair do jogo e desconectar do servidor

        PhotonNetwork.Disconnect();
        Application.Quit();
    }

    public override void OnConnectedToMaster()
    {
        // Conectar a um servidor

        //_uiController.ShowServerData(string.Format("Connected: " + PhotonNetwork.CloudRegion + " | App Version: " + _appVersion + " | Max players in Room: " + _maxPlayersRoom));
        //_uiController.ShowLog("Conected");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        // Entrou no lobby

        //_uiController.ShowLobbyPanel();
        //_uiController.ShowLog("joined Loddy");
    }

    public override void OnJoinedRoom()
    {
        // Entrou na sala
        base.OnJoinedRoom();
        {
            //_uiController.ShowMessage("Entrando...");
            PhotonNetwork.LoadLevel("ARENA");
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> _rl)
    {
        // Atualiza o numero de jogadores na sala

        //_uiController.UpdateRoomList(_rl);
    }

    public override void OnDisconnected(DisconnectCause _cause)
    {
        // Desconectar da sala

        //_uiController.ShowLobbyPanel(false);
        //_uiController.ShowLog(_cause.ToString());
    }

    public override void OnCreateRoomFailed(short _returnCode, string _message)
    {
        // Falhou na criação da sala

        //_uiController.ShowLobbyPanel(false);
        //_uiController.ShowLog(_message);
        //_uiController.ShowLog(_returnCode.ToString());
    }
}
