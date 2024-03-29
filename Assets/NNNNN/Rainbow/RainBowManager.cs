﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBowManager : MonoBehaviour
{
    public List<GameObject> gos;
    public float timer;
    public float timermax;
    public Transform spawnPoint;
    public GameObject current;
    public RainBowPlayer p1, p2;
    public Object vomitSF;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(p1 && p2)
        {
      
            if (p1.isWin || p2.isWin)
            {
                if(vomitSF == null) vomitSF=Instantiate(Resources.Load("vomit")); 
                if (p1.isWin)
                {
                    Debug.Log("p1Win");
                    p1.PlayWinAnim();
                    if (GeneralManager.Instance)
                    {
                        GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
                    }
                }
                if (p2.isWin)
                {
                    Debug.Log("p2Win");
                    p2.PlayWinAnim();
                    if (GeneralManager.Instance)
                    {
                        GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
                    }
                }

                if (current) Destroy(current,1);
                return;
            }

            if (p1.currentTime <= 0)
            {
                p2.isWin = true;
            }
            if (p2.currentTime <= 0)
            {
                p1.isWin = true;
            }

        }
        else
        {
            Debug.LogError("87");
        }

        if(timer < timermax)
        {
            timer += Time.deltaTime;
        }
        if(timer >= timermax)
        {
            if (current) Destroy(current);
            current = Instantiate(gos[Random.Range(0, gos.Count)], spawnPoint);
            current.SetActive(true);
            timer = 0;
        }

        
    }
}
