﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sk3_p2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) transform.Rotate(0, 90, 0);
    }
}
