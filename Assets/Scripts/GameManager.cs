using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] items;
    Scene currentLevel;
    int index;
    public SpriteRenderer[] needs = new SpriteRenderer[4];
    public string sprite1Name;
    public string sprite2Name;
    public string sprite3Name;

    public List<GameObject> CreateNewList(string currentBox)
    {
        List<GameObject> objectsNeeded = new List<GameObject>();
        index = Random.Range(0, 3);
        objectsNeeded.Add(items[index]);
        index = Random.Range(0, 3);
        objectsNeeded.Add(items[index]);
        index = Random.Range(0, 3);
        objectsNeeded.Add(items[index]);
        index = Random.Range(0, 3);
        objectsNeeded.Add(items[index]);

        if (currentBox == "Open Box 1")
        {
            needs[0] = GameObject.Find("Truck1Need1").GetComponent<SpriteRenderer>();
            needs[1] = GameObject.Find("Truck1Need2").GetComponent<SpriteRenderer>();
            needs[2] = GameObject.Find("Truck1Need3").GetComponent<SpriteRenderer>();
            needs[3] = GameObject.Find("Truck1Need4").GetComponent<SpriteRenderer>();
        }
        else if (currentBox == "Open Box 2")
        {
            needs[0] = GameObject.Find("Truck2Need1").GetComponent<SpriteRenderer>();
            needs[1] = GameObject.Find("Truck2Need2").GetComponent<SpriteRenderer>();
            needs[2] = GameObject.Find("Truck2Need3").GetComponent<SpriteRenderer>();
            needs[3] = GameObject.Find("Truck2Need4").GetComponent<SpriteRenderer>();
        }
        else
        {
            needs[0] = GameObject.Find("Truck3Need1").GetComponent<SpriteRenderer>();
            needs[1] = GameObject.Find("Truck3Need2").GetComponent<SpriteRenderer>();
            needs[2] = GameObject.Find("Truck3Need3").GetComponent<SpriteRenderer>();
            needs[3] = GameObject.Find("Truck3Need4").GetComponent<SpriteRenderer>();
        }

        for (int i = 0; i < 4; i++)
        {
            Sprite loadedSprite;
            if (objectsNeeded[i].name == "Cow(Clone)")
            {
                loadedSprite = Resources.Load<Sprite>(sprite1Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Cat(Clone)")
            {
                loadedSprite = Resources.Load<Sprite>(sprite2Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Chicken(Clone)")
            {
                loadedSprite = Resources.Load<Sprite>(sprite3Name);
                needs[i].sprite = loadedSprite;
            }
            if (objectsNeeded[i].name == "Cow")
            {
                loadedSprite = Resources.Load<Sprite>(sprite1Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Cat")
            {
                loadedSprite = Resources.Load<Sprite>(sprite2Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Chicken")
            {
                loadedSprite = Resources.Load<Sprite>(sprite3Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Car7 (1)(Clone)")
            {
                loadedSprite = Resources.Load<Sprite>(sprite1Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Car4 (1)(Clone)")
            {
                loadedSprite = Resources.Load<Sprite>(sprite2Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Car3 (1)(Clone)")
            {
                loadedSprite = Resources.Load<Sprite>(sprite3Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Car1")
            {
                loadedSprite = Resources.Load<Sprite>(sprite1Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "Car2")
            {
                loadedSprite = Resources.Load<Sprite>(sprite2Name);
                needs[i].sprite = loadedSprite;
            }
            else if (objectsNeeded[i].name == "LLama")
            {
                loadedSprite = Resources.Load<Sprite>(sprite3Name);
                needs[i].sprite = loadedSprite;
            }
        }
        return objectsNeeded;
    }
}
