using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 75;
    public float moverate = 2;
    private float timer = 0;
    public float health = 170;
    public EnemyController controller;
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
            timer = 0;
        }

    }
}
