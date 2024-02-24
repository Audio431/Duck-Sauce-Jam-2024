using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : ProjectileWeaponBehavoir
{
    FishController kc;
    protected override void Start()
    {   
        base.Start();
        kc = FindObjectOfType<FishController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * kc.speed * Time.deltaTime; 
    }
}
