using UnityEngine;
using UnityEngine.SceneManagement; // Required if reloading the scene

public class DeathPlane : MonoBehaviour
{
    [Tooltip("Leave empty to reload the current scene on death")]
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the zone is the Player
        if (other.CompareTag("Player"))
        {
            if (respawnPoint != null)
            {
                // Option A: Teleport player to a checkpoint
                other.transform.position = respawnPoint.position;

                // Reset falling momentum so they don't keep falling fast
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                }
            }
            else
            {
                // Option B: Reload the entire level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}