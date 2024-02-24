using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 75;
    public float moverate = 2;
    private float timer = 0;
    public float health = 150;
    public EnemyController controller;
    public GameObject player;
    public float distance;
    void Start()
    {
        controller = GetComponent<EnemyController>();
        controller.SetHp(health);


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
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            if (distance < 4) { 
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed*Time.deltaTime);
            }
            /*var rand = Random.value;

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

            }*/
            timer = 0;
        }

    }
}
