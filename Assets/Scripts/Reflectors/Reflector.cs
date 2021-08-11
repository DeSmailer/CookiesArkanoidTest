using UnityEngine;

public abstract class Reflector : MonoBehaviour
{
    public delegate void ReflectHandler();
    public event ReflectHandler Reflected;

    public abstract void Reflect(BallMovement ball, Collision collision);

    public void RaiseReflectedEvent()
    {
        Reflected?.Invoke();
    }

    public void OnCollisionEnter(Collision collision)
    {
        BallMovement ball = collision.gameObject.GetComponent<BallMovement>();
        if (ball != null)
        {
            Reflect(ball, collision);
        }
    }
}
