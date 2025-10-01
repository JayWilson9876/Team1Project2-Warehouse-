using UnityEngine;

public class Player : MonoBehaviour
{
    bool holdingObject = false;
    public ObjectHolder objectHolderScript;
    public Camera playerCamera;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (holdingObject == false)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 2.5f))
                {
                    if (hit.collider.CompareTag("Box"))
                    {
                        objectHolderScript.PickUpBox(hit.transform.gameObject);
                        holdingObject = true;
                    }
                    
                }
            }
            else
            {
                objectHolderScript.DropBox();
                holdingObject = false;
            }
        }
    }
}
