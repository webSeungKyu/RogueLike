using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange = 10f; //검색할 범위
    public LayerMask targetLayer; //검색할 레이어
    public RaycastHit2D[] targetList; //검색 후 저장할 리스트
    public static Transform nearTarget; //가장 가까운 거리에 있는 대상

    private void FixedUpdate()
    {
        //시작 위치, 검색할 범위(원의 반지름), 방향, 길이, 검색할 레이어
        targetList = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        
        nearTarget = GetNear();
    }

    Transform GetNear()
    {
        Transform temp = null;
        float diff = 100;
        foreach (RaycastHit2D target in targetList)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;

            //거리 계산
            float curDiff = Vector3.Distance(myPos, targetPos);

            if(curDiff < diff)
            {
                diff = curDiff;
                temp = target.transform;
            }
        }


        return temp;
    }
}
