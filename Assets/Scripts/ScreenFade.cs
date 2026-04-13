//Using This https://www.youtube.com/watch?v=Si6Rn_-3i84
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade Instance;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeDuration = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    async Task Fade(float targetTransparency)
    {
        if (canvasGroup == null) return;

        float startTransparency = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            if (canvasGroup == null) return; 

            elapsedTime += Time.deltaTime;

            canvasGroup.alpha = Mathf.Lerp(
                startTransparency,
                targetTransparency,
                elapsedTime / fadeDuration
            );

            await Task.Yield();
        }

        if (canvasGroup != null)
            canvasGroup.alpha = targetTransparency;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        canvasGroup = FindFirstObjectByType<CanvasGroup>();
    }

    async public Task FadeOut()
    {
        await Fade(1f);
    }
    async public Task FadeIn()
    {
        await Fade(0f);
    }
}
