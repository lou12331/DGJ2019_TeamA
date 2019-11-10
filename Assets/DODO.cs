using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DODO : MonoBehaviour
{
    public GameObject go;
    public bool show;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHide()
    {
        show = !show;
        go.SetActive(show);
    }
}
