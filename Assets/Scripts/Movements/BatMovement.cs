using UnityEngine;

public class BatMovement : MonoBehaviour
{
    private Camera mainCamera;
    private float cameraDistance;

    [SerializeField]
    private Transform leftBorder;
    [SerializeField]
    private Transform rightBorder;

    private float halfWidth;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraDistance = Vector3.Distance(mainCamera.transform.position, transform.position);
        halfWidth = transform.localScale.x / 2;
    }

    void Update()
    {
        var mousePos2D = Input.mousePosition;

        Vector3 worldPoint = mainCamera.ScreenToWorldPoint(new Vector3(mousePos2D.x, mousePos2D.y, mainCamera.nearClipPlane + cameraDistance));

        transform.position = new Vector3
            (
            Mathf.Clamp(worldPoint.x, leftBorder.position.x + halfWidth, rightBorder.position.x - halfWidth),
            transform.position.y,
            transform.position.z
            );
    }
}