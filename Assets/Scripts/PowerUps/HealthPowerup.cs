using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    [SerializeField] private int healthRestore = 1; // Amount of health to restore to the player

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Restore health to the player
            other.GetComponent<Player>().IncreaseHealth(healthRestore);

            // Destroy the powerup
            Destroy(gameObject);
        }
    }
}
