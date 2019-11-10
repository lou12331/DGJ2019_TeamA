using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaManager : MonoBehaviour
{
    public List<GameObject> pandas;
    public float factor;
    public bool p1;
    private Vector3 ray;

    public bool p1W=false;
    public bool p2W=false;
    public PandaBehavior pa;
    Coroutine co;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var c = collision.GetComponent<PandaCollider>();
        if (c.isAnswer)
        {
            if(p1)
            {
                pa = collision.GetComponent<PandaBehavior>();
                p1W = true;
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
                }
            }
            else
            {
                pa = collision.GetComponent<PandaBehavior>();
                p2W = true;
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
                }
            }
            Debug.Log(p1W +":"+ p2W);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var c = collision.GetComponent<PandaCollider>();
        if (!c.isAnswer)
        {
            if (p1)
            {
                p1W = false;
      
            }
            else
            {
                p2W = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (p1W || p2W)
        {
            if(pa)
            {
                if(co == null)
                    co = StartCoroutine(pa.Anim());
                //pa.SetWin2();
            }
            else
            {
                Debug.LogError("no panda 87");
            }

            return;
        }

        if (p1)
        {
            if (SYS.input.rightKeyA)
            {
                transform.position += Vector3.right * factor;
            }
            if (SYS.input.leftKeyA)
            {
                transform.position += Vector3.left * factor;
            }
            if (SYS.input.upKeyA)
            {
                transform.position += Vector3.up * factor;
            }
            if (SYS.input.downKeyA)
            {
                transform.position += Vector3.down * factor;
            }
        }
        else
        {
            if (SYS.input.rightKeyB)
            {
                transform.position += Vector3.right * factor;
            }
            if (SYS.input.leftKeyB)
            {
                transform.position += Vector3.left * factor;
            }
            if (SYS.input.upKeyB)
            {
                transform.position += Vector3.up * factor;
            }
            if (SYS.input.downKeyB)
            {
                transform.position += Vector3.down * factor;
            }
        }

    }
}
