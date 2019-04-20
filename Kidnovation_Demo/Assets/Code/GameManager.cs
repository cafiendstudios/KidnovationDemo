using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Stats")]
    public List<StoryNode> storyNodes = new List<StoryNode>();
    public GameObject startScreenGO;
    public GameObject settingsGO;
    public GameObject tutorialGO;

    private int currentNodeIndex = 0;

    private void Awake()
    {
        startScreenGO = GameObject.Find("StartScreen");
        Assert.IsNotNull(startScreenGO, "StartScreen - gameobject not assigned, can not restart when reached final node, this will happen if the gameobject \"StartScreen\" is disabled");
    }

    public void ActivateSettings()
    {
        settingsGO.SetActive(true);
    }

    public void ActivateTutorial()
    {
        tutorialGO.SetActive(true);
    }

    public void BeginStory()
    {
        storyNodes[currentNodeIndex].Activate();
    }

    public void LoadSavedData()
    {
        storyNodes[currentNodeIndex].Activate();
    }

    public void Reset()
    {
        currentNodeIndex = 0;
        startScreenGO.SetActive(true);
    }

    public void DisplayNextStoryNode()
    {
        storyNodes[currentNodeIndex].Deactivate();

        currentNodeIndex++;
        if (currentNodeIndex >= storyNodes.Count)
        {
            Debug.Log("No more story nodes in list, restarting...");
            Reset();
            return;
        }
        storyNodes[currentNodeIndex].Activate();
    }
}
