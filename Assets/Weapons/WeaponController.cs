using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    protected PlayerController pc;
    float currentCooldown;
    public GameObject prefab;
    public float damage=50;
    public float speed=5;
    public float cooldownDuration=3;
    public bool updraded=false;
    public int pierce;
    public bool enable;
    public LogicManager logic;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enable = false;
        pc = FindObjectOfType<PlayerController>();
        currentCooldown = cooldownDuration;

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (logic.score == 3)
        {
            enable = true;
        }
        if(logic.score%5==0 && logic.score!=0)
        {
            if (updraded == false)
            {
            var rand=Random.value;
            if (rand>0.5)
            {
                if(cooldownDuration>1)
                    cooldownDuration -= 1;
                else
                        speed += 1;
                }
            else
            {
                damage += 10;
            }
            }
            
            updraded = true;
        }
        if(logic.score % 5 != 0)
        {
            updraded=false;
        }
        
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f && enable == true){
            Attack();
        }
    }

    protected virtual void Attack(){
        currentCooldown = cooldownDuration;
    }
}
