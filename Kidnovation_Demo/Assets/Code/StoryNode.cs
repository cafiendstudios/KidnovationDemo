using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class StoryNode : MonoBehaviour
{
    [Header("Stats")]
    public int id;
    public string title = "Story node ";

    [Header("Choices gameobjects")]
    public ActiveChoice activeChoice;
    public FantasyChoice fantasyChoice;
    public LearningChoice learningChoice;
    public MiniGame minigame;
    private GameObject previousChoice;

    [Header("UI panels")]
    [SerializeField] private GameObject nodePanel;
    [SerializeField] private GameObject activePanel;
    [SerializeField] private GameObject fantasyPanel;
    [SerializeField] private GameObject learningPanel;
    [SerializeField] private GameObject minigamePanel;
    private GameObject previousPanel;

    [Header("Header texts")]
    [SerializeField] private Text storyNodeTXT;
    [SerializeField] private Text activeTXT;
    [SerializeField] private Text fantasyTXT;
    [SerializeField] private Text learningTXT;
    [SerializeField] private Text minigameTXT;
    private Text previousText;
    private GameManager manager;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Assert.IsNotNull(manager, "Failed to locate <b>GameManager<b> object");

        Assert.IsNotNull(storyNodeTXT, string.Format("Title text object not assigned for story node {0}", id));
        storyNodeTXT.text = title + id.ToString();
    }

    public void ProceedToNextNode()
    {
        Reset();
        manager.DisplayNextStoryNode();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        previousText = storyNodeTXT;
    }

    public void Deactivate()
    {
        previousChoice?.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ChooseActive()
    {
        HidePreviousChoice();
        activePanel.SetActive(true);
        activeChoice.gameObject.SetActive(true);
        activeTXT.gameObject.SetActive(true);

        previousPanel = activePanel;
        previousChoice = activeChoice.gameObject;
        previousText = activeTXT;
    }

    public void ChooseFantasy()
    {
        HidePreviousChoice();
        fantasyPanel.SetActive(true);
        fantasyChoice.gameObject.SetActive(true);
        fantasyTXT.gameObject.SetActive(true);

        previousPanel = fantasyPanel;
        previousChoice = fantasyChoice.gameObject;
        previousText = fantasyTXT;
    }

    public void ChooseLearning()
    {
        HidePreviousChoice();
        learningPanel.SetActive(true);
        learningChoice.gameObject.SetActive(true);
        learningTXT.gameObject.SetActive(true);

        previousPanel = learningPanel;
        previousChoice = learningChoice.gameObject;
        previousText = learningTXT;
    }

    public void ChooseMinigame()
    {
        HidePreviousChoice();
        minigamePanel.SetActive(true);
        minigame.gameObject.SetActive(true);
        minigameTXT.gameObject.SetActive(true);

        previousPanel = minigamePanel;
        previousChoice = minigame.gameObject;
        previousText = minigameTXT;
    }

    public void ReplayMinigame()
    {
        // minigame.Replay();
        Debug.Log("Replay minigame");
    }

    private void HidePreviousChoice()
    {
        previousText?.gameObject.SetActive(false);
        nodePanel?.SetActive(false);
        previousPanel?.SetActive(false);
        previousChoice?.SetActive(false);
    }

    private void Reset()
    {
        HidePreviousChoice();
        storyNodeTXT?.gameObject.SetActive(true);
        nodePanel?.gameObject.SetActive(true);
    }
}
