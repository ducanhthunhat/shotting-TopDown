using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthEnemy : Enemy
{
    protected float healValue = 20f;
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

    protected override void Die(){
        if(currentHP <= 0){
            player.Heal(20);
        }
        base.Die();
    }
    
}
