using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinchLab
{
    public class SoundObject : MonoBehaviour
    {
        private AudioSource audio_source;

        void Awake()
        {
            audio_source = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (!audio_source.isPlaying)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}