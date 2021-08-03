using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) GameManager.Instance.Respawn();
    }
}