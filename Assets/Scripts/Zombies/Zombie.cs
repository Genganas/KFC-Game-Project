using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent agent;
    public float health = 10f;
    public ScoreScript score;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject);
        }

        Move();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Move()
    {
        if (health > 0f)
        {
            agent.SetDestination(GameObject.Find("Player").transform.position);
        }
     
    }
}
