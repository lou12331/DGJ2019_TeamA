﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoTiManager : MonoBehaviour
{
    public List<HoTiBehavior> listA, listB;
    public int indexa=0, indexb=0;
    public float moveFactor = 0.5f;
    public Text text;
    private Object o;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(ValidateWin(listA) || ValidateWin(listB))
        {
            if(ValidateWin(listA))
            {
                Debug.LogError("TODO:A win");
                text.text = "P1 Win";
                if(o==null) o=Instantiate(Resources.Load("111"));
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
                }
                //GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Instance.Player.Player1);

            }
            if (ValidateWin(listB))
            {
                Debug.LogError("TODO:B win");
                text.text = "P2 Win";
                if (o == null) o = Instantiate(Resources.Load("111"));
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
                }
            }
            Debug.Log(ValidateWin(listA) + ":" + ValidateWin(listB));
            return;
        }

        DoDoDo1(listA);
        DoDoDo2(listB);
    }

    private void DoDoDo1(List<HoTiBehavior> list)
    {
        ValidateShow(list[indexa]);
        if (list[indexa].canMove)
        {
            if(list[indexa].SHOW)
            if (SYS.input.key_confirm_a)
            {
                //Rotate
                list[indexa].transform.localEulerAngles += new Vector3(0, 0, 1) * 90;
                Debug.Log("key_confirm_a");
                Instantiate(Resources.Load("roll"));
                }
            if (SYS.input.key_cancel_a)
            {
                //change list
                list[indexa].SHOW.SetActive(false);
                indexa++;
                indexa %= list.Count;
                Debug.Log("key_cancel_a");
            }
            if (SYS.input.upKeyA)
            {
                list[indexa].transform.localPosition += Vector3.up * moveFactor;
            }
            if (SYS.input.downKeyA)
            {
                list[indexa].transform.localPosition += Vector3.down * moveFactor;
            }
            if (SYS.input.leftKeyA)
            {
                list[indexa].transform.localPosition += Vector3.left * moveFactor;
            }
            if (SYS.input.rightKeyA)
            {
                list[indexa].transform.localPosition += Vector3.right * moveFactor;
            }
        }
        else
        {

            indexa++;
            indexa %= listA.Count;
            return;
        }
    }

    private void ValidateShow(HoTiBehavior Hoti)
    {
        if (Hoti == null) return;
        if(Hoti.canMove)
        {
            Hoti.SHOW.SetActive(true);
        }
        else
        {
            Hoti.SHOW.SetActive(false);
        }
    }

    private void DoDoDo2(List<HoTiBehavior> list)
    {
        ValidateShow(list[indexb]);
        if (list[indexb].canMove)
        {
            if (SYS.input.key_confirm_b)
            {
                //Rotate
                list[indexb].transform.localEulerAngles += new Vector3(0, 0, 1) * 90;
                Debug.Log("key_confirm_b");
                Instantiate(Resources.Load("roll"));
            }
            if (SYS.input.key_cancel_b)
            {
                //change list
                list[indexb].SHOW.SetActive(false);
                indexb++;
                indexb %= list.Count;
                Debug.Log("key_cancel_b");
            }
            if (SYS.input.upKeyB)
            {
                list[indexb].transform.localPosition += Vector3.up * moveFactor;
            }
            if (SYS.input.downKeyB)
            {
                list[indexb].transform.localPosition += Vector3.down * moveFactor;
            }
            if (SYS.input.leftKeyB)
            {
                list[indexb].transform.localPosition += Vector3.left * moveFactor;
            }
            if (SYS.input.rightKeyB)
            {
                list[indexb].transform.localPosition += Vector3.right * moveFactor;
            }
        }
        else
        {

            indexb++;
            indexb %= listB.Count;
            return;
        }
    }

    private bool ValidateWin(List<HoTiBehavior> list)
    {
        bool isWin = true;
        foreach(var i in list)
        {
            if(i.canMove)
            {
                isWin = false;
            }
        }
        return isWin;
    }
}
