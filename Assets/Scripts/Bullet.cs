using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : WeaponSetting
{
    protected Bullet(int lv, bool lvMax, float speed, float damage) : base(lv, lvMax, speed, damage)
    {

    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

    }
}
