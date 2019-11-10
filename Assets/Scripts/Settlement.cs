using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settlement : MonoBehaviour
{
    public Text P1Text, P2Text, MindText;
    public int ShowP1Score, ShowP2Score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowSettlement()
    {
        StartCoroutine(showSettlement());
    }
    IEnumerator showSettlement()
    {
        yield return null;
        P1Text.text = ShowP1Score.ToString();
        P2Text.text = ShowP2Score.ToString();
        yield return new WaitForSeconds(1);
        ShowP1Score = GeneralManager.Instance.Player1Score;
        ShowP2Score = GeneralManager.Instance.Player2Score;
        P1Text.text = ShowP1Score.ToString();
        P2Text.text = ShowP2Score.ToString();
        yield return new WaitForSeconds(1);
        if (ShowP1Score > ShowP2Score)
        {
            MindText.text = "←他贏了";
        }
        else if (ShowP1Score < ShowP2Score)
        {
            MindText.text = "他贏了→";
        }
        else
        {
            MindText.text = "平手";
        }
    }
    public void ShowEndSettlement()
    {
        P1Text.text = ShowP1Score.ToString();
        P2Text.text = ShowP2Score.ToString();
        if (ShowP1Score > ShowP2Score)
        {
            MindText.text = "玩家1獲勝";
        }
        else if (ShowP1Score < ShowP2Score)
        {
            MindText.text = "玩家2獲勝";
        }
        else
        {
            MindText.text = "平手，進入加賽";
        }
    }
}
