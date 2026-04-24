using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeSpeed = 5f;

    private bool isVisible = false; 
    private bool isFading = false;
    private float targetAlpha;

    void Update()
    {
        if (isFading)
        {
            canvasGroup.alpha = Mathf.MoveTowards(
                canvasGroup.alpha,
                targetAlpha,
                Time.deltaTime * fadeSpeed
            );

            if (canvasGroup.alpha == targetAlpha)
            {
                isFading = false;

                canvasGroup.interactable = isVisible;
                canvasGroup.blocksRaycasts = isVisible;
            }
        }
    }

    public void ToggleUI()
    {
        isVisible = !isVisible;

        targetAlpha = isVisible ? 1f : 0f;
        isFading = true;
    }
}