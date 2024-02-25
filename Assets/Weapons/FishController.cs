using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : WeaponController
{
    // Start is called before the first frame update
    protected override void Attack(){
        base.Attack();
        GameObject spawnedFish = Instantiate(data.prefab);
        spawnedFish.transform.position = transform.position;
        spawnedFish.transform.position = spawnedFish.transform.position + new Vector3(0.5f,0.5f);
        spawnedFish.GetComponent<FishBehaviour>().DirectChecker(pc.LastmoveVector);
    }
}
