using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Text = UnityEngine.UI.Text;

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
        text.text = "";
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
                    if (GeneralManager.Instance)
                    {
                        GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
                    }
                    Debug.LogError("Todo P1 Win");
                }
                if (p2.win)
                {
                    text.text = p2Wintext;
                    if (GeneralManager.Instance)
                    {
                        GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
                    }
                    Debug.LogError("Todo P2 Win");
                }
                IsOn = false;
            }
            
        }
        
    }
}
