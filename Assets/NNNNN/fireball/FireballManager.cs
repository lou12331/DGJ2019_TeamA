﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballManager : MonoBehaviour
{
    public FireBallInput p1, p2;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(p1 && p2)
        {
            if(p1.isLose)
            {
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
                }
                text.text = "P2 Win";
                Debug.Log("P2 Win");
                p1.enabled = false;
                return;
            }
            if(p2.isLose)
            {
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
                }
                Debug.Log("P1 Win");
                text.text = "P1 Win";
                p2.enabled = false;
                return;
            }
           

        }
        else
        {
            Debug.LogError("Null player 87");
        }
    }
}
