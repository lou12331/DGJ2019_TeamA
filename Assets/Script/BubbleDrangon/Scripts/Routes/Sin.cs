using UnityEngine;
public class Sin : IRoute
{
    float magnitude=0.1f;
    float speed = 0.1f;
    public override Vector2 vec(double time)
    {
        return new Vector2(speed,magnitude*Mathf.Cos((float)time%Mathf.PI));
    }
}