using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    public RainbowTag tag;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        tag = GetComponent<RainbowTag>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tag)
        {
            if(tag.HasOwner)
            {
                var p = tag.HasOwner.transform.position;
                transform.position = Vector3.Lerp(transform.position, p, speed);
            }
        }
    }
}
