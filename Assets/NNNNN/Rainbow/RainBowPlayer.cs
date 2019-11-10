﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBowPlayer : MonoBehaviour
{
    public RainBowManager manager;
    public bool p1;
    public int targetTime = 3;
    public int currentTime = 0;
    public bool isWin = false;
    public float animDelayTime=1;
    Coroutine myCo;
    public Sprite[] sps;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<RainBowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime >= targetTime)
        {
            isWin = true;
            if(p1)
            {
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
                }
            }
            else
            {
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
                }
            }
     
            return;
        }

        if(p1)
        {
            if (SYS.input.key_confirm_a)
            {
                SetOwner();
            }
        }
        else
        {
            if (SYS.input.key_confirm_b)
            {
                SetOwner();
            }
        }
        
    }

    private void SetOwner()
    {
        var tag = manager.current?.GetComponent<RainbowTag>();
        if (tag.HasOwner == null)
        {
            tag.HasOwner = this.gameObject;
            if(tag.tag =="wine")
            {
                GetComponent<Renderer>().material.DOColor(Color.red, 0.5f).SetLoops(2, LoopType.Yoyo);
                currentTime++;
                Instantiate(Resources.Load("wineSE"));
            }
            if (tag.tag == "water")
            {
                GetComponent<Renderer>().material.DOColor(Color.blue, 0.5f).SetLoops(2, LoopType.Yoyo);
                currentTime--;
                Instantiate(Resources.Load("waterSE"));
            }
        }
    }

    public bool PlayWinAnim()
    {
        if(myCo==null)
        {
            myCo = StartCoroutine(Anim());
            return true;
        }

        return false;
    }

    IEnumerator Anim()
    {
        Debug.Log("anim");
        yield return new WaitForSeconds(1);
        do
        {
            if(index >= sps.Length-1)
            {
                index--;
            }
            else
            {
                index++;
            }
            
            GetComponent<SpriteRenderer>().sprite = sps[index];

            yield return new WaitForSeconds(animDelayTime);
        }
        while (index < sps.Length);
    
        StopCoroutine(myCo);
        
    }
}
