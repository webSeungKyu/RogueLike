using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ� ������ ���� ����

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // SpriteRenderer ������Ʈ ����
    private Animator animator; // Animator ������Ʈ ����


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer ������Ʈ ��������
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������

    }


    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // ���� �� ���� �Է� �ޱ�
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ������ ���� ���
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Rigidbody2D�� �̿��Ͽ� ������Ʈ �̵�
        rb.velocity = movement * speed;

        // �̵� ���⿡ ���� ������Ʈ ������
        if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = true; // �������� �̵��ϸ� ������Ʈ�� ������
        }
        else if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = false; // ���������� �̵��ϸ� ������Ʈ�� ������� ����
        }

        // �̵� ���¿� ���� �ִϸ��̼� ���
        if (movement.magnitude > 0)
        {
            animator.SetBool("isMoving", true); // �̵� ���̸� isMoving �Ű������� true�� �����Ͽ� Move �ִϸ��̼� ���
        }
        else
        {
            animator.SetBool("isMoving", false); // ���� ���¸� isMoving �Ű������� false�� �����Ͽ� Idle �ִϸ��̼� ���
        }
    }

    public void Die()
    {
        // ���� ���� �ִϸ��̼��� ����ϱ� ���� Animator�� ���� ���¸� �˸��� �Ű������� ����
        animator.SetTrigger("Die");
    }


}
