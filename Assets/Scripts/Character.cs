using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public Player playerScript;
    string currentLevel;
    public int currentLine = 1;
    public TextMeshProUGUI subtitles;
    public bool canTeleport = false;
    bool cancelClear = false;
    public bool canTalk = true;
    
    void Start()
    {
        currentLevel = playerScript.currentScene.name;
        if (currentLine == 1)
        {
            Dialogue();
        }
    }

    public void Dialogue()
    {
        if (currentLevel == "Tutorial")
        {
            switch (currentLine)
            {
                case 1:
                    subtitles.text = "\"Hey kid, come here and talk with me\"";
                    Invoke("ClearText", 5f);
                    break;
                case 2:
                    subtitles.text = "\"Meet me inside and I'll walk you through the job\"";
                    cancelClear = true;
                    Invoke("ClearText", 5f);
                    canTeleport = true;
                    break;
                case 3:
                    subtitles.text = "\"Go ahead and clock in at the computer and come back to me when you're ready\"";
                    cancelClear = true;
                    Invoke("ClearText", 5f);
                    break;
                case 4:
                    subtitles.text = "\"Alrighty, you see those TV's Behind you? Those will tell you the next set of items that need to be loaded into the truck\"";
                    cancelClear = true;
                    Invoke("Dialogue", 5f);
                    break;
                case 5:
                    subtitles.text = "\"Go ahead and take the items as they come through the conveyer belt put them in the boxes in the middle of the room\"";
                    cancelClear = true;
                    Invoke("Dialogue", 5f);
                    break;
                case 6:
                    subtitles.text = "\"Any faulty items you find, just take to the bins in the corner\"";
                    cancelClear = true;
                    Invoke("Dialogue", 5f);
                    break;
                case 7:
                    subtitles.text = "\"Anyways, go ahead and get to work. Don't forget to clock out once you're done\"";
                    cancelClear = true;
                    Invoke("ClearText", 5f);
                    canTalk = false;
                    break;
                default:
                    break;
            }
        }
        else if (currentLevel == "Level 1")
        {
            switch (currentLine)
            {
                case 1:
                    subtitles.text = "\"Hey, come here\"";
                    Invoke("ClearText", 5f);
                    break;
                case 2:
                    subtitles.text = "\"Boss said that if anything that looks strange comes off the of the conveyer belt, just bring it to me. Otherwise, just clock in and out like you did yesterday\"";
                    Invoke("ClearText", 5f);
                    canTeleport = true;
                    canTalk = false;
                    break;
                default:
                    break;
            }
        }
        else if (currentLevel == "LVL 2")
        {
            switch (currentLine)
            {
                case 1:
                    subtitles.text = "\"Get over here\"";
                    Invoke("ClearText", 5f);
                    break;
                case 2:
                    subtitles.text = "\"We've got new inventory\"";
                    cancelClear = true;
                    Invoke("Dialogue", 5f);
                    break;
                case 3:
                    subtitles.text = "\"Just load them up the same way you did with the last batch\"";
                    cancelClear = true;
                    Invoke("Dialogue", 5f);
                    break;
                case 4:
                    subtitles.text = "\"If you come across anything that shouldn't be on the line, bring it to me, and don't ask questions\"";
                    Invoke("ClearText", 5f);
                    playerScript.OpenDoor();
                    canTeleport = true;
                    canTalk = false;
                    break;
                default:
                    break;
            }
        }
        else if (currentLevel == "LVL 3")
        {
            switch (currentLine)
            {
                case 1:
                    subtitles.text = "\"Come here\"";
                    Invoke("ClearText", 2.5f);
                    break;
                case 2:
                    subtitles.text = "\"Last day of training, kid. Keep up the work and maybe we can let you in on the other parts of the business\"";
                    cancelClear = true;
                    Invoke("Dialogue", 5f);
                    break;
                case 3:
                    subtitles.text = "\"New inventory batch again. Anyways, go ahead and get to work. We will contact you if something comes up\"";
                    Invoke("ClearText", 5f);
                    playerScript.OpenDoor();
                    canTeleport = true;
                    canTalk = false;
                    break;
                default:
                    break;
            }
        }
        currentLine++;
    }

    public void MoveInside()
    {
        if (canTeleport)
        {
            transform.position = new Vector3(8.69f, 0f, 6.72f);
            transform.localEulerAngles = new Vector3(0f, -90f, 0f);
            canTeleport = true;
        }
    }

    void ClearText()
    {
        if (!cancelClear)
        {
            subtitles.text = "";
        }
        else
        {
            cancelClear = false;
        }
    }

    public void ContrabandDialogue()
    {
        subtitles.text = "\"Nice catch, now get back to work\"";
        Invoke("ClearText", 5f);
    }
}
