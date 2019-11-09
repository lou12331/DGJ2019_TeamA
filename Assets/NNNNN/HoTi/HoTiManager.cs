using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoTiManager : MonoBehaviour
{
    public List<HoTiBehavior> listA, listB;
    public int indexa=0, indexb=0;
    public float moveFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ValidateWin(listA) || ValidateWin(listB))
        {
            Debug.Log(ValidateWin(listA) + ":" + ValidateWin(listB));
            return;
        }

        DoDoDo1(listA);
        DoDoDo2(listB);
    }

    private void DoDoDo1(List<HoTiBehavior> list)
    {
        
        Debug.Log(ValidateWin(list) + "win A");
        if (list[indexa].canMove)
        {
            if (SYS.input.key_confirm_a)
            {
                //Rotate
                list[indexa].transform.localEulerAngles += new Vector3(0, 0, 1) * 90;
                Debug.Log("key_confirm_a");
            }
            if (SYS.input.key_cancel_a)
            {
                //change list
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

    private void DoDoDo2(List<HoTiBehavior> list)
    {

        Debug.Log(ValidateWin(list) + "win A");
        if (list[indexa].canMove)
        {
            if (SYS.input.key_confirm_b)
            {
                //Rotate
                list[indexa].transform.localEulerAngles += new Vector3(0, 0, 1) * 90;
                Debug.Log("key_confirm_b");
            }
            if (SYS.input.key_cancel_b)
            {
                //change list
                indexa++;
                indexa %= list.Count;
                Debug.Log("key_cancel_b");
            }
            if (SYS.input.upKeyB)
            {
                list[indexa].transform.localPosition += Vector3.up * moveFactor;
            }
            if (SYS.input.downKeyB)
            {
                list[indexa].transform.localPosition += Vector3.down * moveFactor;
            }
            if (SYS.input.leftKeyB)
            {
                list[indexa].transform.localPosition += Vector3.left * moveFactor;
            }
            if (SYS.input.rightKeyB)
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
