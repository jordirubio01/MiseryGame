using UnityEngine;
using UnityEngine.InputSystem;

public class Teleporter : MonoBehaviour
{
    public Transform DestinationPoint;
    public bool RequireKeyPress = true;
    
    private bool PlayerNearby = false;
    private GameObject PlayerObject;

    public RoomCameraFollow RoomCameraFollow; // For certain levels (house)

    void Update()
    {
        /*if (PlayerNearby && RequireKeyPress && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TeleportPlayer();
        }*/
        if (!PlayerNearby) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseWorldPos =
                Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            LayerMask mask = LayerMask.GetMask("Interactable");
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos, mask);

            if (hit != null && hit.gameObject == gameObject)
            {
                TeleportPlayer();
            }
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
            if (RoomCameraFollow != null)
            {
                RoomCameraFollow.MoveTo(DestinationPoint.position);
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
                Debug.Log("Fes clic sobre l'objecte");
            }
            else
            {
                TeleportPlayer();
                if (RoomCameraFollow != null)
                {
                    RoomCameraFollow.MoveTo(DestinationPoint.position);
                }
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
