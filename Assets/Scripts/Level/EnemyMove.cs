using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoint;
    [SerializeField]
    private float moveSpeed;
    private int wayPointIndex = 0;

    private SpriteRenderer sprite;


    private void Start()
    {
        transform.position = wayPoint[wayPointIndex].transform.position;
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (transform.position == wayPoint[wayPointIndex].transform.position)
        {
            wayPointIndex += 1;
            sprite.flipX = !sprite.flipX;
        }

        if (wayPointIndex == wayPoint.Length)
            wayPointIndex = 0;
        transform.position = Vector2.MoveTowards(
            transform.position, wayPoint[wayPointIndex].transform.position,
            moveSpeed * Time.deltaTime);
    }
}
