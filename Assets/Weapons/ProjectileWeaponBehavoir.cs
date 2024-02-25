using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehavoir : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject,destroyAfterSeconds);
    }  

    public void DirectChecker(Vector3 dir){
        Debug.Log(dir.x);
        direction = dir;
    }
}
