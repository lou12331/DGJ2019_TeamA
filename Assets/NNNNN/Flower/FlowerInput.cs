using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInput : MonoBehaviour
{
    public bool canMove;
    public float deltaAngle;
    public string inputA;
    public string inputB;
    public FlowerInput next;
    public float targetValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void DoNext()
    {
        this.canMove = false;
        if(next)
        {
            next.canMove = true;
        }
        else
        {

            Debug.LogError("沒有下一個萬花筒 ");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            if(Input.GetKey(inputA))
            {
                transform.eulerAngles += new Vector3(0, 0, 1) * deltaAngle;
            }
            if (Input.GetKey(inputB))
            {
                transform.eulerAngles -= new Vector3(0, 0, 1) * deltaAngle;
            }

            if (Mathf.Approximately(Mathf.RoundToInt(transform.eulerAngles.z), Mathf.RoundToInt(targetValue)))
            {
                DoNext();
                Debug.LogError("YA");
            }
        }


    }
}
