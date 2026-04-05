using System.Collections;
using UnityEngine;

public class PageFlipController : MonoBehaviour
{
    public Transform[] pages;   
    public float flipSpeed = 5f;

    private int currentPage = 0;
    private bool isFlipping = false;

    void Update()
    {
        if (isFlipping) return;

        // Flip forward
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentPage < pages.Length)
            {
                StartCoroutine(FlipPage(pages[currentPage], 180f));
                currentPage++;
            }
        }

        // Flip backward
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentPage > 0)
            {
                currentPage--;
                StartCoroutine(FlipPage(pages[currentPage], -180f));
            }
        }
    }

   IEnumerator FlipPage(Transform page, float angle)
{
    isFlipping = true;

    // Bring page to front BEFORE flipping
    page.SetAsLastSibling();

    Quaternion startRotation = page.rotation;
    Quaternion endRotation = startRotation * Quaternion.Euler(0, angle, 0);

    float time = 0;

    while (time < 1)
    {
        time += Time.deltaTime * flipSpeed;
        page.rotation = Quaternion.Slerp(startRotation, endRotation, time);
        yield return null;
    }

    page.rotation = endRotation;

    isFlipping = false;
}
}
