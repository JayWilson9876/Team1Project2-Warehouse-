using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    Scene currentScene;
    public GameObject truck1Set1;
    public GameObject truck2Set1;
    public GameObject truck3Set1;
    public GameObject truck1Set2;
    public GameObject truck2Set2;
    public GameObject truck3Set2;
    public GameObject truck1Set3;
    public GameObject truck2Set3;
    public GameObject truck3Set3;
    int truck1Capacity = 0;
    int truck2Capacity = 0;
    int truck3Capacity = 0;
    public GameObject truck1Door1;
    public GameObject truck2Door1;
    public GameObject truck3Door1;
    public GameObject truck1Door2;
    public GameObject truck2Door2;
    public GameObject truck3Door2;
    Box currentBoxScript;
    public LayerMask itemLayer;
    Item currentItemScript;

    void Start()
    {
        interactText.enabled = false;
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            if (!holdingObject)
            {
                if (hit.collider.CompareTag("Pickup"))
                {
                    currentItemScript = GetComponent<Item>();
                    if (currentItemScript.canBePickedUp)
                    {
                        canInteract = true;
                        interactText.text = "Pick up";
                        interactText.enabled = true;
                        if (!currentItemScript.pickedUpFirstTime)
                        {
                            currentItemScript.SendSpawnCommand();
                        }
                    }
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
                else if (hit.collider.CompareTag("Car"))
                {
                    if (done)
                    {
                        canInteract = true;
                        interactText.text = "Finish";
                        interactText.enabled = true;
                    }
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, 2.5f, ~itemLayer))
                {
                    if ((hit.collider.CompareTag("Open Box 1")) || (hit.collider.CompareTag("Open Box 2")) || (hit.collider.CompareTag("Open Box 3")))
                    {
                        currentBoxScript = hit.collider.GetComponent<Box>();
                        if (currentBoxScript.items.Count < 4)
                        {
                            canInteract = true;
                            interactText.text = "Put In Box";
                            interactText.enabled = true;
                        }
                    }
                    else
                    {
                        canInteract = true;
                        interactText.text = "Drop";
                        interactText.enabled = true;
                    }
                }
                
            }
        }
        else
        {
            if (holdingObject)
            {
                canInteract = true;
                interactText.text = "Drop";
                interactText.enabled = true;
            }
            else
            {
                canInteract = false;
                interactText.enabled = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (canInteract)
            {
                if (!holdingObject)
                {
                    if (Physics.Raycast(ray, out hit, 2.5f))
                    {
                        if (hit.collider.CompareTag("Pickup"))
                        {
                            objectHolderScript.PickUpItem(hit.transform.gameObject);
                            holdingObject = true;
                        }
                        else if (hit.collider.CompareTag("Time Clock"))
                        {
                            if (!clockedIn)
                            {
                                clockedIn = true;
                                truck1Door1.transform.eulerAngles = new Vector3(0, 120, 0);
                                truck1Door2.transform.eulerAngles = new Vector3(0, -120, 0);
                                truck2Door1.transform.eulerAngles = new Vector3(0, 120, 0);
                                truck2Door2.transform.eulerAngles = new Vector3(0, -120, 0);
                                truck3Door1.transform.eulerAngles = new Vector3(0, 120, 0);
                                truck3Door2.transform.eulerAngles = new Vector3(0, -120, 0);
                            }
                            else
                            {
                                clockedIn = false;
                                done = true;
                            }
                        }
                        else if (hit.collider.CompareTag("Car"))
                        {
                            if (done)
                            {
                                if (currentScene.name == "Tutorial")
                                {
                                    SceneManager.LoadScene("Level 1");
                                }
                                if (currentScene.name == "Level 1")
                                {
                                    SceneManager.LoadScene("LVL 2");
                                }
                                else if (currentScene.name == "LVL 2")
                                {
                                    SceneManager.LoadScene("LVL 3");
                                }
                                else if (currentScene.name == "LVL 3")
                                {

                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Physics.Raycast(ray, out hit, 2.5f, ~itemLayer))
                    {
                        if ((hit.collider.CompareTag("Open Box 1")) || (hit.collider.CompareTag("Open Box 2")) || (hit.collider.CompareTag("Open Box 3")))
                        {
                            objectHolderScript.Unparent(currentBoxScript);
                            holdingObject = false;
                            interactText.enabled = false;
                        }
                        else
                        {
                            objectHolderScript.DropItem();
                            holdingObject = false;
                        }
                    }
                    else
                    {
                        objectHolderScript.DropItem();
                        holdingObject = false;
                    }
                }
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
