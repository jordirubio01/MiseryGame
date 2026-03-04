using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{
    public bool RequireKeyPress = true;

    public string description;
    public Sprite objectSprite;

    bool playerNear = false;

    void Update()
    {
        if (!playerNear) return;

        if (RequireKeyPress && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseWorldPos =
                Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            LayerMask mask = LayerMask.GetMask("Interactable");
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos, mask);

            if (hit != null && hit.gameObject == gameObject)
            {
                ShowDescription();
            }
        }
        else if (RequireKeyPress && Keyboard.current.qKey.wasPressedThisFrame)
        {
            ShowDescription();
        }
    }

    void OnMouseDown()
    {
        if (playerNear)
        {
            ShowDescription();
        }
    }

    void ShowDescription()
    {
        ObjectDescriptionUI.Instance.Show(objectSprite, description);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}