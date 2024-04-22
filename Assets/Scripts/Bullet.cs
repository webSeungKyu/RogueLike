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
        SettingSpeed(15f);
        SettingDamage(5f);

        if(target == null)
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
                Debug.Log("����� ���� ��� ����� Null ����" + e);
                Destroy(gameObject);
            }



        }
        



    }

    protected override void Update()
    {
        base.Update();



    }

    private void FixedUpdate()
    {

        transform.Translate(target * speed * Time.fixedDeltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        GameManager.Instance.HitEnemy(collision.GetComponent<Enemy>(), power);
        
        if (!GameManager.Instance.penetrate)
        {
            Destroy(gameObject);
        }

    }
}
