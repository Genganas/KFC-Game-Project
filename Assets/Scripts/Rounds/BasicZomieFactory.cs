using UnityEngine;
using System.Collections;

public class BasicZomieFactory : ZombieFactory
{
    [SerializeField] private float spawnInterval = 2f; // Interval between spawning zombies
    [SerializeField] private int zombiesPerRound = 5; // Number of zombies to spawn per round

    private int currentRound = 1; // Current round number
    private int zombiesSpawnedThisRound = 0; // Number of zombies spawned in the current round

    private void Start()
    {
        StartCoroutine(SpawnZombiesWithInterval());
    }

    private IEnumerator SpawnZombiesWithInterval()
    {
        while (true)
        {
            if (zombiesSpawnedThisRound < zombiesPerRound)
            {
                SpawnZombie();
                zombiesSpawnedThisRound++;
            }
            else
            {
                yield return new WaitForSeconds(spawnInterval * 2f); // Wait until next round starts
                currentRound++;
                zombiesSpawnedThisRound = 0;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombie()
    {
        GameObject zombieGameObject = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        // Set any additional properties for basic zombies, such as speed or health
    }

    public override void SpawnZombies(int round)
    {
        // This method is not needed since we're spawning zombies based on an interval
    }
}
