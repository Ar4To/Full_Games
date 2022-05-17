using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int money; //dinheiro
    private float moneyTime = 5; //tempo de receber dinheiro
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyTime -= Time.deltaTime;
        if(moneyTime <= 0)
        {
            money += 5;
            moneyTime = 5;
        }
    }


}
