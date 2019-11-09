using UnityEngine;
public class Circle : IRoute
{
    float magnitude=0.1f;
    float speed=0.1f;
    public override Vector2 vec(double time)
    {
        return new Vector2(speed-magnitude*Mathf.Sin((float)time%Mathf.PI),magnitude*Mathf.Cos((float)time%Mathf.PI));
    }
}