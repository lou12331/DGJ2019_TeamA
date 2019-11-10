using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sk1_p2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) transform.Rotate(0, 90, 0);
    }
}
