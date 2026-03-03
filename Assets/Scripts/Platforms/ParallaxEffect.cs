using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Tooltip("0 = Stays in place (like the ground). 1 = Follows the camera (very distant background).")]
    [Range(0f, 1f)]
    public float parallaxSpeed;

    private float length;
    private float startPosX;
    private Transform cam;

    void Start()
    {
        // Automatically finds your Main Camera
        cam = Camera.main.transform;
        
        // Gets the starting X position and the exact width of your sprite
        startPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x;
    }

    void Update() 
    {
        // Calculate how far the camera has moved relative to the background
        float temp = (cam.position.x * (1 - parallaxSpeed));
        float distance = (cam.position.x * parallaxSpeed);

        // Move the background on the X axis
        transform.position = new Vector3(startPosX + distance, transform.position.y, transform.position.z);

        // THE MAGIC: If the camera passed the background's right edge, loop it to the right!
        if (temp > startPosX + length)
        {
            startPosX += length;
        }
        // If the camera passed the background's left edge, loop it to the left!
        else if (temp < startPosX - length)
        {
            startPosX -= length;
        }
    }
}