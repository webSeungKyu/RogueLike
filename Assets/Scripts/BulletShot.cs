using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject bullet;
    float shotCoolTime = 1f;
    
    void Start()
    {

        InvokeRepeating("BulletInstantiate", 4f, shotCoolTime);
    }

    void BulletInstantiate()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }


}
