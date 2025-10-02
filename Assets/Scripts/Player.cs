using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool holdingObject = false;
    public ObjectHolder objectHolderScript;
    public Camera playerCamera;
    bool canInteract = false;
    public TextMeshProUGUI interactText;
    public TMP_Text timerText;
    float timeSeconds = 0;
    float timeMinutes = 0;
    float timeHours = 0;
    bool clockedIn = false;

    void Start()
    {
        interactText.enabled = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            if (hit.collider.CompareTag("Box"))
            {
                canInteract = true;
                interactText.text = "Pickup Box";
                interactText.enabled = true;
            }
            else if (hit.collider.CompareTag("Time Clock"))
            {
                canInteract = true;
                if (!clockedIn)
                {
                    interactText.text = "Clock In";
                    interactText.enabled = true;
                }
                else
                {
                    interactText.text = "Clock Out";
                    interactText.enabled = true;
                }
            }
        }
        else
        {
            canInteract = false;
            interactText.enabled = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!holdingObject)
            {
                if (canInteract)
                {
                    if (Physics.Raycast(ray, out hit, 2.5f))
                    {
                        if (hit.collider.CompareTag("Box"))
                        {
                            objectHolderScript.PickUpBox(hit.transform.gameObject);
                            holdingObject = true;
                        }
                        else if (hit.collider.CompareTag("Time Clock"))
                        {
                            if (!clockedIn)
                            {
                                clockedIn = true;
                            }
                            else
                            {
                                clockedIn = false;
                            }
                        }
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
