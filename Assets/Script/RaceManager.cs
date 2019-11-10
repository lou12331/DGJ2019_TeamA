using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace LinchLab
{
    public class RaceManager : MonoBehaviour
    {
        public static RaceManager instance;

        public AudioSource aud;


        public GameObject txtMsg;
        public GameObject txtHintA;
        public GameObject txtHintB;

        public GameObject player_a;
        public GameObject player_b;
        public GameObject end_a;
        public GameObject end_b;

        public GameObject super_rock_a;
        public GameObject super_rock_b;


        private bool showDistance = false;

        private void Awake()
        {
            instance = this;
            txtHintA.GetComponent<Text>().text = "";
            txtHintB.GetComponent<Text>().text = "";
            aud = GetComponent<AudioSource>();

            super_rock_a.SetActive(false);
            super_rock_b.SetActive(false);
            int rand = (int)Random.Range(0, 100);
            if (rand % 2 == 0)
            {
                super_rock_a.SetActive(true);
            }
            else
            {
                super_rock_b.SetActive(true);
            }


        }

        private void Update()
        {
            if (showDistance)
            {
                txtHintA.GetComponent<Text>().text = (int)(end_a.gameObject.transform.position.x -
                 player_a.gameObject.transform.position.x) + "m";

                txtHintB.GetComponent<Text>().text = (int)(end_b.gameObject.transform.position.x -
                   player_b.gameObject.transform.position.x) + "m";
            }
            else
            {
                txtHintA.GetComponent<Text>().text = "";
                txtHintB.GetComponent<Text>().text = "";
            }
        }


        void Start()
        {
            txtMsg.GetComponent<Text>().text = "";
            player_a.GetComponent<RacePlayerCharacterControlA>().enabled = false;
            player_b.GetComponent<RacePlayerCharacterControlB>().enabled = false;

            StartCoroutine(initGame());
        }



        public IEnumerator initGame()
        {
            setMsg("Ready?");
            yield return new WaitForSeconds(3);
            setMsg("3");
            Instantiate(SE.instance.count_count);
            yield return new WaitForSeconds(1);
            setMsg("2");
            Instantiate(SE.instance.count_count);
            yield return new WaitForSeconds(1);
            setMsg("1");
            Instantiate(SE.instance.count_count);
            yield return new WaitForSeconds(1);
            setMsg("GO!!!");
            Instantiate(SE.instance.count_start);
            yield return new WaitForSeconds(1);
            setMsg("");
            setGame();
        }

        public void setGame()
        {
            aud.Play();
            player_a.GetComponent<RacePlayerCharacterControlA>().enabled = true;
            player_b.GetComponent<RacePlayerCharacterControlB>().enabled = true;
            showDistance = true;
        }

        public void setGameEnd(string msg = "")
        {
            aud.Stop();
            showDistance = false;
            player_a.GetComponent<RacePlayerCharacterControlA>().enabled = false;
            player_b.GetComponent<RacePlayerCharacterControlB>().enabled = false;
            setMsg(msg);
        }

        public void setMsg(string msg)
        {
            txtMsg.GetComponent<Text>().text = msg;
        }

    }
}