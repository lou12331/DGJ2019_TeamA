using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinchLab
{
    public class DancerB : MonoBehaviour
    {
        void Update()
        {
            if (DanceManager.instance.isOnGame)
            {
                if (InputManager.instance.GetAxisDownVerticalB())
                {
                    if (SYS.input.upKeyB && ExpectedKey == DanceManager.danceKey.up)
                        DanceManager.instance.moveNextB();
                    if (SYS.input.downKeyB && ExpectedKey == DanceManager.danceKey.down)
                        DanceManager.instance.moveNextB();
                }

                if (InputManager.instance.GetAxisDownHorizontalB())
                {
                    if (SYS.input.rightKeyB && ExpectedKey == DanceManager.danceKey.right)
                        DanceManager.instance.moveNextB();
                    if (SYS.input.leftKeyB && ExpectedKey == DanceManager.danceKey.left)
                        DanceManager.instance.moveNextB();
                }

                if (SYS.input.key_confirm_b && ExpectedKey == DanceManager.danceKey.A)
                    DanceManager.instance.moveNextB();
                if (SYS.input.key_cancel_b && ExpectedKey == DanceManager.danceKey.B)
                    DanceManager.instance.moveNextB();

            }
        }

        public DanceManager.danceKey ExpectedKey
        {
            get
            {
                return DanceManager.instance.expectedKeyB;
            }
        }

    }
}