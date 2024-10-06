using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontal = 1.0f;
    public float jumpForce = 12.0f;
    public Animator animator;
    private Rigidbody2D rb;
    public HumanState state;
    public GameObject groundDetection;
    public GameObject frontDetection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetection = transform.Find("GroundDetection").gameObject;
        frontDetection = transform.Find("FrontDetection").gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("SpeedY", rb.velocity.y);
        animator.SetFloat("Horizontal", horizontal);
    }
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = horizontal * speed;
        rb.velocity = velocity;
        
    }
    public void RaycastDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().position + Vector2.right * 0.5f * horizontal, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));
        if (hit.collider == null)
        {
            Debug.Log("AddForceToJump");
            animator.SetBool("OnGround", false);
            Jump();
        }
        else
        {
            Debug.Log("Ã»ÓÐÆðÌø");
        }
    }
    public void Jump()
    {
        rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
    }
    public void TurnBack()
    {
        horizontal *= -1;
        Collider2D groundDetectionCollider = groundDetection.GetComponent<Collider2D>();
        groundDetectionCollider.offset = new Vector2(groundDetectionCollider.offset.x * -1, groundDetectionCollider.offset.y);
        Collider2D frontDetectionCollider = frontDetection.GetComponent<Collider2D>();
        frontDetectionCollider.offset = new Vector2(frontDetectionCollider.offset.x * -1, frontDetectionCollider.offset.y);
        animator.SetBool("OnGround", true);
    }
}
