using UnityEngine;
public class Oc : IRoute
{
    float magnitude=0.1f;
    float speed=0.1f;
    public override Vector2 vec(double time)
    {
        return new Vector2(speed,(((int)(time/2)%2==0)? -magnitude:magnitude));
    }
}