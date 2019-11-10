using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{
    public Vector2 force;
    Rigidbody2D rig;
    public string tag;
    public bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(force);
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var c = collision.gameObject.GetComponent<FireBallBehavior>();
        var d = collision.gameObject.GetComponent<FireBallInput>();
        if (c)
        {
            if (c.tag != this.tag && !c.isHit)
            {
                c.isHit = true;
                Destroy(this.gameObject);
                CameraShake.Instance.Shake();
                Debug.Log("FireBall contact FireBall");
            }
            

        }

        if (d)
        {
            if (d.tag != this.tag)
            {
                d.GetComponent<Rigidbody2D>().AddForce(force);
                Debug.Log("FireBall contact Player");
                d.isLose = true;
                Destroy(this.gameObject);
            }

        }
    }
}
