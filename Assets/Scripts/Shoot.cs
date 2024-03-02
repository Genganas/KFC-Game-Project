using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    public float speedOfBullet = 5f;
    public float destroyDelay = 2.0f; // Time in seconds before destroying the bullet
    public AudioClip shootingSound; // The sound to be played when shooting
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component from the same GameObject or its children
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        if (bullet != null && muzzle != null)
        {
            GameObject bullets = Instantiate(bullet, muzzle.position, muzzle.rotation);
            Rigidbody rb = bullets.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = muzzle.forward * speedOfBullet;
            }

            Destroy(bullets, destroyDelay); // Destroy the instantiated bullet after a delay

            if (audioSource != null && shootingSound != null)
            {
                // Play the shooting sound
                audioSource.PlayOneShot(shootingSound);
            }
        }
    }
}
