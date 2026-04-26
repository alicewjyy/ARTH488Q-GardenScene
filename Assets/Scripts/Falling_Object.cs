using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Falling_Object : MonoBehaviour
{
    public GameObject interactPrompt;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject block1;
    public GameObject player;


    private bool playerInRange = false;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactPrompt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        interactPrompt.SetActive(playerInRange);

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");

            if (!platform1.activeSelf)
            {
                platform1.SetActive(true);
            }
            if (!platform2.activeSelf)
            {
                platform2.SetActive(true);
            }
            StartCoroutine(TimerCoroutine(3f));

        }
    }
    private IEnumerator TimerCoroutine(float duration)
    {
        Debug.Log("Timer started!");
        yield return new WaitForSeconds(duration);
        Debug.Log("10 seconds passed!");
        ShootAbovePlayer();
    }
    void ShootAbovePlayer()
    {
        Vector3 spawnPosition = player.transform.position + new Vector3(0f, 6f, 0f);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject block = Instantiate(block1, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = block.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = block.AddComponent<Rigidbody2D>();
        }

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1f;
        rb.freezeRotation = true; 

        

        StartCoroutine(FloatDown(block));
        if (block.GetComponent<Collider2D>() == null)
        {
            block.AddComponent<BoxCollider2D>();
        }
    }

    private IEnumerator FloatDown(GameObject block)
    {
        Collider2D blockCol = block.GetComponent<Collider2D>();
        Collider2D playerCol = player.GetComponent<Collider2D>();
        Rigidbody2D rb = block.GetComponent<Rigidbody2D>();


        Physics2D.IgnoreCollision(blockCol, playerCol, true);
        StartCoroutine(ReenableCollision(blockCol, playerCol, 3f));


        float groundY = -1.75f;
        if (player.transform.position.y > 0.25 && player.transform.position.y < 2)
        {
            groundY = -0.65f;
        }
        else
        {
            groundY = 4.41f;
        }
        float followSpeed = 4f;

        while (block != null && block.transform.position.y > groundY)
        {
            float targetX = player.transform.position.x;

            Vector3 pos = block.transform.position;

            pos.x = Mathf.Lerp(pos.x, targetX, followSpeed * Time.deltaTime);

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -4f);

            block.transform.position = pos;

            yield return null;
        }

        if (block != null)
        {
            Vector3 pos = block.transform.position;
            pos.y = groundY;
            block.transform.position = pos;
        }
    }
    IEnumerator ReenableCollision(Collider2D a, Collider2D b, float delay)
    {
        yield return new WaitForSeconds(delay);
        Physics2D.IgnoreCollision(a, b, false);
    }
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
