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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1)
        {
            if (SYS.input.key_confirm_a || SYS.input.key_cancel_a)
            {
                var go = Instantiate(fireball, fireballSpawn);
                go.SetActive(true);
            }
        }
        else
        {
            if (SYS.input.key_confirm_b || SYS.input.key_cancel_b)
            {
                var go = Instantiate(fireball, fireballSpawn);
                go.SetActive(true);
            }
        }
       
    }
}
