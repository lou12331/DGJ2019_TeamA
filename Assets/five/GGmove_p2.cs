using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GGmove_p2 : MonoBehaviour
{
    public GameObject Instantiate_Position;
    public GameObject Box;
    public List<GameObject> lsit;
    public int index;
    public Text text;
    void Start()
    {
        index = GGmove.index;
        index = Random.Range(0, 5);
        Box.transform.position = lsit[index].transform.position;
        text.text = "";

    }
    private void Update()
    {
        switch (index)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("P2wim");
                    text.text = "P2 Win";
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Debug.Log("P2wim");
                    text.text = "P2 Win";
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Debug.Log("P2wim");
                    text.text = "P2 Win";
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Debug.Log("P2wim");
                    text.text = "P2 Win";
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.Comma))
                {
                    Debug.Log("P2wim");
                    text.text = "P2 Win";
                }
                break;
        }
    }

}
