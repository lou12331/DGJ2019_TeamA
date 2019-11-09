using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DanceManager;

public class DancerA : MonoBehaviour
{
    void Update()
    {
        if (DanceManager.instance.isOnGame)
        {
            if (SYS.input.upKeyA && ExpectedKey == danceKey.up)
                DanceManager.instance.moveNextA();
            if (SYS.input.downKeyA && ExpectedKey == danceKey.down)
                DanceManager.instance.moveNextA();
            if (SYS.input.rightKeyA && ExpectedKey == danceKey.right)
                DanceManager.instance.moveNextA();
            if (SYS.input.leftKeyA && ExpectedKey == danceKey.left)
                DanceManager.instance.moveNextA();


            if (SYS.input.key_confirm_a && ExpectedKey == danceKey.A)
                DanceManager.instance.moveNextA();
            if (SYS.input.key_cancel_a && ExpectedKey == danceKey.B)
                DanceManager.instance.moveNextA();

        }
    }

    public danceKey ExpectedKey
    {
        get
        {
            return DanceManager.instance.expectedKeyA;
        }
    }

}
