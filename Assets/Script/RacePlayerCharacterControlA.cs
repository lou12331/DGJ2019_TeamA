using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinchLab
{
    public class RacePlayerCharacterControlA : MonoBehaviour
    {
        private Rigidbody2D rigidbody;
        public float speed = 10f;
        public float jump = 30f;
        private bool allowJump = true;
        private Animator ani;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        void Update()
        {
            if (InputManager.instance.GetAxisDownVerticalA() && allowJump)
            {
                StartCoroutine(unlockJump());
                rigidbody.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
            }

        }

        IEnumerator unlockJump()
        {
            ani.SetBool("isRunning", true);
            allowJump = false;
            Instantiate(SE.instance.jump);
            yield return new WaitForSeconds(1.2f);
            allowJump = true;
            ani.SetBool("isRunning", false);
        }

        void FixedUpdate()
        {
            Vector3 move = new Vector3(SYS.input.axis_horizontal_a * speed, rigidbody.velocity.y, 0f);
            rigidbody.velocity = move;
        }
    }
}

