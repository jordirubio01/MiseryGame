using UnityEngine;

public class Coffin : MonoBehaviour
{
    public float FallSpeed = 5f;
    public float RotationSpeed = 180f;
    public Vector3 FinalPosition;
    public float FinalRotationZ = 0f; // 0 = horizontal, 90 = vertical
    
    private bool IsActivated = false;
    private bool IsMoving = false;
    private Vector3 StartPosition;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        StartPosition = transform.position;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
        // Set coffin as kinematic initially
        if (Rigidbody2D != null)
        {
            Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void Update()
    {
        if (IsMoving)
        {
            // Move coffin down to final position
            transform.position = Vector3.MoveTowards(transform.position, FinalPosition, FallSpeed * Time.deltaTime);

            // Rotate coffin to horizontal
            float currentRotation = transform.eulerAngles.z;
            float newRotation = Mathf.MoveTowardsAngle(currentRotation, FinalRotationZ, RotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, newRotation);

            // Check if reached destination
            if (Vector3.Distance(transform.position, FinalPosition) < 0.01f && 
                Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, FinalRotationZ)) < 1f)
            {
                IsMoving = false;
                transform.position = FinalPosition;
                transform.eulerAngles = new Vector3(0, 0, FinalRotationZ);
                
                // Make it solid platform
                if (Rigidbody2D != null)
                {
                    Rigidbody2D.bodyType = RigidbodyType2D.Static;
                }
                
                Debug.Log("Coffin in place!");
            }
        }
    }

    public void Activate()
    {
        if (!IsActivated)
        {
            IsActivated = true;
            IsMoving = true;
            Debug.Log("Coffin activated!");
        }
    }
}
