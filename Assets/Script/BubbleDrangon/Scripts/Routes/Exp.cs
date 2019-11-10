using UnityEngine;
public class Exp : IRoute
{
    float magnitude=0.1f;
    float speed=0.1f;
    public override Vector2 vec(double time)
    {
        return new Vector2(speed,magnitude*Mathf.Exp((float)time*magnitude));
    }
}