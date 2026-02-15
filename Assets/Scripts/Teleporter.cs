using UnityEngine;
using UnityEngine.InputSystem;

public class Teleporter : MonoBehaviour
{
    public Transform DestinationPoint;
    public bool RequireKeyPress = true;
    
    private bool PlayerNearby = false;
    private GameObject PlayerObject;

    void Update()
    {
        if (PlayerNearby && RequireKeyPress && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        if (PlayerObject != null && DestinationPoint != null)
        {
            PlayerObject.transform.position = DestinationPoint.position;
            
            // Reset velocity to avoid bugs
            Rigidbody2D rb = PlayerObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
            
            Debug.Log("Teleported!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerNearby = true;
            PlayerObject = collision.gameObject;
            
            if (RequireKeyPress)
            {
                Debug.Log("Press E to teleport");
            }
            else
            {
                TeleportPlayer();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerNearby = false;
            PlayerObject = null;
        }
    }
}
