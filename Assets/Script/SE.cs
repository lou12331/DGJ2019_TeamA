﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinchLab
{
    public class SE : MonoBehaviour
    {
        public static SE instance;
        public GameObject applause;
        public GameObject count_count;
        public GameObject count_start;
        public GameObject jump;

        private void Awake()
        {
            instance = this;
        }
    }
}