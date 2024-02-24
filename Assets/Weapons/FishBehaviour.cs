using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : ProjectileWeaponBehavoir
{
    FishController kc;
    public LayerMask interactableLayer;
    public float dmg = 100;

    protected override void Start()
    {   
        base.Start();
        kc = FindObjectOfType<FishController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * kc.speed * Time.deltaTime;
        var collider = Physics2D.OverlapCircle(transform.position, 0.2f, interactableLayer);
        if (collider != null)
        {
            //Debug.Log("ther is a npc here");
            collider.GetComponent<Enemy>()?.Damage(dmg);
            Destroy(gameObject);

        }
    }
}
