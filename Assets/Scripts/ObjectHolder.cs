using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public Transform parent;
    public GameObject currentItem;
    Rigidbody currentRigidBody;

    public void PickUpItem(GameObject item)
    {
        item.transform.SetParent(parent);
        currentItem = item;
        currentRigidBody = currentItem.GetComponent<Rigidbody>();
        currentItem.GetComponent<BoxCollider>().enabled = false;
        currentRigidBody.isKinematic = true;
        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void DropItem()
    {
        currentItem.GetComponent<BoxCollider>().enabled = true;
        currentRigidBody.isKinematic = false;
        currentRigidBody = null;
        currentItem.transform.SetParent(null);
        currentItem = null;
    }

    public void Unparent(Box currentBoxScript)
    {
        currentItem.transform.parent = null;
        currentBoxScript.PlaceItemInBox(currentItem);
    }

    public void DestroyBox()
    {
        Destroy(currentItem);
        currentItem = null;
        currentRigidBody = null;
    }
}
