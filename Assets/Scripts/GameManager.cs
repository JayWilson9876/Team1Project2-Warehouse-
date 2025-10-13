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
    public GameObject[] needs = new GameObject[4];

    public List<GameObject> CreateNewList(string currentBox)
    {
        List<GameObject> objectsNeeded = new List<GameObject>();
        if (currentLevel.name == "LVL 2")
        {
            index = Random.Range(3, 6);
            objectsNeeded.Add(items[index]);
            index = Random.Range(3, 6);
            objectsNeeded.Add(items[index]);
            index = Random.Range(3, 6);
            objectsNeeded.Add(items[index]);
            index = Random.Range(3, 6);
            objectsNeeded.Add(items[index]);
        }
        else
        {
            index = Random.Range(0, 3);
            objectsNeeded.Add(items[index]);
            index = Random.Range(0, 3);
            objectsNeeded.Add(items[index]);
            index = Random.Range(0, 3);
            objectsNeeded.Add(items[index]);
            index = Random.Range(0, 3);
            objectsNeeded.Add(items[index]);
        }
        /*
        if (currentBox == "Open Box 1")
        {
            needs[0] = GameObject.Find("Truck1Need1");
            needs[1] = GameObject.Find("Truck1Need2");
            needs[2] = GameObject.Find("Truck1Need3");
            needs[3] = GameObject.Find("Truck1Need4");
        }
        else if (currentBox == "Open Box 2")
        {
            needs[0] = GameObject.Find("Truck2Need1");
            needs[1] = GameObject.Find("Truck2Need2");
            needs[2] = GameObject.Find("Truck2Need3");
            needs[3] = GameObject.Find("Truck2Need4");
        }
        else
        {
            needs[0] = GameObject.Find("Truck3Need1");
            needs[1] = GameObject.Find("Truck3Need2");
            needs[2] = GameObject.Find("Truck3Need3");
            needs[3] = GameObject.Find("Truck3Need4");
        }

        for (int i = 0; i < 4; i++)
        {
            if (objectsNeeded[i].name == "Cow(Clone)")
            {

            }
            else if (objectsNeeded[i].name == "Cat(Clone)")
            {
                
            }
            else if (objectsNeeded[i].name == "Chicken(Clone)")
            {
                
            }
            else if (objectsNeeded[i].name == "Car7 (1)(Clone)")
            {
                
            }
            else if (objectsNeeded[i].name == "Car4 (1)(Clone)")
            {
                
            }
            else if (objectsNeeded[i].name == "Car3 (1)(Clone)")
            {
                
            }
        }
        */
        return objectsNeeded;
    }
}
