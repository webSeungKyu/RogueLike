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