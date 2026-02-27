using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float SmoothSpeed = 0.125f;
    public Vector3 Offset = new Vector3(0f, 0f, -10f);
    public bool FollowX = true;
    public bool FollowY = true;

    private void Start()
    {
        // Auto-find Paul if target not set
        if (Target == null)
        {
            GameObject paul = GameObject.Find("Paul");
            if (paul != null)
            {
                Target = paul.transform;
                Debug.Log("CameraFollow: Paul found and set as target");
            }
            else
            {
                Debug.LogWarning("CameraFollow: Paul not found in scene");
            }
        }

        // Ensure camera has correct Z position
        if (transform.position.z > -5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }

    private void LateUpdate()
    {
        if (Target == null)
            return;

        Vector3 desiredPosition = Target.position + Offset;

        // Apply smoothing
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);

        // Choose which axes to follow
        float newX = FollowX ? smoothedPosition.x : transform.position.x;
        float newY = FollowY ? smoothedPosition.y : transform.position.y;
        float newZ = smoothedPosition.z;

        transform.position = new Vector3(newX, newY, newZ);
    }
}
