using UnityEngine;

public class HammerHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PaulMovement paul = collision.GetComponent<PaulMovement>();
            if (paul != null)
            {
                paul.Respawn();
                Debug.Log("Hit by hammer! Respawning...");
            }
        }
    }
}
