using UnityEngine;

public class Item : MonoBehaviour
{
    public bool pickedUpFirstTime = false;
    public bool canBePickedUp = false;
    public Vector3 targetPosition;
    GameObject spawner;
    Spawner spawnerScript;
    public string spawnerName;
    Collider itemCollider;
    Rigidbody rb;

    void Start()
    {
        spawner = GameObject.Find(spawnerName);
        spawnerScript = spawner.GetComponent<Spawner>();
        itemCollider = GetComponent<Collider>();
        itemCollider.enabled = false;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if ((transform.position != targetPosition) && !canBePickedUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, (6.637f / 10f) * Time.deltaTime);
        }
        else if (!pickedUpFirstTime)
        {
           canBePickedUp = true;
           itemCollider.enabled = true;
           rb.isKinematic = false;
        }
    }

    public void SendSpawnCommand()
    {
        spawnerScript.Spawn();
    }
}
