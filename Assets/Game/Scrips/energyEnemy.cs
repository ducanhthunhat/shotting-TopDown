using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class energyEnemy : Enemy
{
    [SerializeField] private GameObject energyObject;
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

    protected override void Die()
    {
        if(energyObject != null){
            GameObject energy = Instantiate(energyObject,transform.position,Quaternion.identity);
            Destroy(energy, 5f);
        }
        base.Die();
    }
}
