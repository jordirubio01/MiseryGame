using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{
    public enum UnlockType
    {
        None,
        Idea,
        Pista
    }

    public UnlockType unlockType = UnlockType.None;
    bool unlocked = false;

    public GameManager.Idea idea;
    public GameManager.Pista pista;

    public bool RequireKeyPress = true;
    public bool NextLevelButton = false;

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
        // Activar/desactivar botó de següent nivell
        if (ObjectDescriptionUI.Instance.NextLevelButton != null)
            ObjectDescriptionUI.Instance.NextLevelButton.gameObject.SetActive(NextLevelButton);

        Unlock();
    }

    void Unlock()
    {
        if (unlocked) return;

        if (unlockType == UnlockType.Idea)
        {
            GameManager.idees[idea] = true;
            Debug.Log("Idea desbloquejada: " + idea);
        }

        if (unlockType == UnlockType.Pista)
        {
            GameManager.pistes[pista] = true;
            Debug.Log("Pista desbloquejada: " + pista);
        }
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