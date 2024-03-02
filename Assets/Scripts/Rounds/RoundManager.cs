// RoundManager.cs
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private ZombieFactory[] zombieFactories; // Array of zombie factories
    [SerializeField] private int maxRounds = 10; // Maximum number of rounds

    private int currentRound = 1; // Current round number

    void Start()
    {
        StartRound(); // Start the first round
    }

    void Update()
    {
        // Check if all zombies are dead
        if (GameObject.FindWithTag("Zombie") == null)
        {
            // Proceed to the next round
            NextRound();
        }
    }

    void StartRound()
    {
        // Spawn zombies based on the current round
        foreach (ZombieFactory factory in zombieFactories)
        {
            factory.SpawnZombies(currentRound);
        }

        // Display round information
        Debug.Log("Round: " + currentRound);
    }

    void NextRound()
    {
        // Increment the current round
        currentRound++;

        // Check if the maximum number of rounds has been reached
        if (currentRound <= maxRounds)
        {
            StartRound(); // Start the next round
        }
        else
        {
            // End the game
            Debug.Log("Game Over!");
        }
    }
}
