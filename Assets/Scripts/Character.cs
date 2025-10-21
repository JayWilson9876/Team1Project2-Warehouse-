using UnityEngine.SceneManagement;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Player playerScript;
    Scene currentLevel;
    
    void Start()
    {
        currentLevel = playerScript.currentScene;
    }

    void Update()
    {
        
    }
}
