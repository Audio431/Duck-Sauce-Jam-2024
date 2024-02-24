using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, Enemy
{
    public float hp = 1;
    public LogicManager logic;
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
}
