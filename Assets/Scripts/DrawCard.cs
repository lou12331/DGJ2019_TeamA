using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HutongGames.PlayMaker;
using DG.Tweening;

public class DrawCard : MonoBehaviour
{
    public Vector2 AxisRaw_Player1;
    public Vector2 AxisRaw_Player2;
    bool Player1_LeftPress;
    bool Player1_RightPress;
    bool Player2_LeftPress;
    bool Player2_RightPress;

    public List<Image> CardImages_Player1;
    public List<Image> CardImages_Player2;
    public List<Image> SlotImages_Player1;
    public List<Image> SlotImages_Player2;

    public int SelectingID_Player1 = 0;
    public int SelectingID_Player2 = 0;

    public bool StartSelect;
    public GameObject SelectOutline_Player1;
    public GameObject SelectOutline_Player2;

    public List<string> SelectedCard_Player1;
    public List<string> SelectedCard_Player2;


    public string[] DrawCards_Player1;
    public string[] DrawCards_Player2;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        StartCoroutine(LittlteDelay(0.2f));
    }

    // Update is called once per frame
    void Update()
    {
        AxisRaw_Player1 = new Vector2(Input.GetAxisRaw("HorizontalA"), Input.GetAxisRaw("VerticalA"));
        AxisRaw_Player2 = new Vector2(Input.GetAxisRaw("HorizontalB"), Input.GetAxisRaw("VerticalB"));


        if (StartSelect)
        {
            InputAndSelect();

            SelectingID_Player1 = Mathf.Clamp(SelectingID_Player1, 0, 5);
            SelectingID_Player2 = Mathf.Clamp(SelectingID_Player2, 0, 5);
            SelectOutline_Player1.transform.position = CardImages_Player1[SelectingID_Player1].transform.position;
            SelectOutline_Player2.transform.position = CardImages_Player2[SelectingID_Player2].transform.position;

            if (SelectedCard_Player1.Count >= 3 && SelectedCard_Player2.Count >= 3)
            {
                StartSelect = false;
                SelectEnd();
            }
        }
        else
        {
            SelectOutline_Player1.SetActive(false);
            SelectOutline_Player2.SetActive(false);
        }
    }
    public void Draw()
    {
        DrawCards_Player1 = GeneralManager.Instance.GetComponent<MiniGameSceneManager>().GiveMeRandomSceneArray(6, new List<string>());
        DrawCards_Player2 = GeneralManager.Instance.GetComponent<MiniGameSceneManager>().GiveMeRandomSceneArray(6, new List<string>());


    }
    IEnumerator LittlteDelay(float dTime)
    {
        yield return new WaitForSeconds(dTime);
        Draw();
        MiniGameSceneManager miniGameScene = GeneralManager.Instance.GetComponent<MiniGameSceneManager>();
        for (int i = 0; i < 6; i++)
        {
            //CardImages_Player1[i].transform.GetComponentInChildren<Text>().text = DrawCards_Player1[i];
            //CardImages_Player2[i].transform.GetComponentInChildren<Text>().text = DrawCards_Player2[i];
            CardImages_Player1[i].transform.DOLocalRotate(new Vector3(0, -360, 0), 1, RotateMode.FastBeyond360);
            CardImages_Player2[i].transform.DOLocalRotate(new Vector3(0, -360, 0), 1, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(0.5f);
            CardImages_Player1[i].sprite = miniGameScene.GameCardSprites[miniGameScene.MiniGameScenes.FindIndex(x => x == DrawCards_Player1[i])];
            CardImages_Player2[i].sprite = miniGameScene.GameCardSprites[miniGameScene.MiniGameScenes.FindIndex(x => x == DrawCards_Player2[i])];


        }
        StartSelect = true;
        SelectOutline_Player1.SetActive(true);
        SelectOutline_Player2.SetActive(true);


    }
    void InputAndSelect()
    {
        #region 左右方向
        if (AxisRaw_Player1.x == 1)
        {
            if (!Player1_RightPress)
            {
                SelectingID_Player1++;
                Player1_RightPress = true;
            }
        }
        else Player1_RightPress = false;

        if (AxisRaw_Player1.x == -1)
        {
            if (!Player1_LeftPress)
            {
                SelectingID_Player1--;
                Player1_LeftPress = true;
            }
        }
        else Player1_LeftPress = false;

        if (AxisRaw_Player2.x == 1)
        {
            if (!Player2_RightPress)
            {
                SelectingID_Player2++;
                Player2_RightPress = true;
            }
        }
        else Player2_RightPress = false;

        if (AxisRaw_Player2.x == -1)
        {
            if (!Player2_LeftPress)
            {
                SelectingID_Player2--;
                Player2_LeftPress = true;
            }
        }
        else Player2_LeftPress = false;
        #endregion

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            SelectCard(SelectingID_Player1, 1);
        }
        else
        {
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
        }
        else
        {
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            SelectCard(SelectingID_Player2, 2);
        }
        else
        {
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
        }
        else
        {
        }
    }

    void SelectCard(int id, int PlayerID)
    {
        if (PlayerID == 1)
        {
            if (SelectedCard_Player1.Count >= 3) return;
            bool haveSelect = false;
            foreach (string item in SelectedCard_Player1)
            {
                if (item == DrawCards_Player1[id]) haveSelect = true;
            }
            if (haveSelect) return;

            SelectedCard_Player1.Add(DrawCards_Player1[id]);
            GameObject TempObj = Instantiate(CardImages_Player1[id].gameObject, transform);
            TempObj.transform.position = CardImages_Player1[id].transform.position;
            CardImages_Player1[id].color = new Color(0.5f, 0.5f, 0.5f);
            int i = SelectedCard_Player1.FindIndex(x => x == DrawCards_Player1[id]);
            TempObj.transform.DOMove(SlotImages_Player1[i].transform.position, 1f).SetEase(Ease.OutCirc).OnComplete(() =>
             {
                 Destroy(TempObj);
                 SlotImages_Player1[i].sprite = CardImages_Player1[id].sprite;
                 SlotImages_Player1[i].color = Color.white;
                 //SlotImages_Player1[SelectedCard_Player1.Count - 1].transform.GetComponentInChildren<Text>().text = DrawCards_Player1[id];
             });


        }
        if (PlayerID == 2)
        {
            if (SelectedCard_Player2.Count >= 3)
            {
                return;
            }
            bool haveSelect = false;
            foreach (string item in SelectedCard_Player2)
            {
                if (item == DrawCards_Player2[id]) haveSelect = true;
            }
            if (haveSelect) return;

            SelectedCard_Player2.Add(DrawCards_Player2[id]);
            GameObject TempObj = Instantiate(CardImages_Player2[id].gameObject, transform);
            TempObj.transform.position = CardImages_Player2[id].transform.position;
            CardImages_Player2[id].color = new Color(0.5f, 0.5f, 0.5f);
            int i = SelectedCard_Player2.FindIndex(x => x == DrawCards_Player2[id]);
            TempObj.transform.DOMove(SlotImages_Player2[i].transform.position, 1f).SetEase(Ease.OutCirc).OnComplete(() =>
            {
                Destroy(TempObj);
                SlotImages_Player2[i].sprite = CardImages_Player2[id].sprite;
                SlotImages_Player2[i].color = Color.white;
                //SlotImages_Player2[SelectedCard_Player2.Count - 1].transform.GetComponentInChildren<Text>().text = DrawCards_Player2[id];
            });

        }
    }

    void SelectEnd()
    {
        StartCoroutine(SelectEndWait());
    }
    IEnumerator SelectEndWait()
    {
        yield return new WaitForSeconds(1f);
        GeneralManager.Instance.SelectedCards = new List<string>();
        foreach (string item in SelectedCard_Player1)
        {
            GeneralManager.Instance.SelectedCards.Add(item);
        }
        foreach (string item in SelectedCard_Player2)
        {
            GeneralManager.Instance.SelectedCards.Add(item);
        }

        GeneralManager.Instance.GetComponent<PlayMakerFSM>().SendEvent("Next");
    }
}
