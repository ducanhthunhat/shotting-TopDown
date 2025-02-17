using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player.TakeDamage(2);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player.TakeDamage(2);
        }
    }
}
