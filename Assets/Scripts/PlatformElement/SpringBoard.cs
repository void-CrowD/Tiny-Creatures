using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpringBoard : MonoBehaviour
{
    public float jumpForce = 20.0f;
    public float waitTime = 0.5f;
    float waitTimer = 0.0f;
    public float limitHeight = 10.0f;
    private bool isWaiting = false;
    Rigidbody2D rb2D;
    BoxCollider2D boxCollider2D;
    Vector2 originalPosition;
    private List<GameObject> humansOnIt;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        originalPosition = rb2D.position;
        boxCollider2D = GetComponent<BoxCollider2D>();
        humansOnIt = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHeight();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            humansOnIt.Add(other.gameObject);
            if (!isWaiting)
            {
                StartCoroutine(Spring());
                isWaiting = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            humansOnIt.Remove(other.gameObject);
            if(humansOnIt.Count == 0)
            {
                isWaiting = false;
                waitTimer = 0.0f;
            }
        }
    }
    IEnumerator Spring()
    {
        while (waitTimer < waitTime)
        {
            waitTimer += Time.deltaTime;
            yield return 0;
        }
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        foreach (GameObject human in humansOnIt)
        {
            Rigidbody2D humanRigidbody = human.GetComponent<Rigidbody2D>();
            humanRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        humansOnIt.Clear();
        boxCollider2D.enabled = false;
    }
    void CheckHeight()
    {
        if(rb2D.position.y - originalPosition.y >= limitHeight)
        {
            rb2D.position = originalPosition + new Vector2(0.0f, limitHeight);
            rb2D.velocity = Vector2.zero;
            rb2D.gravityScale = 5.0f;
        }
        else if(rb2D.position.y < originalPosition.y && rb2D.gravityScale > 0.0f)
        {
            rb2D.position = originalPosition;
            rb2D.velocity = Vector2.zero;
            rb2D.gravityScale = 0.0f;
            waitTimer = 0.0f;
            boxCollider2D.enabled = true;
            isWaiting = false;
        }
    }
}
