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
        // 타이머 업데이트
        timer += Time.fixedDeltaTime;

        // 일정 간격마다 총알 생성
        if (timer >= shotCoolTime)
        {
            BulletInstantiate();
            // 타이머 초기화
            timer = 0f;
        }
    }

    void BulletInstantiate()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}