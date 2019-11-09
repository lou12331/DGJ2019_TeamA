using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] RouteController routeController;
    public string detectTag;
    IRoute route;
    public void SetNormal()
    {
        route=new Straight();
    }
    // Start is called before the first frame update
    void Start()
    {
        route=routeController.GetRandomAni();
        Destroy(gameObject,5);
    }
    double time=0;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(route.vec(time));
        time+=Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag==detectTag)
            col.gameObject.GetComponent<Player>().Trapped();
    }
}
