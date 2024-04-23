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
            //�̹� �����Ǿ��ִٸ� ���� ���� �� ����
            Destroy(this.gameObject);
        }
        //���� �Ѿ�� ������Ʈ ����
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
            Debug.Log("����");
            GameObject gameObject = GameObject.FindGameObjectWithTag("Pos");
            WeaponLvUp(gameObject);
        }
    }
}
