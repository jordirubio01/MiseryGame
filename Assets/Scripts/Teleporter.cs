using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public Transform DestinationPoint;
    public bool RequireKeyPress = true;

    [Header("Lives Based Teleport")]
    public bool DependsOnLives = false;
    public Transform Destination2Lives;
    public Transform Destination3Lives;

    private bool PlayerNearby = false;
    private GameObject PlayerObject;

    public RoomCameraFollow RoomCameraFollow; // For certain levels (house)
    public Image FadeImage;
    private float FadeInDuration = 0.2f;
    private float FadeOutDuration = 0.2f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
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
        else if (PlayerNearby && RequireKeyPress && Keyboard.current.qKey.wasPressedThisFrame)
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        StartCoroutine(TeleportWithFade());
    }

    IEnumerator TeleportWithFade()
    {
        if (FadeImage != null) yield return StartCoroutine(Fade(0, 1, FadeInDuration)); // Fade a negro

        Transform targetDestination = DestinationPoint;

        if (DependsOnLives)
        {
            if (GameManager.salut <= 1) targetDestination = DestinationPoint;
            else if (GameManager.salut <= 3) targetDestination = Destination2Lives;
            else targetDestination = Destination3Lives;
        }

        if (PlayerObject != null && targetDestination != null)
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

            PlayerObject.transform.position = targetDestination.position;

            Rigidbody2D rb = PlayerObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }

            if (RoomCameraFollow != null)
            {
                RoomCameraFollow.MoveTo(targetDestination.position);
            }

            Debug.Log("Teleported!");
        }
        if (FadeImage != null)
        {
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(Fade(1, 0, FadeOutDuration)); // Volver a la escena
        }
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float time = 0;
        UnityEngine.Color color = FadeImage.color;

        while (time<duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / duration);
            FadeImage.color = new UnityEngine.Color(color.r, color.g, color.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        FadeImage.color = new UnityEngine.Color(color.r, color.g, color.b, endAlpha);
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
