using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject bullet;
    public float shotCoolTime = 1f;
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

    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (player.GetComponent<SpriteRenderer>().flipX)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(player.transform.position.x - 0.4f, transform.position.y);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector2(player.transform.position.x + 0.4f, transform.position.y);
        }
        
    }
}