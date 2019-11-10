using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;


public class Click : MonoBehaviour,IPointerEnterHandler,IPointerDownHandler
{
    public float ShakeDur = 0.05f;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(name);
        
        //transform.DOShakeRotation(ShakeDur);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Shake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shake()
    {
        transform.DOShakePosition(ShakeDur, 0.1f).OnComplete(() => Shake());
    }
}
