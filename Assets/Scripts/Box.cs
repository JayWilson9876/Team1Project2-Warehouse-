using UnityEngine;
using System.Collections.Generic;

public class Box : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void PlaceItemInBox(GameObject item)
    {
        items.Add(item);
        item.transform.SetParent(transform);
        if (items.Count == 1)
        {
            item.transform.localPosition = new Vector3(-1, 0, 1);
        }
        if (items.Count == 2)
        {
            item.transform.localPosition = new Vector3(1, 0, 1);
        }
        if (items.Count == 3)
        {
            item.transform.localPosition = new Vector3(-1, 0, -1);
        }
        if (items.Count == 4)
        {
            item.transform.localPosition = new Vector3(1, 0, -1);
        }
        item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
