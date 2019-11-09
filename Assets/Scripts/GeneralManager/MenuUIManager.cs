using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuUIManager : MonoBehaviour
{
    public Image Cover;
    public List<GameObject> MenuItems;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeMenu(string MenuName)
    {
        foreach (GameObject obj in MenuItems)
        {
            obj.SetActive(obj.name == MenuName);
        }
    }
    public void CoverFadeIn()
    {
        Cover.DOFade(1, 0.5f).SetEase(Ease.InCubic).OnStart(() => { Cover.raycastTarget = true; });
    }
    public void CoverFadeOut()
    {
        Cover.DOFade(0, 0.5f).SetEase(Ease.InCubic).OnComplete(() => { Cover.raycastTarget = false; });
    }
}
