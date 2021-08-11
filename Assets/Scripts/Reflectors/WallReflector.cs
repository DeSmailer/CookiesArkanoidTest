using UnityEngine;

public class WallReflector : Reflector
{
    public override void Reflect(BallMovement ball, Collision collision)
    {
        ball.SetDirection(Vector3.Reflect(ball.GetDirection(), collision.GetContact(0).normal));
        RaiseReflectedEvent();
    }
}
