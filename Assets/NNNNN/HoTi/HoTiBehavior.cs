using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HoTiBehavior : MonoBehaviour
{
    public List<HoTiCollider> co;
    public bool canMove=true;
     
    // Start is called before the first frame update
    void Start()
    {
        var cc = GetComponentsInChildren<HoTiCollider>();
        co = cc.ToList();
    }

    // Update is called once per frame
    void Update()
    {
        bool allHit = true;
        foreach (var c in co)
        {

            allHit = c.IsHit && allHit;
        }
        if(allHit)
        {
            Debug.Log("YA");
            canMove = false;
        }
    }
}
