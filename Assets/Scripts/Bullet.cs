using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : WeaponSetting
{
    public Vector2 target;
    protected Bullet(int lv, bool lvMax, float speed, float damage) : base(lv, lvMax, speed, damage)
    {

    }

    protected override void Start()
    {
        base.Start();
        SettingSpeed(5f);
        if (Scanner.nearTarget)
        {
            target = Scanner.nearTarget.position - transform.position;
            target.Normalize();
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
}
