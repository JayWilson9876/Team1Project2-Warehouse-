using System.Collections;
using System.ComponentModel.Design;
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
    public GameObject door;
    bool doorOpen = false;
    public GameObject item1Spawner;
    public GameObject item2Spawner;
    public GameObject item3Spawner;
    public GameObject box1Spawner;
    public GameObject box2Spawner;
    public GameObject box3Spawner;
    int boxesNeeded;

    void Start()
    {
        interactText.enabled = false;
        currentScene = SceneManager.GetActiveScene();
        truck1Set1.SetActive(false);
        truck2Set1.SetActive(false);
        truck3Set1.SetActive(false);
        truck1Set2.SetActive(false);
        truck2Set2.SetActive(false);
        truck3Set2.SetActive(false);
        truck1Set3.SetActive(false);
        truck2Set3.SetActive(false);
        truck3Set3.SetActive(false);
        if (currentScene.name == "LVL 2")
        {
            boxesNeeded = 2;
        }
        else if (currentScene.name == "LVL 3")
        {
            boxesNeeded = 3;
        }
        else
        {
            boxesNeeded = 1;
        }
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
                if (hit.collider.CompareTag("Correct Box 1") || hit.collider.CompareTag("Correct Box 2") || hit.collider.CompareTag("Correct Box 3") || hit.collider.CompareTag("Incorrect Box 1") || hit.collider.CompareTag("Incorrect Box 2") || hit.collider.CompareTag("Incorrect Box 3"))
                {
                    canInteract = true;
                    interactText.text = "Pick Up";
                    interactText.enabled = true;
                }
                else if (hit.collider.CompareTag("Pickup"))
                {
                    currentItemScript = hit.collider.GetComponent<Item>();
                    if (currentItemScript.canBePickedUp)
                    {
                        canInteract = true;
                        interactText.text = "Pick Up";
                        interactText.enabled = true;
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
                    else if (clockedIn && !done && truck1Capacity == boxesNeeded && truck2Capacity == boxesNeeded && truck3Capacity == boxesNeeded)
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
                    else if ((hit.collider.CompareTag("Truck 1") && objectHolderScript.CompareTag("Correct Box 1") && truck1Capacity < 3) || (hit.collider.CompareTag("Truck 2") && objectHolderScript.CompareTag("Correct Box 2") && truck2Capacity < 3) || (hit.collider.CompareTag("Truck 3") && objectHolderScript.CompareTag("Correct Box 3") && truck3Capacity < 3))
                    {
                        canInteract = true;
                        interactText.text = "Put In Truck";
                        interactText.enabled = true;
                    }
                    else if (hit.collider.CompareTag("Waste Bin"))
                    {
                        canInteract = true;
                        interactText.text = "Throw Away";
                        interactText.enabled = true;
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
                        if (hit.collider.CompareTag("Pickup") || hit.collider.CompareTag("Correct Box 1") || hit.collider.CompareTag("Correct Box 2") || hit.collider.CompareTag("Correct Box 3") || hit.collider.CompareTag("Incorrect Box 1") || hit.collider.CompareTag("Incorrect Box 2") || hit.collider.CompareTag("Incorrect Box 3"))
                        {
                            objectHolderScript.PickUpItem(hit.transform.gameObject);
                            holdingObject = true;
                            if (hit.collider.CompareTag("Pickup"))
                            {
                                if (!currentItemScript.pickedUpFirstTime)
                                {
                                    currentItemScript.pickedUpFirstTime = true;
                                    currentItemScript.SendSpawnCommand();
                                }
                            }
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
                                item1Spawner.GetComponent<Spawner>().Spawn();
                                item2Spawner.GetComponent<Spawner>().Spawn();
                                item3Spawner.GetComponent<Spawner>().Spawn();
                                box1Spawner.GetComponent<Spawner>().Spawn();
                                box2Spawner.GetComponent<Spawner>().Spawn();
                                box3Spawner.GetComponent<Spawner>().Spawn();
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
                        if ((objectHolderScript.currentItem.CompareTag("Pickup")) && (hit.collider.CompareTag("Open Box 1")) || (hit.collider.CompareTag("Open Box 2")) || (hit.collider.CompareTag("Open Box 3")))
                        {
                            objectHolderScript.Unparent(currentBoxScript);
                            holdingObject = false;
                            interactText.enabled = false;
                        }
                        else if (hit.collider.CompareTag("Truck 1") && objectHolderScript.currentItem.CompareTag("Correct Box 1") && truck1Capacity < boxesNeeded)
                        {
                            truck1Capacity++;
                            objectHolderScript.DestroyBox();
                            holdingObject = false;
                            if (truck1Capacity == 1)
                            {
                                truck1Set1.SetActive(true);
                                if (truck1Capacity < boxesNeeded)
                                {
                                    box1Spawner.GetComponent<Spawner>().Spawn();
                                }
                                else
                                {
                                    truck1Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                    truck1Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                            }
                            else if (truck1Capacity == 2)
                            {
                                truck1Set2.SetActive(true);
                                if (truck1Capacity < boxesNeeded)
                                {
                                    box1Spawner.GetComponent<Spawner>().Spawn();
                                }
                                else
                                {
                                    truck1Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                    truck1Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                            }
                            else if (truck1Capacity == 3)
                            {
                                truck1Set3.SetActive(true);
                                truck1Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                truck1Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                        }
                        else if (hit.collider.CompareTag("Truck 2") && objectHolderScript.currentItem.CompareTag("Correct Box 2") && truck2Capacity < boxesNeeded)
                        {
                            truck2Capacity++;
                            objectHolderScript.DestroyBox();
                            holdingObject = false;
                            if (truck2Capacity == 1)
                            {
                                truck2Set1.SetActive(true);
                                if (truck2Capacity < boxesNeeded)
                                {
                                    box2Spawner.GetComponent<Spawner>().Spawn();
                                }
                                else
                                {
                                    truck2Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                    truck2Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                            }
                            else if (truck2Capacity == 2)
                            {
                                truck1Set2.SetActive(true);
                                if (truck2Capacity < boxesNeeded)
                                {
                                    box2Spawner.GetComponent<Spawner>().Spawn();
                                }
                                else
                                {
                                    truck2Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                    truck2Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                            }
                            else if (truck2Capacity == 3)
                            {
                                truck2Set3.SetActive(true);
                                truck2Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                truck2Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                        }
                        else if (hit.collider.CompareTag("Truck 3") && objectHolderScript.currentItem.CompareTag("Correct Box 3") && truck3Capacity < boxesNeeded)
                        {
                            truck3Capacity++;
                            objectHolderScript.DestroyBox();
                            holdingObject = false;
                            if (truck3Capacity == 1)
                            {
                                truck3Set1.SetActive(true);
                                if (truck3Capacity < boxesNeeded)
                                {
                                    box3Spawner.GetComponent<Spawner>().Spawn();
                                }
                                else
                                {
                                    truck3Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                    truck3Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                            }
                            else if (truck3Capacity == 2)
                            {
                                truck3Set2.SetActive(true);
                                if (truck3Capacity < boxesNeeded)
                                {
                                    box3Spawner.GetComponent<Spawner>().Spawn();
                                }
                                else
                                {
                                    truck3Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                    truck3Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                            }
                            else if (truck3Capacity == 3)
                            {
                                truck3Set3.SetActive(true);
                                truck3Door1.transform.eulerAngles = new Vector3(0, 0, 0);
                                truck3Door2.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                        }
                        else if (hit.collider.CompareTag("Waste Bin"))
                        {
                            objectHolderScript.DestroyBox();
                            holdingObject = false;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            if (!doorOpen)
            {
                door.transform.eulerAngles = new Vector3(0, -180, 0);
                doorOpen = true;
            }
        }
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
