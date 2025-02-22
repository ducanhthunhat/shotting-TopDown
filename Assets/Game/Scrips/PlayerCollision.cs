using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            player.TakeDamage(10);
        }
        else if (other.CompareTag("USB"))
        {
            Debug.Log("Win");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Energy"))
        {
            gameManager.AddEnegy();
            Destroy(other.gameObject);
        }
    }
}
