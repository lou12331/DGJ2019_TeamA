using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HoTiBehavior : MonoBehaviour
{
    public List<HoTiCollider> co;
    public bool canMove=true;
    public GameObject SHOW;
     
    // Start is called before the first frame update
    void Start()
    {
        var cc = GetComponentsInChildren<HoTiCollider>();
        co = cc.ToList();
        SHOW = transform.Find("777").gameObject;
        SHOW.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        bool allHit = true;
        foreach (var c in co)
        {
            allHit = c.IsHit && allHit;
        }
        if(allHit && co != null && co.Count != 0)
        {
            Debug.Log(Mathf.RoundToInt(transform.eulerAngles.z));
            if(Mathf.RoundToInt(transform.eulerAngles.z % 360) == 0)
            {

                this.canMove = false;
                Instantiate(Resources.Load("222"));
            }

            
        }


    }
}
