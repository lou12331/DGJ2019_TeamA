using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRecorder : MonoBehaviour
{
    [SerializeField] private double QueueClearTime=4;
    [SerializeField]private List<KeyCode> cur=new List<KeyCode>();
    [SerializeField]KeyCode[] SpecialKeySet=new KeyCode[10]{KeyCode.UpArrow,KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.DownArrow,
                                                   KeyCode.LeftArrow,KeyCode.RightArrow,KeyCode.LeftArrow,KeyCode.RightArrow,
                                                   KeyCode.B,KeyCode.A};
    bool blocked=false;
    IEnumerator ClearQueue()
    {
        if(blocked==true)
            yield return null;
        
        blocked=true;
        yield return new WaitForSeconds((float)QueueClearTime);
        cur.Clear();
        blocked=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void scankey()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
            cur.Add(KeyCode.UpArrow);
        if(Input.GetKeyDown(KeyCode.DownArrow))
            cur.Add(KeyCode.DownArrow);
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            cur.Add(KeyCode.LeftArrow);
        if(Input.GetKeyDown(KeyCode.RightArrow))
            cur.Add(KeyCode.RightArrow);


        if(Input.GetKeyDown(KeyCode.A))
            cur.Add(KeyCode.A);
        if(Input.GetKeyDown(KeyCode.B))
            cur.Add(KeyCode.B);
        

        if(Input.GetKeyDown(KeyCode.W))
            cur.Add(KeyCode.W);
        if(Input.GetKeyDown(KeyCode.S))
            cur.Add(KeyCode.S);
    }
    public bool specialskill()
    {
        for(int u=10;cur.Count>=u;cur.RemoveAt(0))
        {
            bool flag=true;
            for(int i=0;i<=10;++i)
                if(cur.Count>i && SpecialKeySet[i]!=cur[i])
                {
                    flag=false;
                    break;
                }
            if(flag==true)
            {
                Debug.Log("special Active!!");
                cur.Clear();
                return true;
            }
                
            else
                continue;
        }
            
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if(blocked==false)
            StartCoroutine(ClearQueue());
        scankey();

    }
}
