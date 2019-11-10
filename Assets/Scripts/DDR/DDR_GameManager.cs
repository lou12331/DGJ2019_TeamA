using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using HutongGames.PlayMaker;


public class DDR_GameManager : MonoBehaviour
{
    public static DDR_GameManager Instance;
    public float SpawnPosY = 5;
    public List<DDR_Block> Blocks;
    public bool GameStart;
    public GameObject Player1HandleBlock;
    public GameObject Player2HandleBlock;
    public Text MindText;
    public bool isGameOver;

    public AudioSource AudioSource;
    public AudioClip CoinSound;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart)
        {
            if (Player1HandleBlock == null)
            {
                int r = Random.Range(0, Blocks.Count);
                Player1HandleBlock = Instantiate(Blocks[r].Prefab);
                Player1HandleBlock.transform.position = new Vector3(Blocks[r].SpawnPosX_P1, SpawnPosY);
                Player1HandleBlock.GetComponent<DDR_BlockScript>().Onwer = DDR_BlockScript.Player.Player1;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Player1HandleBlock.transform.DOMoveX(Player1HandleBlock.transform.position.x - 0.6f, 0.1f);
                    //Player1HandleBlock.GetComponent<Rigidbody2D>().MovePosition(new Vector2(Player1HandleBlock.transform.position.x - 0.6f, Player1HandleBlock.transform.position.y));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Player1HandleBlock.transform.DOMoveX(Player1HandleBlock.transform.position.x + 0.6f, 0.1f);
                    //Player1HandleBlock.GetComponent<Rigidbody2D>().MovePosition(new Vector2(Player1HandleBlock.transform.position.x + 0.6f, Player1HandleBlock.transform.position.y));
                }
            }

            if (Player2HandleBlock == null)
            {
                int r = Random.Range(0, Blocks.Count);
                Player2HandleBlock = Instantiate(Blocks[r].Prefab);
                Player2HandleBlock.transform.position = new Vector3(Blocks[r].SpawnPosX_P2, SpawnPosY);
                Player2HandleBlock.GetComponent<DDR_BlockScript>().Onwer = DDR_BlockScript.Player.Player2;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Debug.Log("Left");
                    Player2HandleBlock.transform.DOMoveX(Player2HandleBlock.transform.position.x - 0.6f, 0.1f);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Debug.Log("Right");
                    Player2HandleBlock.transform.DOMoveX(Player2HandleBlock.transform.position.x + 0.6f, 0.1f);
                }
            }
        }
    }

    public void GameOver(DDR_BlockScript.Player Winner)
    {
        StartCoroutine(gameover(Winner));
    }
    IEnumerator gameover(DDR_BlockScript.Player Winner)
    {
        if (isGameOver) yield break;
        isGameOver = true;
        Instance.GameStart = false;
        if (Winner == DDR_BlockScript.Player.Player1)
        {
            MindText.text = "玩家1獲勝";
        }
        else
        {
            MindText.text = "玩家2獲勝";
        }
        yield return new WaitForSeconds(2);
        if (Winner == DDR_BlockScript.Player.Player1)
        {
            GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
        }
        else
        {
            GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
        }
    }
}
[System.Serializable]
public class DDR_Block
{
    public GameObject Prefab;
    public float SpawnPosX_P1;
    public float SpawnPosX_P2;
}
