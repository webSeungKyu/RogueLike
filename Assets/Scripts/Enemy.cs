using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f; // 몬스터 이동 속도
    private Transform player; // 플레이어의 위치를 저장하기 위한 변수
    private float lastMoveTime; // 마지막으로 몬스터가 이동한 시간
    private bool facingRight = true; // 몬스터의 방향 상태
    public Sprite hitSprite; // 맞았을 때 변경할 이미지
    public Sprite dieSprite; // 죽었을 때 변병할 이미지

    void Start()
    {
        // 플레이어 오브젝트를 찾아서 player 변수에 할당
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastMoveTime = Time.fixedTime; // 시작 시간 설정
    }


    void FixedUpdate()
    {
        if (player != null)
        {
            // 일정 시간 간격마다 몬스터 이동
            if (Time.fixedTime - lastMoveTime >= 0.1f) // 예시로 0.1초 간격으로 설정
            {
                // 플레이어의 위치를 바라보는 방향 벡터 계산
                Vector3 direction = player.position - transform.position;
                direction.Normalize(); // 방향 벡터 정규화

                // 몬스터를 플레이어 쪽으로 이동시킴
                transform.Translate(direction * moveSpeed * Time.deltaTime);

                // 몬스터 방향 변경
                if (direction.x < 0 && facingRight)
                {
                    Flip();
                }
                else if (direction.x > 0 && !facingRight)
                {
                    Flip();
                }

                lastMoveTime = Time.fixedTime; // 마지막 이동 시간 업데이트
            }
        }
    }

    // 몬스터 방향 전환 메서드
    void Flip()
    {
        facingRight = !facingRight; // 방향 상태 변경
        Vector3 scale = transform.localScale;
        scale.x *= -1; // x 축 방향 반전
        transform.localScale = scale;
    }
}
