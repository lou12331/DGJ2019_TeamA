using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Party : MonoBehaviour
{

    PostProcessVolume ps;
    
    public PostProcessProfile file;
    private PostProcessProfile self;
    public int amp;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PostProcessVolume>();
        self = Instantiate(ps.sharedProfile);
        Debug.Log(self);

        ps.sharedProfile = self;
        
    }

    // Update is called once per frame
    void Update()
    {

        self.TryGetSettings(out ColorGrading setting);

        //ps.sharedProfile.TryGetSettings(out ColorGrading outSetting);
        if (setting)
        {
            setting.hueShift.value = Mathf.Sin(Time.time)* amp;
            Debug.Log("Party!");
        }
    }
}
