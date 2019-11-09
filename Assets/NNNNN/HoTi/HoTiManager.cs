using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoTiManager : MonoBehaviour
{
    public List<HoTiBehavior> listA, listB;
    public int indexa=0, indexb=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SYS.input.key_confirm_a)
        {
            //Rotate
            listA[indexa].transform.localEulerAngles += new Vector3(0, 0, 1) * 90;
            Debug.Log("key_confirm_a");
        }
        if (SYS.input.key_cancel_a)
        {
            //change list
            indexa++;
            indexa %= listA.Count;
            Debug.Log("key_cancel_a");
        }
    }
}
