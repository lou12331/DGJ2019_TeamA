using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDR_BlockScript : MonoBehaviour
{
    public enum Player { Player1, Player2 };
    public Player Onwer;
    public float LifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LifeTime += Time.deltaTime;
        GetComponent<Rigidbody2D>().simulated = DDR_GameManager.Instance.GameStart;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Wall") return;
        if (LifeTime <= 0.1f)
        {
            
            if (Onwer == Player.Player1)
                DDR_GameManager.Instance.GameOver(Player.Player2);
            else
                DDR_GameManager.Instance.GameOver(Player.Player1);
        }
        else
        {
            if (Onwer == Player.Player1)
                DDR_GameManager.Instance.Player1HandleBlock = null;
            else
                DDR_GameManager.Instance.Player2HandleBlock = null;
        }
        DDR_GameManager.Instance.AudioSource.PlayOneShot(DDR_GameManager.Instance.CoinSound);
    }
}
