using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public Player playerScript;
    string currentLevel;
    int currentLine = 0;
    public TMP_Text subtitles;
    
    void Start()
    {
        currentLevel = playerScript.currentScene.name;
    }

    public void Dialogue()
    {
        currentLine++;
        if (currentLevel == "Tutorial")
        {
            switch (currentLine)
            {
                case 1:
                    subtitles.text = "Hey kid, come here and talk with me";
                    break;
                case 2:
                    subtitles.text = "Meet me inside and I'll walk you through the job";
                    break;
                case 3:
                    subtitles.text = "Go ahead and clock in at the computer and come back to me when you're ready";
                    break;
                case 4:
                    subtitles.text = "Alrighty, you see those TV's Behind you? Those will tell you the next set of items that need to be loaded into the truck";
                    break;
                case 5:
                    subtitles.text = "Go ahead and take the items as they come through the conveyer belt put them in the boxes in the middle of the room";
                    break;
                case 6:
                    subtitles.text = "Any faulty items just take to the bins in the corner";
                    break;
                case 7:
                    subtitles.text = "Anyways, go ahead and clock in and get to work. Don't forget to clock out once you're done";
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
                    subtitles.text = "Hey, come here";
                    break;
                case 2:
                    subtitles.text = "Boss said that if anything that looks strange comes off the of the conveyer, just bring it to me. Otherwise, just clock in and out like you did yesterday";
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
                    subtitles.text = "Get over here";
                    break;
                case 2:
                    subtitles.text = "We've got new inventory";
                    break;
                case 3:
                    subtitles.text = "Just load them up the same way you did with the last batch";
                    break;
                case 4:
                    subtitles.text = "If you come across anything that shouldn't be on the line, bring it to me, and don't ask questions";
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
                    subtitles.text = "Come here";
                    break;
                case
            }
        }
    }
}
