using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HutongGames.PlayMaker;
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
    public int nowPlayingIndex = 0;

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
        if (Input.GetKeyDown(KeyCode.O))
        {
            GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
        }
    }

    public void OpenShowCard(GameObject Parent)
    {
        for (int i = 0; i < SelectedCards.Count; i++)
        {
            //Parent.transform.GetChild(i).GetComponentInChildren<Text>().text = SelectedCards[i];
            MiniGameSceneManager miniGameScene = GetComponent<MiniGameSceneManager>();
            Parent.transform.GetChild(i).GetComponent<Image>().sprite = miniGameScene.GameCardSprites[miniGameScene.MiniGameScenes.FindIndex(x => x == SelectedCards[i])];
        }
    }
    public void OpenShowSingleCard(Image Card)
    {
        MiniGameSceneManager miniGameScene = GetComponent<MiniGameSceneManager>();
        int id = miniGameScene.MiniGameScenes.FindIndex(x => x == SelectedCards[nowPlayingIndex]);
        Card.sprite = miniGameScene.GameCardSprites[id];
        Card.transform.Find("CardName").GetComponent<Text>().text = miniGameScene.GameCardNames[id];
        Card.transform.Find("CardDescription").GetComponent<Text>().text = miniGameScene.GameCardDescriptions[id];
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
        GetComponent<PlayMakerFSM>().SendEvent("Next");
        nowPlayingIndex++;
    }
    public void LetPlayMiniGame()
    {
        LoadScene(SelectedCards[nowPlayingIndex]);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(loadScene(sceneName));
    }
    IEnumerator loadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        yield break;
    }
    public void MiniGameOver()
    {
        MiniGameSceneManager miniGameSceneManager = GetComponent<MiniGameSceneManager>();
        foreach (string item in miniGameSceneManager.MiniGameScenes)
        {
            if (SceneManager.GetSceneByName(item).isLoaded)
            {
                UnloadScene(item);
            }
        }
        
    }
    public void UnloadScene(string sceneName)
    {
        StartCoroutine(unloadScene(sceneName));
    }
    IEnumerator unloadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.UnloadSceneAsync(sceneName);

        yield break;
    }
    public void ExitGame()
    {
        Application.Quit();
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