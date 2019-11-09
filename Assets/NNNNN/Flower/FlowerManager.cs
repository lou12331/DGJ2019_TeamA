using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerManager : MonoBehaviour
{
    public Text text;
    public string p1Wintext, p2Wintext;

    public bool IsOn;
    public FlowerInput p1;
    public FlowerInput p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOn)
        {
            if(p1.win || p2.win)
            {
                if(p1.win)
                {
                    text.text = p1Wintext;
                }
                if (p2.win)
                {
                    text.text = p2Wintext;
                }
                IsOn = false;
            }
            
        }
        
    }
}
