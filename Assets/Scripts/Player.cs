using TMPro;
using Unity.VisualScripting;
using UnityEditor;
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
    bool done = false;

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
                if (!clockedIn && !done)
                {
                    canInteract = true;
                    interactText.text = "Clock In";
                    interactText.enabled = true;
                }
                else if (clockedIn && !done)
                {
                    canInteract = true;
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
                                done = true;
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

        if (clockedIn)
        {
            timeSeconds += Time.deltaTime;
            if (timeSeconds >= 60)
            {
                timeMinutes += 1;
                timeSeconds = 0;
                if (timeMinutes >= 60)
                {
                    timeHours += 1;
                    timeMinutes = 0;
                }
            }
        }

        timerText.text = Timer();
    }

    string Timer()
    {
        string secondsString;
        string minutesString;
        string hoursString;

        if (timeSeconds < 10)
        {
            secondsString = $"0{Mathf.RoundToInt(timeSeconds)}";
        }
        else
        {
            secondsString = Mathf.RoundToInt(timeSeconds).ToString();
        }

        if (timeMinutes < 10)
        {
            minutesString = $"0{Mathf.RoundToInt(timeMinutes)}";
        }
        else
        {
            minutesString = Mathf.RoundToInt(timeMinutes).ToString();
        }

        if (timeHours < 10)
        {
            hoursString = $"0{Mathf.RoundToInt(timeHours)}";
        }
        else
        {
            hoursString = Mathf.RoundToInt(timeHours).ToString();
        }

        return $"{hoursString}:{minutesString}:{secondsString}";
    }
}
