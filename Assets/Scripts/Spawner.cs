using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemToSpawn;

    public void Spawn()
    {
        Instantiate(itemToSpawn, transform.position, transform.rotation);
    }
}
