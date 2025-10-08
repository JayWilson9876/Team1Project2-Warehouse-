using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject[] items = new GameObject[4];

    void PlaceItemInBox(GameObject item)
    {
        items[items.Length] = item;
        item.transform.SetParent(transform);
        if (items.Length == 1)
        {
            item.transform.localPosition = new Vector3(-1, 0, 1);
        }
        if (items.Length == 2)
        {
            item.transform.localPosition = new Vector3(1, 0, 1);
        }
        if (items.Length == 3)
        {
            item.transform.localPosition = new Vector3(-1, 0, -1);
        }
        if (items.Length == 4)
        {
            item.transform.localPosition = new Vector3(1, 0, -1);
        }
        item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
