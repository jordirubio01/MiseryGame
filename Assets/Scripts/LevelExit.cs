using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string NextSceneName = "Exploration"; // CAMBIAR AQUÍ para ir a otra escena
    
    private bool PlayerNearby = false;

    void Update()
    {
        /*if (PlayerNearby && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ExitLevel();
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
                ExitLevel();
            }
        }
    }

    void ExitLevel()
    {
        Debug.Log($"Loading scene: {NextSceneName}");
        SceneManager.LoadScene(NextSceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerNearby = true;
            Debug.Log("Press E to exit level");
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
