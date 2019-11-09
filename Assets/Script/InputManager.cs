using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LinchLab
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance;
        public static bool axis_states_horizontal = false;
        public static bool axis_states_vertical = false;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            SYS.input.is_confirm_receivable = true;
            SYS.input.is_cancel_receivable = true;
            SYS.input.is_skip_receivable = true;
            SYS.input.is_jump_receivable = true;
        }

        void Update()
        {
            #region Input Detection
            SYS.input.axis_horizontal_a = Input.GetAxisRaw(SYS.input.horizontal_a);
            SYS.input.axis_vertical_a = Input.GetAxisRaw(SYS.input.vertical_a);
            SYS.input.axis_horizontal_b = Input.GetAxisRaw(SYS.input.horizontal_b);
            SYS.input.axis_vertical_b = Input.GetAxisRaw(SYS.input.vertical_b);


            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                SYS.input.key_confirm_a = true;
            }
            else
            {
                SYS.input.key_confirm_a = false;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SYS.input.key_cancel_a = true;
            }
            else
            {
                SYS.input.key_cancel_a = false;
            }

            if (Input.GetKeyDown(KeyCode.Comma))
            {
                SYS.input.key_confirm_b = true;
            }
            else
            {
                SYS.input.key_confirm_b = false;
            }

            if (Input.GetKeyDown(KeyCode.Period))
            {
                SYS.input.key_cancel_b = true;
            }
            else
            {
                SYS.input.key_cancel_b = false;
            }

            //SYS.input.key_aim = Input.GetButton(SYS.input.aim) ? true : false;
            //SYS.input.key_attack = Input.GetButton(SYS.input.attack) ? true : false;
            //SYS.input.key_run = Input.GetButton(SYS.input.run) ? true : false;
            //SYS.input.key_reload = Input.GetButton(SYS.input.reload) ? true : false;
            //SYS.input.key_serum = Input.GetButton(SYS.input.serum) ? true : false;
            //SYS.input.key_menu = Input.GetButton(SYS.input.menu) ? true : false;
            //SYS.input.key_skip = Input.GetButton(SYS.input.skip) ? true : false;
            #endregion
        }

        public bool GetAxisDownHorizontalA()
        {
            bool current_input_value = Input.GetAxisRaw(SYS.input.horizontal_a) == 0 ? false : true;
            if (current_input_value && axis_states_horizontal)
            {
                return false;
            }
            axis_states_horizontal = current_input_value;
            SYS.input.axis_horizontal_a = Input.GetAxisRaw(SYS.input.horizontal_a);
            return current_input_value;
        }

        public bool GetAxisDownVerticalA()
        {
            bool current_input_value = Input.GetAxisRaw(SYS.input.vertical_a) == 0 ? false : true;
            if (current_input_value && axis_states_vertical)
            {
                return false;
            }
            axis_states_vertical = current_input_value;
            SYS.input.axis_vertical_a = Input.GetAxisRaw(SYS.input.vertical_a);
            return current_input_value;
        }

        public bool GetAxisDownHorizontalB()
        {
            bool current_input_value = Input.GetAxisRaw(SYS.input.horizontal_b) == 0 ? false : true;
            if (current_input_value && axis_states_horizontal)
            {
                return false;
            }
            axis_states_horizontal = current_input_value;
            SYS.input.axis_horizontal_b = Input.GetAxisRaw(SYS.input.horizontal_b);
            return current_input_value;
        }

        public bool GetAxisDownVerticalB()
        {
            bool current_input_value = Input.GetAxisRaw(SYS.input.vertical_b) == 0 ? false : true;
            if (current_input_value && axis_states_vertical)
            {
                return false;
            }
            axis_states_vertical = current_input_value;
            SYS.input.axis_vertical_b = Input.GetAxisRaw(SYS.input.vertical_b);
            return current_input_value;
        }

        public void keyConfirmCD()
        {
            StartCoroutine(setConfirmCD());
        }

        public void keySkipCD()
        {
            StartCoroutine(setSkipCD());
        }

        public void keyConfirmCD(float _time)
        {
            StartCoroutine(setConfirmCD(_time));
        }

        private IEnumerator setConfirmCD()
        {
            SYS.input.is_confirm_receivable = false;
            yield return new WaitForSecondsRealtime(0.2f);
            SYS.input.is_confirm_receivable = true;
        }
        private IEnumerator setSkipCD()
        {
            SYS.input.is_skip_receivable = false;
            yield return new WaitForSecondsRealtime(0.05f);
            SYS.input.is_skip_receivable = true;
        }
        private IEnumerator setConfirmCD(float _time)
        {
            SYS.input.is_confirm_receivable = false;
            yield return new WaitForSecondsRealtime(_time);
            SYS.input.is_confirm_receivable = true;
        }

        public void keyJumpCD()
        {
            StartCoroutine(setJumpCD());
        }

        public void keyCancelCD()
        {
            StartCoroutine(setCancelCD());
        }

        private IEnumerator setCancelCD()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            SYS.input.is_confirm_receivable = true;
        }


        private IEnumerator setJumpCD()
        {
            SYS.input.is_jump_receivable = false;
            yield return new WaitForSecondsRealtime(1f);
            SYS.input.is_jump_receivable = true;
        }
    }
}
