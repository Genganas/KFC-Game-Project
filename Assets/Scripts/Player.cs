using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;
    public int lives = 5; // Number of lives
    public Image[] heartImages; // Array of heart image UI elements
    public GameObject loseObject;

    public GameObject speedPowerupEffectPrefab;
    public GameObject healthPowerupEffectPrefab;
    public GameObject despawnZombiesPowerupEffectPrefab;
    public Transform powerupEffectSpawnPoint;

    public AudioClip speedPowerupSound; // Sound for the speed power-up
    public AudioClip healthPowerupSound; // Sound for the health power-up
    public AudioClip despawnZombiesPowerupSound; // Sound for the despawn zombies power-up
    private AudioSource audioSource; // Reference to the AudioSource component


    private Rigidbody rb;
    private float currentSpeedBoost = 1f; // Current speed boost multiplier
    private float speedBoostDuration = 0f; // Remaining duration of speed boost

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (speedBoostDuration > 0f)
        {
            speedBoostDuration -= Time.deltaTime;
            if (speedBoostDuration <= 0f)
            {
                currentSpeedBoost = 1f; // Reset speed boost to normal
            }
        }

        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            lives--; // Decrement lives when colliding with a zombie

            // Deactivate the corresponding heart image
            heartImages[lives].enabled = false;

            if (lives <= 0) // Game over when lives reach zero
            {
                // Freeze the game
                Time.timeScale = 0f;

                // Display the "Lose" object
                loseObject.SetActive(true);
            }
        }
        else
       if (other.tag == "SpeedPowerup")
        {
            // Spawn the speed powerup effect at the serialized spawn point
            GameObject effectInstance = Instantiate(speedPowerupEffectPrefab, powerupEffectSpawnPoint.position, transform.rotation);
            effectInstance.transform.SetParent(powerupEffectSpawnPoint);

            PlayPowerupSound(speedPowerupSound);

            // Destroy the powerup after spawning the effect
            Destroy(other.gameObject);

            // Start the coroutine to destroy the effect after the delay
            StartCoroutine(DisablePowerupEffectAfterDelay(effectInstance, 2f));
        }
        else if (other.tag == "HealthPowerup")
        {
            // Spawn the health powerup effect at the serialized spawn point
            GameObject effectInstance = Instantiate(healthPowerupEffectPrefab, powerupEffectSpawnPoint.position, transform.rotation);
            effectInstance.transform.SetParent(powerupEffectSpawnPoint); // Set the effect as a child of the spawn point

            PlayPowerupSound(healthPowerupSound); // Play sound for the health power-up

            // Restore 2 health points
            IncreaseHealth(2);

            // Destroy the powerup after spawning the effect
            Destroy(other.gameObject);

            // Start the coroutine to destroy the effect after the delay
            StartCoroutine(DisablePowerupEffectAfterDelay(effectInstance, 2f));
        }
        else if (other.tag == "DespawnAllZombiesPowerup")
        {
            // Spawn the despawn zombies powerup effect at the serialized spawn point
            GameObject effectInstance = Instantiate(despawnZombiesPowerupEffectPrefab, powerupEffectSpawnPoint.position, transform.rotation);
            effectInstance.transform.SetParent(powerupEffectSpawnPoint); // Set the effect as a child of the spawn point

            PlayPowerupSound(despawnZombiesPowerupSound); // Play sound for the despawn zombies power-up

            // Despawn all zombies in the scene
            DespawnAllZombies();

            // Destroy the powerup after spawning the effect
            Destroy(other.gameObject);

             // Start the coroutine to destroy the effect after the delay
            StartCoroutine(DisablePowerupEffectAfterDelay(effectInstance, 2f));
        }
    }

    void PlayPowerupSound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // Play the specified power-up sound
        }
    }

    public void IncreaseSpeed(float speedBoostMultiplier, float duration)
    {
        currentSpeedBoost *= speedBoostMultiplier;
        speedBoostDuration = duration;
    }

    public void IncreaseHealth(int healthPoints)
    {
        int maxHealth = 5;
        int potentialHealth = lives + healthPoints;

        if (potentialHealth <= maxHealth) // Consider using the maximum health instead of 'lives'
        {
            lives = potentialHealth; // Update the current health to the potentialHealth

            // Activate heart images up to the current health
            for (int i = 0; i < lives; i++)
            {
                heartImages[i].enabled = true;
            }

            // Disable any remaining heart images beyond current health
            for (int i = lives; i < maxHealth; i++)
            {
                heartImages[i].enabled = false;
            }
        }
    }

    private void DespawnAllZombies()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject zombie in zombies)
        {
            Destroy(zombie);
        }
    }

    public IEnumerator DisablePowerupEffectAfterDelay(GameObject effectInstance, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destroy the powerup effect object after the delay
        if (effectInstance)
        {
            Destroy(effectInstance);
        }
    }
}
