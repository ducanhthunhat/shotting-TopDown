using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed = 5f;
    [SerializeField] protected float timeDes = 5f;

    void Start()
    {
        Destroy(this.gameObject, timeDes);
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet(){
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null){
                enemy.TakeDamage(20);
            }
            Destroy(gameObject); 
        }
    }
}
