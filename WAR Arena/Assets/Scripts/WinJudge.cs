using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinJudge : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;
    public GameObject winCanvas;
    public Text player2Nick;
    
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
            winnerTxt.text = "Red Team Wins";
            winCanvas.SetActive(true);
        }

        if (player2.life <= 0)
        {
            winnerTxt.text = "Blue Team Wins";
            winCanvas.SetActive(true);
        }
    }
}
