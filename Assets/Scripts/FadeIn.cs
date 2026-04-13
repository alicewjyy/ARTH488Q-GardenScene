using System.Threading.Tasks;
using UnityEngine;

public class LevelStartFade : MonoBehaviour
{
    private async void Start()
    {
        Debug.Log("Back Invisible");

        await ScreenFade.Instance.FadeIn();
        Debug.Log("Back visible");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
