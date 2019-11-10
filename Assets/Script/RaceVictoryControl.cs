using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinchLab
{
    public class RaceVictoryControl : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "PlayerA")
            {
                RaceManager.instance.setGameEnd("Player 1 Wins!");
                Debug.Log("PlayerA Wins");
                Instantiate(SE.instance.applause);
            }
            else if (collider.tag == "PlayerB")
            {
                RaceManager.instance.setGameEnd("Player B Wins!");
                Debug.Log("PlayerB Wins");
                Instantiate(SE.instance.applause);
            }
        }
    }
}