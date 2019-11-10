using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
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
                text.text = "P1 Win";
                if (GeneralManager.Instance)
                {
                    GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
                }
            }
            else
            {
                pa = collision.GetComponent<PandaBehavior>();
                p2W = true;
                text.text = "P2 Win";
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
                {
                    co = StartCoroutine(pa.Anim());
                    Instantiate(Resources.Load("pandashoot"));
                }
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
                transform.position += Vector3.right * factor * Time.deltaTime;
            }
            if (SYS.input.leftKeyA)
            {
                transform.position += Vector3.left * factor * Time.deltaTime;
            }
            if (SYS.input.upKeyA)
            {
                transform.position += Vector3.up * factor * Time.deltaTime;
            }
            if (SYS.input.downKeyA)
            {
                transform.position += Vector3.down * factor * Time.deltaTime;
            }
        }
        else
        {
            if (SYS.input.rightKeyB)
            {
                transform.position += Vector3.right * factor * Time.deltaTime;
            }
            if (SYS.input.leftKeyB)
            {
                transform.position += Vector3.left * factor * Time.deltaTime;
            }
            if (SYS.input.upKeyB)
            {
                transform.position += Vector3.up * factor * Time.deltaTime;
            }
            if (SYS.input.downKeyB)
            {
                transform.position += Vector3.down * factor * Time.deltaTime;
            }
        }

    }
}
