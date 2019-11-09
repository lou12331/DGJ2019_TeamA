using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYS : MonoBehaviour
{

    public static class input
    {
        public static string horizontal_a = "HorizontalA";
        public static string vertical_a = "VerticalA";

        public static string horizontal_b = "HorizontalB";
        public static string vertical_b = "VerticalB";

        public static string confirm_a = "ConfirmA";
        public static string confirm_b = "ConfirmB";

        public static string cancel_a = "CancelA";
        public static string cancel_b = "CancelB";

        public static string escape = "Escape";
        public static string skip = "Skip";

        public static string aim = "Aim";
        public static string attack = "Attack";
        public static string run = "Run";
        public static string reload = "Reload";
        public static string menu = "Menu";
        public static string serum = "Serum";

        public static bool rightKeyA
        {
            get
            {
                if (SYS.input.axis_horizontal_a > 0)
                    return true;
                return false;
            }
        }

        public static bool leftKeyA
        {
            get
            {
                if (SYS.input.axis_horizontal_a < 0)
                    return true;
                return false;
            }
        }

        public static bool upKeyA
        {
            get
            {
                if (SYS.input.axis_vertical_a > 0)
                    return true;
                return false;
            }
        }

        public static bool downKeyA
        {
            get
            {
                if (SYS.input.axis_vertical_a < 0)
                    return true;
                return false;
            }
        }


        public static bool rightKeyB
        {
            get
            {
                if (SYS.input.axis_horizontal_b > 0)
                    return true;
                return false;
            }
        }

        public static bool leftKeyB
        {
            get
            {
                if (SYS.input.axis_horizontal_b < 0)
                    return true;
                return false;
            }
        }

        public static bool upKeyB
        {
            get
            {
                if (SYS.input.axis_vertical_b > 0)
                    return true;
                return false;
            }
        }

        public static bool downKeyB
        {
            get
            {
                if (SYS.input.axis_vertical_b < 0)
                    return true;
                return false;
            }
        }

        public static float axis_horizontal_a
        {
            get { return PlayerPrefs.GetFloat("axis_horizontal_a"); }
            set { PlayerPrefs.SetFloat("axis_horizontal_a", value); }
        }

        public static float axis_vertical_a
        {
            get { return PlayerPrefs.GetFloat("axis_vertical_a"); }
            set { PlayerPrefs.SetFloat("axis_vertical_a", value); }
        }

        public static float axis_horizontal_b
        {
            get { return PlayerPrefs.GetFloat("axis_horizontal_b"); }
            set { PlayerPrefs.SetFloat("axis_horizontal_b", value); }
        }

        public static float axis_vertical_b
        {
            get { return PlayerPrefs.GetFloat("axis_vertical_b"); }
            set { PlayerPrefs.SetFloat("axis_vertical_b", value); }
        }

        public static bool key_confirm_a
        {
            get { return PlayerPrefs.GetInt("key_confirm_a") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_confirm_a", value == true ? 1 : 0); }
        }

        public static bool key_confirm_b
        {
            get { return PlayerPrefs.GetInt("key_confirm_b") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_confirm_b", value == true ? 1 : 0); }
        }


        public static bool is_jump_receivable
        {
            get { return PlayerPrefs.GetInt("is_jump_receivable") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("is_jump_receivable", value == true ? 1 : 0); }
        }
        public static bool is_confirm_receivable
        {
            get { return PlayerPrefs.GetInt("is_confirm_receivable") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("is_confirm_receivable", value == true ? 1 : 0); }
        }

        public static bool is_skip_receivable
        {
            get { return PlayerPrefs.GetInt("is_skip_receivable") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("is_skip_receivable", value == true ? 1 : 0); }
        }

        public static bool key_cancel_a
        {
            get { return PlayerPrefs.GetInt("key_cancel_a") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_cancel_a", value == true ? 1 : 0); }
        }


        public static bool key_cancel_b
        {
            get { return PlayerPrefs.GetInt("key_cancel_b") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_cancel_b", value == true ? 1 : 0); }
        }
        public static bool is_cancel_receivable
        {
            get { return PlayerPrefs.GetInt("is_cancel_receivable") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("is_cancel_receivable", value == true ? 1 : 0); }
        }

        public static bool key_aim
        {
            get { return PlayerPrefs.GetInt("key_aim") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_aim", value == true ? 1 : 0); }
        }

        public static bool key_attack
        {
            get { return PlayerPrefs.GetInt("key_attack") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_attack", value == true ? 1 : 0); }
        }

        public static bool key_run
        {
            get { return PlayerPrefs.GetInt("key_run") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_run", value == true ? 1 : 0); }
        }

        public static bool key_reload
        {
            get { return PlayerPrefs.GetInt("key_reload") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_reload", value == true ? 1 : 0); }
        }

        public static bool key_serum
        {
            get { return PlayerPrefs.GetInt("key_serum") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_serum", value == true ? 1 : 0); }
        }

        public static bool key_menu
        {
            get { return PlayerPrefs.GetInt("key_menu") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_menu", value == true ? 1 : 0); }
        }

        public static bool key_skip
        {
            get { return PlayerPrefs.GetInt("key_skip") == 1 ? true : false; }
            set { PlayerPrefs.SetInt("key_skip", value == true ? 1 : 0); }
        }
    }
}
