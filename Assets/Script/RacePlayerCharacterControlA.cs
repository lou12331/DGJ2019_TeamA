﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinchLab
{
    public class RacePlayerCharacterControlA : MonoBehaviour
    {
        private Rigidbody2D rigidbody;
        public float speed = 10f;
        public float jump = 30f;
        private SpineHelper spine;
        private bool allowJump = true;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            spine = GetComponent<SpineHelper>();
        }

        void Update()
        {
            if (SYS.input.key_confirm_a)
            {
                Debug.Log("CONFIRM");
            }

            //if (SYS.input.rightKeyA)
            //{
            //    spine.FlipModelRight();
            //}
            //if (SYS.input.leftKeyA)
            //{
            //    spine.FlipModelLeft();
            //}


            if (SYS.input.rightKeyA || SYS.input.leftKeyA)
            {
                spine.setAnimationLoop("Running");
            }
            else
            {
                spine.setAnimation("Idle");
            }

            if (InputManager.instance.GetAxisDownVerticalA() && allowJump)
            {
                StartCoroutine(unlockJump());
                rigidbody.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
            }

            if (isForceBack)
            {
                StartCoroutine(unlockForceBack());
                rigidbody.AddForce(Vector3.left * jump, ForceMode2D.Impulse);
            }
        }

        private bool isForceBack = false;

        IEnumerator unlockForceBack()
        {
            yield return new WaitForSeconds(0.1f);
            isForceBack = false;
        }

        IEnumerator unlockJump()
        {
            allowJump = false;
            yield return new WaitForSeconds(1.5f);
            allowJump = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Barrier")
            {
                isForceBack = true;
            }
        }

        void FixedUpdate()
        {
            if (!isForceBack)
            {
                Vector3 move = new Vector3(SYS.input.axis_horizontal_a * speed, rigidbody.velocity.y, 0f);
                rigidbody.velocity = move;
            }
        }
    }
}

