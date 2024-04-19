using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // 이동 속도 조절을 위한 변수

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // SpriteRenderer 컴포넌트 참조
    private Animator animator; // Animator 컴포넌트 참조


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 컴포넌트 가져오기
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기

    }


    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // 수평 및 수직 입력 받기
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 움직임 벡터 계산
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Rigidbody2D를 이용하여 오브젝트 이동
        rb.velocity = movement * speed;

        // 이동 방향에 따라 오브젝트 뒤집기
        if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = true; // 왼쪽으로 이동하면 오브젝트를 뒤집음
        }
        else if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = false; // 오른쪽으로 이동하면 오브젝트를 원래대로 복원
        }

        // 이동 상태에 따라 애니메이션 재생
        if (movement.magnitude > 0)
        {
            animator.SetBool("isMoving", true); // 이동 중이면 isMoving 매개변수를 true로 설정하여 Move 애니메이션 재생
        }
        else
        {
            animator.SetBool("isMoving", false); // 정지 상태면 isMoving 매개변수를 false로 설정하여 Idle 애니메이션 재생
        }
    }

    public void Die()
    {
        // 죽음 상태 애니메이션을 재생하기 위해 Animator에 죽음 상태를 알리는 매개변수를 설정
        animator.SetTrigger("Die");
    }


}
