using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public Transform parent;
    GameObject currentBox;
    Rigidbody currentRigidBody;
    void Start()
    {

    }

    void Update()
    {

    }

    public void PickUpBox(GameObject box)
    {
        box.transform.SetParent(parent);
        currentBox = box;
        currentRigidBody = currentBox.GetComponent<Rigidbody>();
        currentBox.GetComponent<BoxCollider>().enabled = false;
        currentRigidBody.isKinematic = true;
        currentBox.transform.localPosition = Vector3.zero;
        currentBox.transform.eulerAngles = new Vector3(0, 0, 0);
        
    }

    public void DropBox()
    {
        currentBox.GetComponent<BoxCollider>().enabled = true;
        currentRigidBody.isKinematic = false;
        currentRigidBody = null;
        currentBox.transform.SetParent(null);
        currentBox = null;
    }
}
