using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            //이미 생성되어있다면 새로 만든 거 삭제
            Destroy(this.gameObject);
        }
        //씬이 넘어가도 오브젝트 유지
        DontDestroyOnLoad(this.gameObject);
    }



    public void HitEnemy(Enemy enemy, float damage)
    {
        enemy.hp -= damage;
        if (enemy.hp <= 0)
        {
            enemy.Die();
        }
    }

    public void WeaponLvUp(GameObject weapon)
    {
        weapon.GetComponent<BulletShot>().bullet.GetComponent<Bullet>().SettingLv(1);
        weapon.GetComponent<BulletShot>().bullet.GetComponent<Bullet>().SettingSpeed(111);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("업업");
            GameObject gameObject = GameObject.FindGameObjectWithTag("Pos");
            WeaponLvUp(gameObject);
        }
    }
}
