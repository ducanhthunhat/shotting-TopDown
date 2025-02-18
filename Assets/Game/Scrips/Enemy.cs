using UnityEngine;
using UnityEngine.UI;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected Player player;
    protected bool isFacingRight;
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected float currentHP;
    [SerializeField] private Image hpBar;
    [SerializeField] protected int enterDamage = 10;
    [SerializeField] protected float stayDamage = 1f;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();
        currentHP = maxHp;
        UpdateHpBar();

    }
    protected virtual void Update()
    {
        MoveToPlayer();
    }
    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
        }
        if (transform.position.x < player.transform.position.x && isFacingRight || transform.position.x > player.transform.position.x && !isFacingRight)
        {
            Flip();
        }
    }

    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    public virtual void TakeDamage(int amount)
    {
        currentHP -= amount;
        UpdateHpBar();
        if (currentHP <= 0)
        {
            Die();
        }

    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected void UpdateHpBar()
    {
        hpBar.fillAmount = (float)currentHP / maxHp;
    }
}
