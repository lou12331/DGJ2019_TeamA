using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LinchLab
{
    public class DanceManager : MonoBehaviour
    {
        public static DanceManager instance;
        public bool isOnGame = false;
        public bool isOnReset = false;

        //public AudioSource aud;

        public GameObject txtMsg;
        public GameObject txtMsgA;
        public GameObject txtMsgB;

        private List<danceKey> collection;
        private List<List<danceKey>> source_collection = new List<List<danceKey>>() {
            new List<danceKey>() {
            danceKey.A,
            danceKey.A,
            danceKey.B,
            danceKey.B,
            danceKey.up,
            danceKey.down
        },
   new List<danceKey>() {
            danceKey.B,
            danceKey.B,
            danceKey.A,
            danceKey.B,
            danceKey.A,
            danceKey.down
        },
      new List<danceKey>() {
            danceKey.up,
            danceKey.down,
            danceKey.up,
            danceKey.down,
            danceKey.left,
            danceKey.right
        },
         new List<danceKey>() {
            danceKey.up,
            danceKey.up,
            danceKey.down,
            danceKey.down,
            danceKey.left,
            danceKey.left,
            danceKey.right,
            danceKey.right,
            danceKey.B,
            danceKey.A,
         }
    };

        public danceKey expectedKeyA;
        public danceKey expectedKeyB;
        public int idx_a;
        public int idx_b;
        public int idx_main;
        public int game_count = 0;

        public GameObject dancer_a;
        public GameObject dancer_b;

        public GameObject txt_win_a;
        public GameObject txt_win_b;

        private int win_player_1 = 0;
        private int win_player_2 = 0;

        private void Awake()
        {
            instance = this;
            //aud = this.gameObject.GetComponent<AudioSource>();
        }

        private void Start()
        {
            collection = new List<danceKey>();
            dancer_a.GetComponent<SpineHelper>().setAnimation("Idle");
            dancer_b.GetComponent<SpineHelper>().setAnimation("Idle");
            setMsgPlayerA("");
            setMsgPlayerB("");

            txtMsgA.GetComponent<Text>().supportRichText = true;
            txtMsgB.GetComponent<Text>().supportRichText = true;


            StartCoroutine(initGame());
        }
        void Update()
        {
            txt_win_a.GetComponent<Text>().text = win_player_1.ToString();
            txt_win_b.GetComponent<Text>().text = win_player_2.ToString();

            if (collection.Count != 0 && isOnGame)
            {
                if (idx_a == collection.Count)
                {
                    game_count++;
                    if (game_count != source_collection.Count)
                        win_player_1++;
                    else
                        win_player_1 += 10;

                    //aud.Stop();
                    isOnGame = false;
                    dancer_b.GetComponent<SpineHelper>().setAnimationLoop("Cry");
                    dancer_a.GetComponent<SpineHelper>().setAnimation("Win");
                    setMsg("Player 1 Wins!");

                    checkGameSet();
                    Instantiate(SE.instance.applause);
                }

                if (idx_b == collection.Count)
                {
                    game_count++;
                    if (game_count != source_collection.Count)
                        win_player_2++;
                    else
                        win_player_2 += 10;

                    //aud.Stop();
                    isOnGame = false;
                    dancer_a.GetComponent<SpineHelper>().setAnimationLoop("Cry");
                    dancer_b.GetComponent<SpineHelper>().setAnimation("Win");
                    setMsg("Player 2 Wins!");

                    checkGameSet();
                    Instantiate(SE.instance.applause);
                }
            }
        }

        private void checkGameSet()
        {
            if (game_count != source_collection.Count)
            {
                Debug.Log("Restarting Game");
                StartCoroutine(resetGame());
            }
            else
            {
                if (win_player_1 > win_player_2)
                {
                    if (GeneralManager.Instance != null)
                        GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
                }
                else
                {
                    if (GeneralManager.Instance != null)
                        GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
                }
                setMsg("GAME OVER!");
            }
        }

        private IEnumerator resetGame()
        {
            idx_main++;
            yield return new WaitForSeconds(3);
            StartCoroutine(initReGame());
            isOnReset = false;
        }

        public void moveNextA()
        {
            Instantiate(SE.instance.correct);
            idx_a++;
            if (idx_a <= collection.Count - 1)
                expectedKeyA = collection[idx_a];

            string startTag = "<color=#70f356>";
            string endTag = "</color>";
            string msg = startTag;
            for (int i = 0; i < collection.Count; i++)
            {
                if (i == idx_a - 1)
                    msg += GetCmd(collection[i]) + endTag;
                else
                    msg += GetCmd(collection[i]);
            }
            setMsgPlayerA(msg);
        }

        public void moveNextB()
        {
            Instantiate(SE.instance.correct);
            idx_b++;
            if (idx_b <= collection.Count - 1)
                expectedKeyB = collection[idx_b];

            string startTag = "<color=#70f356>";
            string endTag = "</color>";
            string msg = startTag;
            for (int i = 0; i < collection.Count; i++)
            {
                if (i == idx_b - 1)
                    msg += GetCmd(collection[i]) + endTag;
                else
                    msg += GetCmd(collection[i]);
            }
            setMsgPlayerB(msg);
        }

        public IEnumerator initGame()
        {
            setMsg("Ready?");
            yield return new WaitForSeconds(3);
            Instantiate(SE.instance.count_count);
            setMsg("3");
            yield return new WaitForSeconds(1);
            Instantiate(SE.instance.count_count);
            setMsg("2");
            yield return new WaitForSeconds(1);
            Instantiate(SE.instance.count_count);
            setMsg("1");
            yield return new WaitForSeconds(1);
            Instantiate(SE.instance.count_start);
            setMsg("GO!!!");
            yield return new WaitForSeconds(1);

            setGame(source_collection[idx_main]);
        }

        public IEnumerator initReGame()
        {
            setMsg("Ready?");
            yield return new WaitForSeconds(1);
            setMsg("GO!!!");
            yield return new WaitForSeconds(1);

            setGame(source_collection[idx_main]);
        }


        public void setGame(List<danceKey> _collection)
        {
            //aud.Play();

            collection = _collection;
            expectedKeyA = collection[0];
            expectedKeyB = collection[0];

            dancer_a.GetComponent<SpineHelper>().setAnimationLoop("Idle");
            dancer_b.GetComponent<SpineHelper>().setAnimationLoop("Idle");

            idx_a = idx_b = 0;

            string danceCmdSet = GetCmd();

            isOnGame = true;
            setMsg("");
            setMsgPlayerA(danceCmdSet);
            setMsgPlayerB(danceCmdSet);

            dancer_b.GetComponent<SpineHelper>().setAnimationLoop("Dancing");
            dancer_a.GetComponent<SpineHelper>().setAnimationLoop("Dancing");
        }

        private string GetCmd()
        {
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
            return danceCmdSet;
        }

        private string GetCmd(string cmd)
        {
            string danceCmdSet = string.Empty;

            danceKey key = (danceKey)Enum.Parse(typeof(danceKey), cmd);
            switch (key)
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
            return danceCmdSet;
        }

        private string GetCmd(danceKey key)
        {
            string danceCmdSet = string.Empty;
            switch (key)
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
            return danceCmdSet;
        }

        public void setMsg(string msg)
        {
            txtMsg.GetComponent<Text>().text = msg;
        }

        public void setMsgPlayerA(string msg)
        {
            txtMsgA.GetComponent<Text>().text = msg;
        }
        public void setMsgPlayerB(string msg)
        {
            txtMsgB.GetComponent<Text>().text = msg;
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
}