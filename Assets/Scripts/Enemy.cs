using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f; // ���� �̵� �ӵ�
    private Transform player; // �÷��̾��� ��ġ�� �����ϱ� ���� ����
    private float lastMoveTime; // ���������� ���Ͱ� �̵��� �ð�
    private bool facingRight = true; // ������ ���� ����
    public Sprite hitSprite; // �¾��� �� ������ �̹���
    public Sprite dieSprite; // �׾��� �� ������ �̹���

    void Start()
    {
        // �÷��̾� ������Ʈ�� ã�Ƽ� player ������ �Ҵ�
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastMoveTime = Time.fixedTime; // ���� �ð� ����
    }


    void FixedUpdate()
    {
        if (player != null)
        {
            // ���� �ð� ���ݸ��� ���� �̵�
            if (Time.fixedTime - lastMoveTime >= 0.1f) // ���÷� 0.1�� �������� ����
            {
                // �÷��̾��� ��ġ�� �ٶ󺸴� ���� ���� ���
                Vector3 direction = player.position - transform.position;
                direction.Normalize(); // ���� ���� ����ȭ

                // ���͸� �÷��̾� ������ �̵���Ŵ
                transform.Translate(direction * moveSpeed * Time.deltaTime);

                // ���� ���� ����
                if (direction.x < 0 && facingRight)
                {
                    Flip();
                }
                else if (direction.x > 0 && !facingRight)
                {
                    Flip();
                }

                lastMoveTime = Time.fixedTime; // ������ �̵� �ð� ������Ʈ
            }
        }
    }

    // ���� ���� ��ȯ �޼���
    void Flip()
    {
        facingRight = !facingRight; // ���� ���� ����
        Vector3 scale = transform.localScale;
        scale.x *= -1; // x �� ���� ����
        transform.localScale = scale;
    }
}
