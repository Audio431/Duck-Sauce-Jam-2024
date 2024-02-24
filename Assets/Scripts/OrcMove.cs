using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrcMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3;
    public float moverate = 2;
    private float timer = 0;
    public float health = 200;
    public EnemyController controller;
    private GameObject player;
    public GameObject healthbar;
    private Slider slider;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        controller = GetComponent<EnemyController>();
        controller.SetHp(health);

        healthbar = Instantiate(healthbar, transform.position + Vector3.up * .5f, transform.rotation);
        healthbar.transform.parent = transform;
        slider = healthbar.GetComponent<Slider>();
        slider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.transform.position = transform.position + Vector3.up * .5f;
        GetComponent<EnemyController>().SetHealthbar(slider);

        if (timer < moverate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {

            //var rand = Random.value;

            //if (rand < 0.25)
            //{
            //    transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
            //}
            //else if (rand < 0.5)
            //{
            //    transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
            //}
            //else if (rand < 0.75)
            //{
            //    transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
            //}
            //else
            //{
            //    transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

            //}
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            timer = 0;
        }

    }
}
