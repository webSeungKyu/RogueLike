using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetting : MonoBehaviour
{
    protected int lv;
    protected bool lvMax;
    protected float speed;
    protected float power;
    protected bool penetrate = false; //ฐüล๋ทย
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

    public virtual void SettingLv(int lv)
    {
        this.lv += lv;
    }

    public virtual void SettingSpeed(float speed)
    {
        this.speed += speed;
    }

    public virtual void SettingLvMax(bool onOff)
    {
        this.lvMax = onOff;
    }

    public virtual void SettingPower(float power)
    {
        this.power += power;
    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        GameManager.Instance.HitEnemy(collision.GetComponent<Enemy>(), power);

        if (!penetrate)
        {
            Destroy(gameObject);
        }

    }
}
