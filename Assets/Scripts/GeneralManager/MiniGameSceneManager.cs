using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MiniGameSceneManager : MonoBehaviour
{
    public List<string> MiniGameScenes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            string[] result = GiveMeRandomSceneArray(3, new List<string> { "a", "b" });
            foreach (string item in result)
            {
                Debug.Log(item);
            }
        }
            
    }
    public string[] GiveMeRandomSceneArray(int count, List<string> except)
    {
        List<string> scenes = new List<string>();
        foreach (string scene in MiniGameScenes)
        {
            if (except.Exists(x => x.Contains(scene)))
            {
                continue;
            }
            scenes.Add(scene);
        }
        List<string> result = new List<string>();
        for (int i = 0; i < count; i++)
        {
            int r = Random.Range(0, scenes.Count);
            result.Add(scenes[r]);
            scenes.RemoveAt(r);
        }
        return result.ToArray();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(MiniGameSceneManager))]
public class MiniGameSceneManagerInspector : Editor
{
    MiniGameSceneManager manager;
    private void OnEnable()
    {
        manager = (MiniGameSceneManager)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
#endif
