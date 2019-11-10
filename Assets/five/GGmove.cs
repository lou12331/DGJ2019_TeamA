using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GGmove : MonoBehaviour
{
    public GameObject Instantiate_Position; 
    public GameObject Box;
    public List<GameObject> lsit;
    public static int index;
    public Text text;
    bool yes;
    void Start() 
    {
        index = Random.Range(0, 5);
        Box.transform.position = lsit[index].transform.position;
        text.text = "";
    }
    private void Update()
    {
        switch (index)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("P1wim");
                    text.text = "P1 Win";
                    Instantiate(Resources.Load("yes"));
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log("P1wim");
                    text.text = "P1 Win";
                    Instantiate(Resources.Load("yes"));
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("P1wim");
                    text.text = "P1 Win";
                    Instantiate(Resources.Load("yes"));
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("P1wim");
                    text.text = "P1 Win";
                    Instantiate(Resources.Load("yes"));
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.BackQuote))
                {
                    Debug.Log("P1wim");
                    text.text = "P1 Win";
                    Instantiate(Resources.Load("yes"));
                }
                break;
        
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A)
    || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (!yes)
                Instantiate(Resources.Load("show"));
        }
        yes = false;
    }

}


