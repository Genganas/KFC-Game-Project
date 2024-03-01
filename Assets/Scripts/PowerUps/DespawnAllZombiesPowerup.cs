using UnityEngine;

public class DespawnAllZombiesPowerup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Despawn all zombies in the scene
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                Destroy(zombie);
            }

            // Destroy the powerup
            Destroy(gameObject);
        }
    }
}

