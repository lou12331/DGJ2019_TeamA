using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerKey : MonoBehaviour
{
    public string password;
    public bool findDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var c = collision.GetComponent<FlowerDoor>();
        if(c.password == this.password)
        {
            findDoor = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if(Input.GetKey(PlayerKeyA))
       //{
       //    this.transform.localEulerAngles += new Vector3(0,0,1) *deltaAngle;
       //}
       //if (Input.GetKey(PlayerKeyB))
       //{
       //    this.transform.localEulerAngles -= new Vector3(0, 0, 1) * deltaAngle;
       //}


    }
}
