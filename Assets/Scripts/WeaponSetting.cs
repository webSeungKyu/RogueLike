using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetting : MonoBehaviour
{
    protected int lv;
    protected bool lvMax;
    protected float speed;
    protected float power;

    protected WeaponSetting(int lv, bool lvMax, float speed, float power)
    {
        this.lv = lv;
        this.lvMax = lvMax;
        this.speed = speed;
        this.power = power;
        
    }

    protected virtual void Start()
    {
        SettingLv(0);
    }

    protected virtual void Update()
    {

    }

    protected virtual void SettingLv(int lv)
    {
        this.lv = lv;
    }

    protected virtual void SettingSpeed(float speed)
    {
        this.speed = speed;
    }

    protected virtual void SettingLvMax(bool onOff)
    {
        this.lvMax = onOff;
    }

    protected virtual void SettingDamage(float power)
    {
        this.power = power;
    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
