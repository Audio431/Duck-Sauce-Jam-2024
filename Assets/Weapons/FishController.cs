using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : WeaponController
{
    [SerializeField] private AudioClip attackClip;

    // Start is called before the first frame update
    protected override void Attack(){
        base.Attack();
        GameObject spawnedFish = Instantiate(prefab);
        SoundFXManager.instance.PlaySoundFXClip(attackClip, transform, 0.2f);
        spawnedFish.transform.position = transform.position;
        spawnedFish.transform.position = spawnedFish.transform.position + new Vector3(0.5f,0.5f);
        spawnedFish.GetComponent<FishBehaviour>().DirectChecker(pc.LastmoveVector);
    }
}
