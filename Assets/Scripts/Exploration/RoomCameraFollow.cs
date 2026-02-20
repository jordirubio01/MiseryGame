using UnityEngine;
using UnityEngine.UIElements;

public class RoomCameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.1f;
    public bool follow = false;
    private Vector3 targetPosition;

    void LateUpdate()
    {
        if (follow)
        {
            Vector3 desiredPosition = (targetPosition != Vector3.zero) ? targetPosition : player.position;
            desiredPosition.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }

    public void MoveTo(Vector3 newPosition)
    {
        Vector3 newPos = newPosition;
        newPos.z = transform.position.z; // Mantain depth
        transform.position = newPos;
    }

    public void ResetTarget() => targetPosition = Vector3.zero;
}
