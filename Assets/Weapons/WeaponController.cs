using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    protected PlayerController pc;
    float currentCooldown;
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    public int pierce;
    public bool enable;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enable = false;
        pc = FindObjectOfType<PlayerController>();
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f && enable == true){
            Attack();
        }
    }

    protected virtual void Attack(){
        currentCooldown = cooldownDuration;
    }
}
