using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerupPrefabs; // Array of powerup prefabs
    [SerializeField] private float spawnInterval = 5f; // Interval between spawning powerups
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points

    private void Start()
    {
        StartCoroutine(SpawnPowerupsWithInterval());
    }

    private IEnumerator SpawnPowerupsWithInterval()
    {
        while (true)
        {
            // Choose a random powerup prefab
            int powerupIndex = Random.Range(0, powerupPrefabs.Length);
            GameObject powerupPrefab = powerupPrefabs[powerupIndex];

            // Choose a random spawn point
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            // Instantiate the powerup prefab at the spawn point
            Instantiate(powerupPrefab, spawnPoint.position, spawnPoint.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
