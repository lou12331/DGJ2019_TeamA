using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PandaBehavior : MonoBehaviour
{

    public List<Sprite> sps;
    public SpriteRenderer mySp;
    public Image bamboo;
    public float bambooSpeed;
    private bool isCo;
    // Start is called before the first frame update
    void Start()
    {
        mySp = GetComponent<SpriteRenderer>();
        if(bamboo)bamboo.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("ResetPanda")]
    public void SetNormal()
    {
        mySp.sprite = sps[0];
    }
    [ContextMenu("SetAnswerPanda")]
    public void SetWin()
    {
        mySp.sprite = sps[1];
        GetComponent<PandaCollider>().isAnswer = true;
    }
    [ContextMenu("testWin")]
    public void SetWin2()
    {
        mySp.sprite = sps[2];
    }

    public IEnumerator Anim()
    {
        isCo = true;
        SetWin2();
        transform.DOShakePosition(0.5f, 1);
        yield return new WaitForSeconds(1);
        while(isCo)
        {
            bamboo.fillAmount = Mathf.Lerp(bamboo.fillAmount, 1, bambooSpeed);

            if (Mathf.Approximately(bamboo.fillAmount, 1))
            {
                isCo = false;
            }
            Debug.Log(bamboo.fillAmount);
            yield return null;
        }
        
    }
}
