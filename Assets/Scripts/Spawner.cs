using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public GameObject faultyItem;

    public void Spawn()
    {
        int index = Random.Range(1, 11);
        if (index == 1)
        {
            Instantiate(faultyItem, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(itemToSpawn, transform.position, transform.rotation);
        }
    }
}
