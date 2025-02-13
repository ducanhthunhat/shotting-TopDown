using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected float Speed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    protected string currentAnim;
    protected int maxHealth = 100;
    [SerializeField] protected int currentHealth;

    protected float horizontal;
    protected float vertical;
    protected bool isFacingRight;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        playerMove();
    }

    protected virtual void playerMove(){
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal * Speed, vertical * Speed);
        if(Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0){
            changeAnim("run");
        }
        else {
            changeAnim("idle");
        }
        if((horizontal > 0 && isFacingRight) || (horizontal < 0 && !isFacingRight)){
            Flip();
        }
    }

    protected void changeAnim(string animName){
        if(currentAnim != animName){
            currentAnim = animName;
            anim.ResetTrigger(animName);
            anim.SetTrigger(currentAnim);
        }
    }

    protected void Flip(){
        isFacingRight = !isFacingRight;
        transform.Rotate(0,180,0);
    }

    public void TakeDamage(int amount){
        currentHealth -= amount;
    }

    private void Die(){

    }
}
