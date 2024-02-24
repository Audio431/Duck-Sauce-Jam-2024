using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, Enemy
{
    public float hp = 1;
    public LogicManager logic;
    private float maxHp = 1;

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
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Destroy(gameObject);
        logic.AddScore();
        Debug.Log("Dead");
    }

    public void SetHp(float health)
    {
        hp=health;
        maxHp = health;
        Debug.Log($"{hp}");
    }

    public void SetHealthbar(Slider slider)
    {
        slider.value = (maxHp - hp) / maxHp;
    }
}
