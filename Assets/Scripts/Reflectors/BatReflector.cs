using UnityEngine;

public class BatReflector : Reflector
{
    private float halfWidth;

    private const float reflectAngle = 0.5f;

    private void Start()
    {
        halfWidth = transform.localScale.x / 2;
    }

    public override void Reflect(BallMovement ball, Collision collision)
    {
        float distanceToCenter = Mathf.Abs((collision.GetContact(0).point.x - transform.position.x) / halfWidth);

        Vector3 currentDirection = ball.GetDirection();

        if (currentDirection.x > 0)
        {
            currentDirection.x += GetDeltaX(distanceToCenter);
        }
        else
        {
            currentDirection.x -= GetDeltaX(distanceToCenter);
        }

        if (currentDirection.z > 0)
        {
            currentDirection.z -= GetDeltaZ(currentDirection.z, distanceToCenter);
        }
        else
        {
            currentDirection.z += GetDeltaZ(currentDirection.z, distanceToCenter);
        }

        currentDirection = Vector3.Reflect(currentDirection, collision.GetContact(0).normal);

        ball.SetDirection(currentDirection);
        RaiseReflectedEvent();
    }

    private float GetDeltaX(float distanceToCenter)
    {
        return reflectAngle * distanceToCenter;
    }

    private float GetDeltaZ(float currentDirectionZ, float distanceToCenter)
    {
        return reflectAngle / 3 * distanceToCenter + Mathf.Abs(currentDirectionZ) / 8;
    }
}
