using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float spawnRate = 2f;
    public float timer = 0;
    public int maxEnemy = 10;
    private List<GameObject> enemyList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyList.Count >=maxEnemy) {
        timer = 0;
        }
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            int rand = Random.Range(1, 4);
            if (rand==1){
                Generate(enemy1);
            }
            else if (rand == 2)
            {
                Generate(enemy2);
            }
            else { 
                Generate(enemy3);
            }
            
        }
        for (int i = enemyList.Count - 1; i >= 0; i--)
        {
            if (enemyList[i] == null)
            {
                enemyList.RemoveAt(i);
            }
        }
    }

    public void Generate(GameObject enemy)
    {
        GameObject e = Instantiate(enemy, (transform.position * (Random.value * 10)), transform.rotation);
        enemyList.Add(e);
        timer = 0;
    }
}
