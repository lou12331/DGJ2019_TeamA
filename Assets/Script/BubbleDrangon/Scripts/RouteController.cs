using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(menuName="BubbleDragon/Create Route Controller")]
public class RouteController:ScriptableObject
{
    List<IRoute> routes=new List<IRoute>(){
        new Circle(),new Exp(),new Oc(),
        new Sin(),new XiaoLong()
    };
    public IRoute GetRandomAni()
    {
        if(routes.Count!=0)
        {
            int result=Random.Range(0,routes.Count);
            Debug.Log("result:"+result.ToString());
            return routes[result];
        }
            
        return null;
    }
}