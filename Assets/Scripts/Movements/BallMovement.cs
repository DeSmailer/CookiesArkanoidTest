using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rgb;

    private Vector3 direction;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float minVelocity;
    [SerializeField]
    private float maxVelocity;

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        direction = new Vector3(Random.Range(-1f,1f), 0, Random.Range(-1f, 1f));
    }

    private void Update()
    {
        speed += Time.deltaTime / 10;
    }

    private void FixedUpdate()
    {
        direction = new Vector3(Mathf.Clamp(direction.x, -0.95f, 0.95f), 0, Mathf.Clamp(direction.z, -1, 1));
        rgb.velocity = new Vector3(Mathf.Clamp(direction.x * speed, minVelocity, maxVelocity), 0, (Mathf.Clamp(direction.z * speed, minVelocity, maxVelocity)));
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }
}
