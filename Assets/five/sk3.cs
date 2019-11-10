using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sk3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) transform.Rotate(0, 90, 0);
    }
}
