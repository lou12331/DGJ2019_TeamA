using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GeneralManager : MonoBehaviour
{
    public enum Player { Player1, Player2 };
    public static GeneralManager Instance;
    public List<string> SelectedCards;
    bool isFirst;
    public int Player1Score = 0;
    public int Player2Score = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenShowCard(GameObject Parent)
    {
        for (int i = 0; i < SelectedCards.Count; i++)
        {
            Parent.transform.GetChild(i).GetComponentInChildren<Text>().text = SelectedCards[i];
        }
    }

    public void SetThisRoundWinner(Player player)
    {
        switch (player)
        {
            case Player.Player1:
                Player1Score++;
                break;
            case Player.Player2:
                Player2Score++;
                break;
        }
    }
    public void LoadScene()
    {

    }
}

#if UNITY_EDITOR
    [CustomEditor(typeof(GeneralManager))]
    public class GeneralManagerInspector : Editor
    {
        GeneralManager manager;
        private void OnEnable()
        {
            manager = (GeneralManager)target;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

        }
    }
#endif