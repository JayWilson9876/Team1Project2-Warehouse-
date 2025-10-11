using UnityEngine;

public class Item : MonoBehaviour
{
    public bool pickedUpFirstTime = false;
    public bool canBePickedUp = false;
    public Vector3 targetPosition;
    GameObject spawner;
    Spawner spawnerScript;
    public string spawnerName;

    void Start()
    {
        spawner = GameObject.Find(spawnerName);
        spawnerScript = spawner.GetComponent<Spawner>();
    }

    void Update()
    {
        if ((transform.position != targetPosition) && !canBePickedUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, (6.637f / 1f) * Time.deltaTime);
        }
        else
        {
           canBePickedUp = true;
        }
    }

    public void SendSpawnCommand()
    {
        spawnerScript.Spawn();
    }
}
