using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public GameObject faultyItem;
    public GameObject contrabandItem;

    public void Spawn()
    {
        int index = Random.Range(1, 11);
        if (index == 1)
        {
            Instantiate(contrabandItem, transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (index == 2)
        {
            Instantiate(faultyItem, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(itemToSpawn, transform.position, transform.rotation);
        }
    }
}
