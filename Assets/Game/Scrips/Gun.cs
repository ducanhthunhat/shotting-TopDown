using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;
    [SerializeField] protected float timeShooting = 0f;
    [SerializeField] protected float timeDelay = 2f;
    [SerializeField] protected int maxBullet = 24;
    [SerializeField] protected int currentBullet;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform shootingPoint;

    [SerializeField] public float reloadBullet = 0;
    [SerializeField] protected float reloadDelay = 1;

    void Start()
    {
        currentBullet = maxBullet;
    }

    void Update()
    {
        rotateGun();
        Shoot();
        Reload();
        reloadBullet += Time.deltaTime;
        if(reloadBullet > reloadDelay){
            reloadBullet = 3;
        }
    }

    protected void rotateGun(){
        Vector3 distance = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle + rotateOffset);
        if(angle < -90 || angle > 90){
            transform.localScale =  new Vector3 (1,1,1);
        }
        else{
            transform.localScale =  new Vector3 (1,-1,1);

        }
    }

    void Shoot(){
        if(!Input.GetMouseButton(0)){
        timeShooting = 0;
        return;
        }
        timeShooting += Time.deltaTime;
        if(timeShooting < timeDelay) return;
        timeShooting = 0;
        
        if(Input.GetMouseButton(0) && currentBullet > 0){
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            currentBullet--;
        }
        
    }

    void Reload(){
        
        if(Input.GetMouseButtonDown(1) && currentBullet < maxBullet && reloadBullet > reloadDelay){
            currentBullet = maxBullet;
            reloadBullet = 0;
        }
    }
}
