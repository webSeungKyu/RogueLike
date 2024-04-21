using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange = 10f; //�˻��� ����
    public LayerMask targetLayer; //�˻��� ���̾�
    public RaycastHit2D[] targetList; //�˻� �� ������ ����Ʈ
    public static Transform nearTarget; //���� ����� �Ÿ��� �ִ� ���

    private void FixedUpdate()
    {
        //���� ��ġ, �˻��� ����(���� ������), ����, ����, �˻��� ���̾�
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

            //�Ÿ� ���
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
