using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p2flag : MonoBehaviour
{
    public AudioSource audio;
    public p1flag p1;
    public bool IsGameEnd = false;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameEnd == true) EndGame();
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.Rotate(0, 0, -3);
            //AudioClip audioClip = Resources.Load("retro_jump_bounce_12") as AudioClip;
            //audio.Play();
            Instantiate(Resources.Load("yes"));
        }


        if (Input.GetKeyDown(KeyCode.D))
        { 
            transform.Rotate(0, 0, -3);
            //audio.Play();
            Instantiate(Resources.Load("yes"));
        }
            
        if (Input.GetKeyDown(KeyCode.Space)) Time.timeScale = 0;

        if (transform.eulerAngles.z > 90)
            transform.Rotate(0, 0, -10f * Time.deltaTime);
        if (transform.eulerAngles.z < 90 || transform.eulerAngles.z > 0)
            transform.Rotate(0, 0, 10f * Time.deltaTime);
        //Debug.Log(transform.localEulerAngles.z);
        if (transform.localEulerAngles.z > 300)
        {
            Debug.Log("P2 win");
            Instantiate(Resources.Load("YAYA"));
            this.enabled = false;
            IsGameEnd = true;
            p1.IsGameEnd = true;
            text.text = "P1 Win";
            if (GeneralManager.Instance) GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
        }
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z % 180);


    }
    public void EndGame()
    {
        //show ui
        //
    }
}
