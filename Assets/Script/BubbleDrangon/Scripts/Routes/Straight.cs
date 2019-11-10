using UnityEngine;
public class Straight : IRoute
{
    float speed=0.1f;
    public override Vector2 vec(double time)
    {
        return new Vector2(speed,0);
    }
}