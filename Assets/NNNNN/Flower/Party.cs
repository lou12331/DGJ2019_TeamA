using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Party : MonoBehaviour
{

    PostProcessVolume ps;
    ColorGrading outSetting;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PostProcessVolume>();
        ps.sharedProfile.TryGetSettings<ColorGrading>(out ColorGrading outSetting);
    }

    // Update is called once per frame
    void Update()
    {
        if(outSetting)
        {
            outSetting.hueShift.value = Random.Range(0, 1);
        }
    }
}
