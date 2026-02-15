using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    public GameObject CoffinToActivate;
    public Sprite LeverUpSprite;
    public Sprite LeverDownSprite;
    
    private bool IsActivated = false;
    private bool PlayerNearby = false;
    private SpriteRenderer SpriteRenderer;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (PlayerNearby && !IsActivated && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ActivateLever();
        }
    }

    void ActivateLever()
    {
        IsActivated = true;
        
        // Change lever sprite to down position
        if (SpriteRenderer != null && LeverDownSprite != null)
        {
            SpriteRenderer.sprite = LeverDownSprite;
        }

        // Activate the coffin
        if (CoffinToActivate != null)
        {
            Coffin coffin = CoffinToActivate.GetComponent<Coffin>();
            if (coffin != null)
            {
                coffin.Activate();
            }
        }

        Debug.Log("Lever activated!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerNearby = true;
            Debug.Log("Press E to activate lever");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerNearby = false;
        }
    }
}
