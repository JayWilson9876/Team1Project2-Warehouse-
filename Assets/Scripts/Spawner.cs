using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemToSpawn;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        
    }

    public void Spawn()
    {
        Instantiate(itemToSpawn, transform.position, transform.rotation);
    }
}
