// ZombieFactory.cs
using UnityEngine;

public abstract class ZombieFactory : MonoBehaviour
{
    [SerializeField] protected GameObject zombiePrefab; // Prefab for the zombie GameObject
    [SerializeField] protected Transform spawnPoint; // Transform to spawn zombies at

    public abstract void SpawnZombies(int round); // Abstract method to spawn zombies based on round
}
