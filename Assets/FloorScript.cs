using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private float width;
    private float height;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<BoxCollider2D>().bounds.size.x;
        height = GetComponent<BoxCollider2D>().bounds.size.y;
        player = GameObject.FindWithTag("Player");
        Debug.Log("Hello");
        Debug.Log(width);
    }

    // Update is called once per frame
    void Update()
    {
        //return;
        if (player.transform.position.x >= transform.position.x + width / 2)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, 0);
        }
        else if (player.transform.position.x <= transform.position.x - width / 2)
        {
            transform.position = new Vector3(player.transform.position.x - width, transform.position.y, 0);
        }

        if (player.transform.position.y >= transform.position.y + height / 2)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + height, 0);
        }
        else if (player.transform.position.y <= transform.position.y - height / 2)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, 0);
        }
    }
}
