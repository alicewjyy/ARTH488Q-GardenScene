using UnityEngine;

public class BookTextUnlock : MonoBehaviour
{
    public GameObject[] bookTexts;

    void Start()
    {
        foreach (GameObject text in bookTexts)
        {
            text.SetActive(false);
        }
    }

    void Update()
    {
        if (DialogueProgress.Instance.birdDialogueFinished)
        {
            foreach (GameObject text in bookTexts)
            {
                text.SetActive(true);
            }
        }
    }
}