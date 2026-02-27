using UnityEngine;

public class PendulumHammer : MonoBehaviour
{
    public float SwingAngle = 45f;
    public float SwingSpeed = 2f;
    
    private float StartRotation;

    void Start()
    {
        StartRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        // Calculate pendulum swing using sine wave
        float angle = Mathf.Sin(Time.time * SwingSpeed) * SwingAngle;
        transform.eulerAngles = new Vector3(0, 0, StartRotation + angle);
    }
}
