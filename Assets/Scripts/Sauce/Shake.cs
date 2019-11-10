using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
    public float ShakeDur = 0.05f;
    public Vector3 Stregth = new Vector3(0.5f, 1, 0);
    Tweener tweener;
    // Start is called before the first frame update
    void Start()
    {
        ShakeShake();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShakeShake()
    {
        tweener = transform.DOShakePosition(ShakeDur, Stregth).OnComplete(() => ShakeShake());
    }
    public void StopShake()
    {
        tweener.Kill();
    }
    
}
