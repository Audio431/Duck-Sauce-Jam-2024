using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    protected PlayerController pc;
    public WeaponScriptableObject data;
    float currentCooldown;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        data.enable = false;
        pc = FindObjectOfType<PlayerController>();
        currentCooldown = data.cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f && data.enable == true){
            Attack();
        }
    }

    protected virtual void Attack(){
        currentCooldown = data.cooldownDuration;
    }
}
