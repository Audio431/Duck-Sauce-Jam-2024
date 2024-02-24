using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, Enemy
{
    public float hp = 1;
    public float atk = 1;
    public LogicManager logic;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }
    public void Damage(float dmg)
    {
        Debug.Log("attack" + dmg);
        hp = hp - dmg;
        if (hp <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
        logic.AddScore();
        Debug.Log("Dead");
    }

    public void SetHp(float health)
    {
        hp=health;
        Debug.Log($"{hp}");
    }
    public void SetAtk(float attack)
    {
        atk = attack;
        Debug.Log(atk);
    }

    public void Attack()
    {
        StartCoroutine(AttackAnimation());
    }

    IEnumerator AttackAnimation()
    {
        animator.SetBool("isAttacking", true);
        Debug.Log("attack"+atk);

        // Wait for a short duration (adjust as needed)
        yield return new WaitForSeconds(0.1f);

        animator.SetBool("isAttacking", false);
    }
}
