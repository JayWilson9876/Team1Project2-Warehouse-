using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject[] items;
    Scene currentLevel;
    int index;

    public List<GameObject> CreateNewList()
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
        return objectsNeeded;
    }
}
