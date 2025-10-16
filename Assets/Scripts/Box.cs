using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

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
    GameObject gameManager;
    public List<GameObject> objectsNeeded;
    public GameObject[] itemsArray;
    public GameObject[] objectsNeededArray;
    public GameObject itemPrefab;
    public Material faultyMaterial;
    public Renderer boxRenderer;
    public Image itemSlot1;
    public Image itemSlot2;
    public Image itemSlot3;
    public Image itemSlot4;
    public string itemSlot1Find;
    public string itemSlot2Find;
    public string itemSlot3Find;
    public string itemSlot4Find;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        closedBox.SetActive(false);
        gameManager = GameObject.Find("GameManager");
        objectsNeeded = gameManager.GetComponent<GameManager>().CreateNewList(gameObject.tag);
        itemSlot1 = GameObject.Find(itemSlot1Find).GetComponent<Image>();
        itemSlot2 = GameObject.Find(itemSlot2Find).GetComponent<Image>();
        itemSlot3 = GameObject.Find(itemSlot3Find).GetComponent<Image>();
        itemSlot4 = GameObject.Find(itemSlot4Find).GetComponent<Image>();
    }

    public void PlaceItemInBox(GameObject item)
    {
        items.Add(item);
        Sprite loadedSprite = Resources.Load<Sprite>(item.GetComponent<Item>().spriteName);
        if (items.Count == 1)
        {
            item.transform.SetParent(slot1.transform);
            itemSlot1.sprite = loadedSprite;
        }
        if (items.Count == 2)
        {
            item.transform.SetParent(slot2.transform);
            itemSlot2.sprite = loadedSprite;
        }
        if (items.Count == 3)
        {
            item.transform.SetParent(slot3.transform);
            itemSlot3.sprite = loadedSprite;
        }
        if (items.Count == 4)
        {
            item.transform.SetParent(slot4.transform);
            itemSlot4.sprite = loadedSprite;
            openBox.SetActive(false);
            closedBox.SetActive(true);
            rb.isKinematic = false;
            itemsArray = items.ToArray();
            objectsNeededArray = objectsNeeded.ToArray();
            Array.Sort(itemsArray, (a, b) => a.name.CompareTo(b.name));
            Array.Sort(objectsNeededArray, (a, b) => a.name.CompareTo(b.name));
            Material[] currentMaterial = boxRenderer.materials;
            Material[] newMaterial = new Material[currentMaterial.Length + 1];
            newMaterial[0] = currentMaterial[0];
            if (gameObject.tag == "Open Box 1")
            {
                if (CheckLists())
                {
                    gameObject.tag = "Correct Box 1";
                }
                else
                {
                    gameObject.tag = "Incorrect Box 1";
                    newMaterial[newMaterial.Length - 1] = faultyMaterial;
                    boxRenderer.materials = newMaterial;
                }
            }
            else if (gameObject.tag == "Open Box 2")
            {
                if (CheckLists())
                {
                    gameObject.tag = "Correct Box 2";
                }
                else
                {
                    gameObject.tag = "Incorrect Box 2";
                    newMaterial[newMaterial.Length - 1] = faultyMaterial;
                    boxRenderer.materials = newMaterial;
                }
            }
            else if (gameObject.tag == "Open Box 3")
            {
                if (CheckLists())
                {
                    gameObject.tag = "Correct Box 3";
                }
                else
                {
                    gameObject.tag = "Incorrect Box 3";
                    newMaterial[newMaterial.Length - 1] = faultyMaterial;
                    boxRenderer.materials = newMaterial;
                }
            }
            gameObject.layer = 3;
        }
        item.transform.localPosition = new Vector3(0, 0, 0);
        item.transform.localScale = new Vector3(0.125f, 0.25f, 0.125f);
        item.transform.eulerAngles = new Vector3(0, 0, 0);
        item.tag = "Untagged";
    }

    bool CheckLists()
    {
        for (int i = 0; i < 4; i++)
        {
            if (itemsArray[i].name != objectsNeededArray[i].name)
            {
                return false;
            }
        }
        return true;
    }

    public void ResetSprites()
    {
        itemSlot1.sprite = null;
        itemSlot2.sprite = null;
        itemSlot3.sprite = null;
        itemSlot4.sprite = null;
    }
}
