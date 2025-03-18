using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 5f;
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
            rb.linearVelocity = Vector2.one;
            LevelManager.instance.LoadNextLevel();
        } else if (collision.gameObject.CompareTag("Mattress"))
        {
            transform.position = collision.gameObject.transform.position;
            float angle = collision.gameObject.transform.eulerAngles.z* Mathf.Deg2Rad;
            Debug.Log(angle);
            //Vector2 jumpForce = new Vector2(0, 3.5f);
            //rb.AddForce(jumpForce, ForceMode2D.Impulse);
            rb.linearVelocity = new Vector2(6f*Mathf.Cos(angle), 12f* Mathf.Sin(angle));
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
