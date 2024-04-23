using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : WeaponSetting
{
    public Vector2 target;
    public bool shotOnOff = true;
    protected Bullet(int lv, bool lvMax, float speed, float power) : base(lv, lvMax, speed, power)
    {

        
    }



    protected override void Start()
    {
        base.Start();
        this.power = 1;
        this.speed = 20f;
        if (target == null)
        {
            return;
        }
        else
        {
            try
            {
                target = Scanner.nearTarget.position - transform.position;
                target.Normalize();
            }
            catch(NullReferenceException e)
            {
                Debug.Log("가까운 적이 없어서 생기는 Null 오류" + e);
                Destroy(gameObject);
            }



        }
        



    }

    protected override void Update()
    {
        base.Update();

        Debug.Log(lv);

    }

    private void FixedUpdate()
    {

        transform.Translate(target * speed * Time.fixedDeltaTime);


    }


}
