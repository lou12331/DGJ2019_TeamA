using UnityEngine;
public class XiaoLong : IRoute
{
    float magnitude=0.1f;
    float speed=0.1f;
    public override Vector2 vec(double time)
    {
        return new Vector2(speed,magnitude*3.0f/2*Mathf.Exp(1)*Mathf.Sqrt((float)time));
    }
}