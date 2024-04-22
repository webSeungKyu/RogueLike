using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject bullet;
    float shotCoolTime = 1f;
    float timer = 0f;

    private void FixedUpdate()
    {
        // Ÿ�̸� ������Ʈ
        timer += Time.fixedDeltaTime;

        // ���� ���ݸ��� �Ѿ� ����
        if (timer >= shotCoolTime)
        {
            BulletInstantiate();
            // Ÿ�̸� �ʱ�ȭ
            timer = 0f;
        }
    }

    void BulletInstantiate()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}