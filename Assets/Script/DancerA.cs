using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinchLab
{
    public class DancerA : MonoBehaviour
    {
        void Update()
        {
            if (DanceManager.instance.isOnGame)
            {
                if (SYS.input.upKeyA && ExpectedKey == DanceManager.danceKey.up)
                    DanceManager.instance.moveNextA();
                if (SYS.input.downKeyA && ExpectedKey == DanceManager.danceKey.down)
                    DanceManager.instance.moveNextA();
                if (SYS.input.rightKeyA && ExpectedKey == DanceManager.danceKey.right)
                    DanceManager.instance.moveNextA();
                if (SYS.input.leftKeyA && ExpectedKey == DanceManager.danceKey.left)
                    DanceManager.instance.moveNextA();


                if (SYS.input.key_confirm_a && ExpectedKey == DanceManager.danceKey.A)
                    DanceManager.instance.moveNextA();
                if (SYS.input.key_cancel_a && ExpectedKey == DanceManager.danceKey.B)
                    DanceManager.instance.moveNextA();

            }
        }

        public DanceManager.danceKey ExpectedKey
        {
            get
            {
                return DanceManager.instance.expectedKeyA;
            }
        }

    }
}