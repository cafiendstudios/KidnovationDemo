using UnityEngine;

public class ActiveChoice : MonoBehaviour
{
    private bool hasPassed = false;
    private StoryNode node;

    public void Initialize(StoryNode node)
    {
        this.node = node;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void PassTest()
    {
        hasPassed = true;
    }

    public bool EvaluateHasPassed()
    {
        return hasPassed;
    }
}
