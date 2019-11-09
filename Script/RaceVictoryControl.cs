using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceVictoryControl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PlayerA")
            Debug.Log("PlayerA Wins");
        else if (collider.tag == "PlayerB")
            Debug.Log("PlayerB Wins");
    }
}
