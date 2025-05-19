using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;
    public KeyCode freezeKey = KeyCode.S;

    private bool isFrozen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Animator bileşenini al
    }

    void Update()
    {
        float move = 0f;
        if (Input.GetKey(leftKey)) move = -1f;
        if (Input.GetKey(rightKey)) move = 1f;

        if (!isFrozen)
        {
            rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
            
            // YÖNE GÖRE DÖNME
            if (move > 0)
                transform.localScale = new Vector3(1f, 1f, 1f); // sağa bak
            else if (move < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f); // sola bak

            if (Input.GetKeyDown(jumpKey) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }

        // ANIMATOR PARAMETRELERİNİ GÜNCELLE
        float speed = Mathf.Abs(rb.linearVelocity.x);
        float velocityY = rb.linearVelocity.y;
        bool isJumping = !isGrounded;

        animator.SetFloat("Speed", speed);
        animator.SetFloat("VelocityY", velocityY);
        animator.SetBool("IsJumping", isJumping);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CollectableItem item = other.GetComponent<CollectableItem>();
        if (item != null)
        {
            int amount = item.GetScore();
            ScoreManager.instance.AddScore(amount);
            Destroy(other.gameObject);
        }
    }

}
