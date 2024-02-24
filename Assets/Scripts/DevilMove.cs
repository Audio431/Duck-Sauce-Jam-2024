using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3;
    public float moverate = 2;
    private float timer = 0;
    public float health = 150;
    public float atk = 30;
    public EnemyController controller;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        controller = GetComponent<EnemyController>();
        controller.SetHp(health);
        controller.SetAtk(atk);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < moverate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 1 || Mathf.Abs(transform.position.y - player.transform.position.y) <= 1)
            {
                var rand = Random.value;

                if (rand < 0.25)
                {
                    transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
                }
                else if (rand < 0.5)
                {
                    transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
                }
                else if (rand < 0.75)
                {
                    transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
                }
                else
                {
                    transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
                }
                if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 1 && Mathf.Abs(transform.position.y - player.transform.position.y) <= 1)
                {
                    rand = Random.value;
                    if (rand < 0.5)
                        controller.Attack();
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
            
            timer = 0;
        }

    }
}
