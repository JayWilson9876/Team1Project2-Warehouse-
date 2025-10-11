using UnityEngine;
using System.Collections.Generic;

public class Box : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject openBox;
    public GameObject closedBox;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        closedBox.SetActive(false);
    }

    public void PlaceItemInBox(GameObject item)
    {
        items.Add(item);
        if (items.Count == 1)
        {
            item.transform.SetParent(slot1.transform);
        }
        if (items.Count == 2)
        {
            item.transform.SetParent(slot2.transform);
        }
        if (items.Count == 3)
        {
            item.transform.SetParent(slot3.transform);
        }
        if (items.Count == 4)
        {
            item.transform.SetParent(slot4.transform);
            openBox.SetActive(false);
            closedBox.SetActive(true);
            rb.isKinematic = false;
            if (gameObject.tag == "Open Box 1")
            {
                gameObject.tag = "Closed Box 1";
            }
            else if (gameObject.tag == "Open Box 2")
            {
                gameObject.tag = "Closed Box 2";
            }
            else if (gameObject.tag == "Open Box 3")
            {
                gameObject.tag = "Closed Box 3";
            }
            gameObject.layer = 3;
        }
        item.transform.localPosition = new Vector3(0, 0, 0);
        item.transform.localScale = new Vector3(0.125f, 0.25f, 0.125f);
        item.transform.eulerAngles = new Vector3(0, 0, 0);
        item.tag = "Untagged";
    }
}
