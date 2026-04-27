using System.Collections;
using UnityEngine;

public class PageFlipController : MonoBehaviour
{
    public Transform[] pages;   
    public float flipSpeed = 5f;

    private int currentPage = 0;
    private bool isFlipping = false;

    public AudioSource flipSound;

    public void FlipForward()
    {
        if (isFlipping) return;

        flipSound.Play();

        if (currentPage < pages.Length)
        {
            StartCoroutine(FlipPage(pages[currentPage], 180f));
            currentPage++;
        }
    }

    public void FlipBackward()
    {
        if (isFlipping) return;

        flipSound.Play();

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

    Transform front = page.Find("Front");
    Transform back = page.Find("Back");

    Quaternion startRotation = page.rotation;
    Quaternion endRotation = startRotation * Quaternion.Euler(0, angle, 0);

    float time = 0;
    bool swapped = false;

    while (time < 1)
    {
        time += Time.deltaTime * flipSpeed;
        page.rotation = Quaternion.Slerp(startRotation, endRotation, time);

        if (time >= 0.5f && !swapped)
        {
            if (angle > 0)
            {
                // Forward: show back side
                if (front != null) front.gameObject.SetActive(false);
                if (back != null) back.gameObject.SetActive(true);
            }
            else
            {
                // Backward: show front side
                if (front != null) front.gameObject.SetActive(true);
                if (back != null) back.gameObject.SetActive(false);
            }

            swapped = true;
        }

        yield return null;
    }

    page.rotation = endRotation;
    isFlipping = false;
}
}