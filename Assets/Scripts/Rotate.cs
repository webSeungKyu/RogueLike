using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : WeaponSetting
{
    protected Rotate(int lv, bool lvMax, float speed, float power) : base(lv, lvMax, speed, power)
    {
    }

    Transform player;
    protected override void Start()
    {
        base.Start();
        penetrate = true;
        SettingSpeed(300f);
        SettingPower(3f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {

        transform.RotateAround(player.position, Vector3.back, speed * Time.fixedDeltaTime);
    }
}
