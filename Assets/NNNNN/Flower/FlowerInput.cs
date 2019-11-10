using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInput : MonoBehaviour
{
    public bool canMove;
    public float deltaAngle;
    public KeyCode inputA;
    public KeyCode inputB;
    public FlowerInput next;
    public float targetValue;
    public bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void DoNext()
    {
        transform.DOScale(Vector3.one * 1.3f, 0.5f).SetLoops(2, LoopType.Yoyo);
        this.canMove = false;
        if(next)
        {
            next.canMove = true;
        }
        else
        {
            win = true;
            Debug.LogError("沒有下一個萬花筒 ");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canMove)
        {
            if(Input.GetKeyDown(inputA))
            {
                transform.eulerAngles += new Vector3(0, 0, 1) * deltaAngle;
                Instantiate(Resources.Load("roll"));
            }
            if (Input.GetKeyDown(inputB))
            {
                transform.eulerAngles -= new Vector3(0, 0, 1) * deltaAngle;
                Instantiate(Resources.Load("roll"));
            }

            if (Mathf.Approximately(Mathf.RoundToInt(transform.eulerAngles.z), Mathf.RoundToInt(targetValue)))
            {
                Instantiate(Resources.Load("key"));
                DoNext();
                Debug.LogError("YA");
            }
        }


    }
}
