using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    [SerializeField] private float speedBoost = 2f; // Amount of speed boost to apply to the player
    [SerializeField] private float duration = 5f; // Duration of the speed boost

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Apply speed boost to the player
            other.GetComponent<PlayerController>().IncreaseSpeed(speedBoost, duration);

            // Destroy the powerup
            Destroy(gameObject);
        }
    }
}
