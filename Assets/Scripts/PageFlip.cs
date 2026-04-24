using System.Collections;
using UnityEngine;

public class PageFlipController : MonoBehaviour
{
    public Transform[] pages;   
    public float flipSpeed = 5f;

    private int currentPage = 0;
    private bool isFlipping = false;

    public void FlipForward()
    {
        if (isFlipping) return;

        if (currentPage < pages.Length)
        {
            StartCoroutine(FlipPage(pages[currentPage], 180f));
            currentPage++;
        }
    }

    public void FlipBackward()
    {
        if (isFlipping) return;

        if (currentPage > 0)
        {
            currentPage--;
            StartCoroutine(FlipPage(pages[currentPage], -180f));
        }
    }

    IEnumerator FlipPage(Transform page, float angle)
    {
        isFlipping = true;

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
