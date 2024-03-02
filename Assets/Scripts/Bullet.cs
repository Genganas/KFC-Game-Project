using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float damage = 10f;
    private ScoreScript score; // Reference to the ScoreScript

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        // Find GameObject with the specified tag
        GameObject scoreObject = GameObject.FindGameObjectWithTag("ScoreScript");

        if (scoreObject != null)
        {
            // Get the ScoreScript component from the GameObject with the tag
            score = scoreObject.GetComponent<ScoreScript>();

            if (score == null)
            {
                Debug.LogWarning("ScoreScript component not found on the GameObject with the specified tag.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject with the specified tag not found.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Zombie zombie = other.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage);
                if (score != null)
                {
                    score.AddScore(10);
                }
                else
                {
                    Debug.LogWarning("ScoreScript reference not found for the Bullet.");
                }
            }
        }
    }
}
