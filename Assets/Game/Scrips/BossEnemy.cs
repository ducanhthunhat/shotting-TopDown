using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float hpValue = 100f;
    [SerializeField] private GameObject minions;
    [SerializeField] private float skillCoolDown = 2f;
    private float nextSkillTime = 0f;
    private EnemyBullet enemyBullet;
    private void Awake()
    {
        enemyBullet = FindAnyObjectByType<EnemyBullet>();
    }
    protected override void Update()
    {
        UseSkill();
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(5);
        }
    }
    private void base_shooting()
    {
        Vector3 directionToPlayer = player.transform.position - firePoint.position;
        directionToPlayer.Normalize();
        GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
        EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
        enemyBullet.SetMovementDirections(directionToPlayer * 15);
    }
    private void circle_shooting()
    {
        const int bulletCount = 12;
        float angleStep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirections(bulletDirection * 15);
        }
    }

    private void healHp(float hpAmount)
    {
        currentHP = Mathf.Min(currentHP + hpAmount, maxHp);
        UpdateHpBar();
    }

    private void instanceMinions()
    {
        Instantiate(minions, transform.position, Quaternion.identity);
    }

    private void telePort()
    {
        transform.position = player.transform.position;
    }

    private void RandomSkill()
    {
        int randomSkill = Random.Range(0, 5);
        switch (randomSkill)
        {
            case 0:
                base_shooting();
                break;
            case 1:
                circle_shooting();
                break;
            case 2:
                healHp(100);
                break;
            case 3:
                instanceMinions();
                break;
            case 4:
                telePort();
                break;
        }
    }

    private void UseSkill()
    {
        nextSkillTime += Time.deltaTime;
        if (nextSkillTime < skillCoolDown) return;
        nextSkillTime = 0;
        RandomSkill();
    }
}
