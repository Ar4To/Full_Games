using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinJudge : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;
    public GameObject winCanvas;
    private LobbyManager lM;
    public Text winnerTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(player1.life <= 0)
        {
            winnerTxt.text = "Player 2 Wins";
            winCanvas.SetActive(true);
        }

        if (player2.life <= 0)
        {
            winnerTxt.text = "Player 1 Wins";
            winCanvas.SetActive(true);
        }
    }
}
