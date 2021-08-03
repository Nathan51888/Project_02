using UnityEngine;

public class BoxDrag : MonoBehaviour
{
    public float followSpeed;
    private bool isHeldDown;
    private bool isTouching;
    private bool isTouchingPlayer;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float startPosX;
    private float startPosY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void Update()
    {
        if (isHeldDown && !isTouching)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (isHeldDown && !isTouchingPlayer)
        {
            var mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            rb.velocity = (mousePos - transform.position) * followSpeed;
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            isHeldDown = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isTouching = false;
        if (other.collider.CompareTag("Player"))
        {
            isTouchingPlayer = false;
            sprite.color = Color.white;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        isTouching = true;
        if (other.collider.CompareTag("Player") &&
            other.collider.transform.position.y >= transform.position.y)
        {
            isTouchingPlayer = true;
            sprite.color = Color.red;
        }
    }

    private void OnMouseDown()
    {
        if (!isTouchingPlayer) isHeldDown = true;
    }

    private void OnMouseUp()
    {
        isHeldDown = false;
    }
}