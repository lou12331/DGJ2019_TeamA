using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1flag : MonoBehaviour
{
    public p2flag p2;
    public bool IsGameEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameEnd == true) EndGame();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.Rotate(0, 0, -3);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.Rotate(0, 0, -3);
        if (Input.GetKeyDown(KeyCode.Space)) Time.timeScale = 0;

        if (transform.eulerAngles.z > 90)
            transform.Rotate(0, 0, -0.5f);
        if (transform.eulerAngles.z < 90 || transform.eulerAngles.z >0)
            transform.Rotate(0, 0, 0.5f);
        //Debug.Log(transform.localEulerAngles.z);
        if (transform.localEulerAngles.z > 300) 
        {
            Debug.Log("P1 win");
            this.enabled = false;
            IsGameEnd = true;
            p2.IsGameEnd = true;

        }
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z % 180);
        
            
    }
    public void EndGame()
    {
        //show ui
        //
    }
}
