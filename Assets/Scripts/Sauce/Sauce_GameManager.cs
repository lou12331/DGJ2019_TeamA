using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Sauce_GameManager : MonoBehaviour
{
    public bool GameStart;
    public SaucePlayer Player1;
    public SaucePlayer Player2;
    public GameObject LiYang;
    public Sprite sp;
    public AudioClip AppleSound;
    public AudioClip OnionSound;
    public AudioClip SauceSound;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart)
        {
            PlayerUpadte(Player1, KeyCode.BackQuote);
            PlayerUpadte(Player2, KeyCode.Comma);
        }
    }
    public void init()
    {
        float r1 = Random.Range(100, Player1.BarBack.sizeDelta.x);
        float r2 = Random.Range(100, Player2.BarBack.sizeDelta.x);
        Player1.SafeZone.anchoredPosition = new Vector2(r1, 0);
        Player2.SafeZone.anchoredPosition = new Vector2(r2, 0);
        GameStart = true;
        GoForward(Player1);
        GoForward(Player2);
        Player1.Apple.SetActive(true);
        Player2.Apple.SetActive(true);
    }
    void PlayerUpadte(SaucePlayer Player, KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (Player.LV == 0)
            {

                if (Vector2.Distance(Player.Ping.anchoredPosition, Player.SafeZone.anchoredPosition) < 25)
                {
                    if (Player.Tweener.IsPlaying())
                    {
                        Player.Tweener.Kill();
                        Player.Apple.GetComponent<Shake>().StopShake();
                        Player.Apple.GetComponent<Animator>().SetTrigger("Finish");
                        AudioSource.PlayOneShot(AppleSound);
                        StartCoroutine(WaitAnimation(Player, Player.Onion));
                    }
                }
            }

            else if (Player.LV == 1)
            {
                if (Vector2.Distance(Player.Ping.anchoredPosition, Player.SafeZone.anchoredPosition) < 25)
                {
                    if (Player.Tweener.IsPlaying())
                    {
                        Player.Tweener.Kill();
                        Player.Onion.GetComponent<Shake>().StopShake();
                        Player.Onion.GetComponent<Animator>().SetTrigger("Finish");
                        AudioSource.PlayOneShot(OnionSound);
                        StartCoroutine(WaitAnimation(Player, Player.Sauce));
                    }
                }
            }
            else if (Player.LV == 2)
            {
                if (Vector2.Distance(Player.Ping.anchoredPosition, Player.SafeZone.anchoredPosition) < 25)
                {
                    if (Player.Tweener.IsPlaying())
                    {
                        Player.Tweener.Kill();
                        LiYang.SetActive(true);
                        Player.img.sprite = sp;
                        WhoWin(Player);
                        GameStart = false;
                    }
                }
            }
        }
    }
    IEnumerator WaitAnimation(SaucePlayer Player, GameObject OpenObj)
    {
        yield return new WaitForSeconds(2);
        Player.LV++;
        Player.Apple.SetActive(Player.Apple == OpenObj);
        Player.Onion.SetActive(Player.Onion == OpenObj);
        Player.Sauce.SetActive(Player.Sauce == OpenObj);
        float r1 = Random.Range(100, Player.BarBack.sizeDelta.x);
        Player.SafeZone.anchoredPosition = new Vector2(r1, 0);
        Player.Ping.anchoredPosition = new Vector2(0, 0);
        GoForward(Player);

        

        if (Player.LV == 2)
        {
            AudioSource.clip = SauceSound;
            AudioSource.loop = true;
            AudioSource.pitch = 2.46f;
            AudioSource.Play();
        }
    }
    void GoForward(SaucePlayer Player)
    {
        Player.Tweener = Player.Ping.DOAnchorPosX(Player.BarBack.sizeDelta.x, 1).SetEase(Ease.Linear).OnComplete(() => GoBack(Player));

    }
    void GoBack(SaucePlayer Player)
    {
        Player.Tweener = Player.Ping.DOAnchorPosX(0, 1).SetEase(Ease.Linear).OnComplete(() => GoForward(Player));

    }
    void WhoWin(SaucePlayer Player)
    {
        StartCoroutine(WaitTOWin(Player));
    }
    IEnumerator WaitTOWin(SaucePlayer Player)
    {
        yield return new WaitForSeconds(2);
        if (Player == Player1)
            GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
        else
            GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
    }
    IEnumerator LV3Sound()
    {
        
        while (Player1.LV == 3 || Player2.LV == 3)
        {
            
            //yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }
}
[System.Serializable]
public class SaucePlayer
{
    public RectTransform BarBack;
    public RectTransform Ping;
    public RectTransform SafeZone;
    public GameObject Apple;
    public GameObject Onion;
    public GameObject Sauce;
    public int LV = 0;
    public Tweener Tweener;
    public float[] Scores = new float[3];
    public Image img;
}