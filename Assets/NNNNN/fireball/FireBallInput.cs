using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallInput : MonoBehaviour
{

    public Sprite[] sps;
    public bool p1;
    public GameObject fireball;
    public Transform fireballSpawn;
    public string tag;
    public SpriteRenderer renderer;
    public bool isLose;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p1)
        {
            if (SYS.input.key_cancel_a && renderer.sprite == sps[1])
            {
                renderer.sprite = sps[0];
                
            }
            if (SYS.input.key_confirm_a && renderer.sprite == sps[0])
            {
                renderer.sprite = sps[1];
                var go = Instantiate(fireball, fireballSpawn);
                go.SetActive(true);
            }
        }
        else
        {
            if (SYS.input.key_cancel_b && renderer.sprite == sps[1])
            {
                renderer.sprite = sps[0];
            }
            if (SYS.input.key_confirm_b && renderer.sprite == sps[0])
            {
                renderer.sprite = sps[1];
                var go = Instantiate(fireball, fireballSpawn);
                go.SetActive(true);
            }
        }
       
    }
}
