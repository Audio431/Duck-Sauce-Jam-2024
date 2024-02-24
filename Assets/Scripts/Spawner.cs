using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 2f;
    public float timer = 0;
    public int maxEnemy = 10;
    private List<GameObject> enemyList = new List<GameObject>();
    public GameObject[] enemyArray;


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
            foreach(GameObject obj in enemyArray) {
            var i=Random.value;
                if (i > 0.5)
                {
                    Generate(obj);
                }
                {
                    
                }
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
        GameObject e = Instantiate(enemy, (transform.position + (new Vector3(1,1,0) *Random.value * 10)), transform.rotation);
        enemyList.Add(e);
        timer = 0;
    }
}
