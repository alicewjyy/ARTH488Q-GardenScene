using UnityEngine;

public class StartLevel2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        await ScreenFade.Instance.FadeIn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
