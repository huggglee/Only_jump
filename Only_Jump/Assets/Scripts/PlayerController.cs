using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 4f;
    public float moveSpeed = 2f;
    private int direction = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > Screen.width / 2)
            {
                direction = 1;
            }
            else { direction = -1; }

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 newVelocity = new Vector2(moveSpeed * direction, jumpForce);
                rb.linearVelocity = newVelocity;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("you win");
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.one;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("gameover");
            GameManager.instance.GameOver();
        }
    }
}
