using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceManager : MonoBehaviour
{
    public static DanceManager instance;
    public bool isOnGame = false;

    public GameObject txtMsg;
    private List<danceKey> collection;
    public danceKey expectedKeyA;
    public danceKey expectedKeyB;
    public int idx_a;
    public int idx_b;
    public GameObject dancer_a;
    public GameObject dancer_b;

    private void Start()
    {
        instance = this;
        collection = new List<danceKey>();
        dancer_a.GetComponent<SpineHelper>().setAnimation("Idle");
        dancer_b.GetComponent<SpineHelper>().setAnimation("Idle");

        StartCoroutine(initGame());
    }
    void Update()
    {
        if (collection.Count != 0 && isOnGame)
        {
            if (idx_a == collection.Count)
            {
                isOnGame = false;
                dancer_b.GetComponent<SpineHelper>().setAnimationLoop("Dead A");
                dancer_a.GetComponent<SpineHelper>().setAnimationLoop("Idle");
                Debug.Log("Player A Wins!");
            }

            if (idx_b == collection.Count)
            {
                isOnGame = false;
                dancer_a.GetComponent<SpineHelper>().setAnimationLoop("Dead A");
                dancer_b.GetComponent<SpineHelper>().setAnimationLoop("Idle");
                Debug.Log("Player B Wins!");
            }
        }
    }

    public void moveNextA()
    {
        Debug.Log("Key Match!");
        idx_a++;
        if (idx_a <= collection.Count - 1)
            expectedKeyA = collection[idx_a];
    }

    public void moveNextB()
    {
        Debug.Log("Key Match!");
        idx_b++;
        if (idx_b <= collection.Count - 1)
            expectedKeyA = collection[idx_b];
    }

    public IEnumerator initGame()
    {
        setMsg("Ready?");
        yield return new WaitForSeconds(3);
        setMsg("3");
        yield return new WaitForSeconds(1);
        setMsg("2");
        yield return new WaitForSeconds(1);
        setMsg("1");
        yield return new WaitForSeconds(1);
        setMsg("GO!!!");
        yield return new WaitForSeconds(1);

        List<danceKey> dacne_set_a = new List<danceKey>() {
            danceKey.A,
            danceKey.A,
            danceKey.B,
            danceKey.B,
            danceKey.up,
            danceKey.down
        };
        setGame(dacne_set_a);

    }

    public void setGame(List<danceKey> _collection)
    {
        collection = _collection;
        expectedKeyA = collection[0];
        expectedKeyB = collection[0];

        dancer_a.GetComponent<SpineHelper>().setAnimationLoop("Swing Knife");
        dancer_b.GetComponent<SpineHelper>().setAnimationLoop("Swing Knife");

        string danceCmdSet = string.Empty;

        foreach (danceKey dance_key in collection)
        {
            switch (dance_key)
            {
                case danceKey.up:
                    danceCmdSet += "↑";
                    break;
                case danceKey.down:
                    danceCmdSet += "↓";
                    break;
                case danceKey.right:
                    danceCmdSet += "→";
                    break;
                case danceKey.left:
                    danceCmdSet += "←";
                    break;
                case danceKey.A:
                    danceCmdSet += "A";
                    break;
                case danceKey.B:
                    danceCmdSet += "B";
                    break;
                default:
                    break;
            }
        }
        isOnGame = true;
        setMsg(danceCmdSet);
    }

    public void setMsg(string msg)
    {
        txtMsg.GetComponent<Text>().text = msg;
    }

    public enum danceKey
    {
        up,
        down,
        right,
        left,
        A,
        B

    }
}
