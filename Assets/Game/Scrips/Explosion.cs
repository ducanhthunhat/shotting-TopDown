using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Player player;
    private Enemy enemy;
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        enemy = FindAnyObjectByType<Enemy>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(30);  
        }
        if(collision.CompareTag("Enemy")){
            enemy.TakeDamage(100);
        }
    }

    public void DestroyExplosion()
    {
        Destroy(this.gameObject);
    }
}
