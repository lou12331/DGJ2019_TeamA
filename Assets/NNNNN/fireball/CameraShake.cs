using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public Transform cam;
    public float shakeAmp;
    public static CameraShake Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("shake")]
    public void Shake()
    {
        cam.DOShakePosition(shakeAmp);
    }
}
