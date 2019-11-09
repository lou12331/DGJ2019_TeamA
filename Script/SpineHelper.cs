using UnityEngine;
using System.Collections;
using Spine.Unity;
using System.Collections.Generic;
using Spine;
using System;
using System.Linq;

public class SpineHelper : MonoBehaviour
{
    [Header("Status")]
    public bool is_activate = false;//For spine audio manager to call
    public List<AudioClip> audio_collection = new List<AudioClip>();
    public bool default_normal;
    private SkeletonAnimation skeletion_animation;
    private AudioSource aud;

    [Header("Status")]
    public bool show_black;
    [SpineSkin]
    public string darkness;
    [SpineSkin]
    public string normal;
    public Direciton direction;
    public enum Direciton
    {
        Right,
        Left,
    }
    public float original_scale_x;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        skeletion_animation = GetComponent<SkeletonAnimation>();
        original_scale_x = GetComponent<Transform>().localScale.x;
    }
    private void Start()
    {
        if (skeletion_animation == null)
            return;
        skeletion_animation.state.Event += SpineEventHandler;
    }

    /// <summary>
    /// Spine event handler will deal with Death event, generate Tonic and callback when the climax animation is finished. 
    /// </summary>
    /// <param name="entry"></param>
    /// <param name="e"></param>
    #region SPINE EVENT CONTROL
    void SpineEventHandler(Spine.TrackEntry entry, Spine.Event e)
    {
        //Play sound
        //if (is_activate)
        //{
        //    aud.Stop();
        //    List<AudioClip> aud_collection = audio_collection.Where(s => s.name.Contains("[" + e.Data.Name + "]")).ToList();
        //    if (aud_collection.Count != 0)
        //    {
        //        aud.clip = aud_collection.OrderBy(rand => Guid.NewGuid()).FirstOrDefault();
        //        aud.Play();
        //    }
        //}

        //Apply Event
        if (e.Data.Name.Equals("NAME"))
        {

        }
    }
    #endregion

    #region Animation Control
    public void setAnimation(string _animation_name)
    {
        if (skeletion_animation.AnimationName == _animation_name)
            return;
        skeletion_animation.state.SetAnimation(0, _animation_name, false);
        skeletion_animation.Update(0);
    }
    public void setAnimationLoop(string _animation_name)
    {
        if (skeletion_animation.AnimationName == _animation_name)
            return;
        skeletion_animation.state.SetAnimation(0, _animation_name, true);
        skeletion_animation.Update(0);
    }

    public void setAnimation(string _animation_name, bool _loop)
    {
        skeletion_animation.state.SetAnimation(0, _animation_name, _loop);
        skeletion_animation.Update(0);
    }

    #endregion

    #region Direction Control
    public void FlipModel()
    {
        float current_scale_x = transform.GetComponent<Transform>().localScale.x;
        float current_scale_y = transform.GetComponent<Transform>().localScale.y;
        float current_scale_z = transform.GetComponent<Transform>().localScale.z;

        transform.GetComponent<Transform>().localScale =
            new Vector3(-1 * current_scale_x, current_scale_y, current_scale_z);
    }

    public void FlipModelLeft()
    {
        float current_scale_y = transform.GetComponent<Transform>().localScale.y;
        float current_scale_z = transform.GetComponent<Transform>().localScale.z;

        if (direction == Direciton.Left && original_scale_x > 0 ||
            direction == Direciton.Right && original_scale_x < 0)
        {
            transform.GetComponent<Transform>().localScale =
             new Vector3(original_scale_x, current_scale_y, current_scale_z);
        }
        else
        {
            transform.GetComponent<Transform>().localScale =
                new Vector3((-1) * original_scale_x, current_scale_y, current_scale_z);
        }
    }
    public void FlipModelRight()
    {
        float current_scale_y = transform.GetComponent<Transform>().localScale.y;
        float current_scale_z = transform.GetComponent<Transform>().localScale.z;

        if (direction == Direciton.Right && original_scale_x > 0 ||
            direction == Direciton.Left && original_scale_x < 0)
        {
            transform.GetComponent<Transform>().localScale =
             new Vector3(original_scale_x, current_scale_y, current_scale_z);
        }
        else
        {
            transform.GetComponent<Transform>().localScale =
           new Vector3((-1) * original_scale_x, current_scale_y, current_scale_z);
        }
    }
    public void SetModelLocation(GameObject _ref_loction)
    {
        transform.position = new Vector3(_ref_loction.transform.position.x,
            transform.position.y, transform.position.z);
    }
    #endregion

    #region SLOTS
    public void SetSkin(string _skin_name)
    {
        skeletion_animation.skeleton.SetSkin(_skin_name);
    }
    #endregion

}
