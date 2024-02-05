using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectsLayer;
    

    bool isMoving;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("BattleScene");
        }
            
        if(isMoving==false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if(x !=0)
            {
                y = 0;
            }

            StartCoroutine(Move(new Vector2(x, y)));

        }

        
    }


    // ���X�ɋ߂Â���
    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 targetPos = transform.position + direction;
        if(IsWalkable(targetPos)==false)
        {
            isMoving = false;
            yield break;
        }

        // ���݂̃^�[�Q�b�g�̏ꏊ���Ⴄ�Ȃ�߂Â�������
        while ((targetPos-transform.position).sqrMagnitude>Mathf.Epsilon)
        {
            // �߂Â���
            transform.position = Vector3.MoveTowards(transform.position,targetPos,5f*Time.deltaTime);// �i���ݒn�A�ڕW�l�A���x�j
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    // ����̈ʒu�Ɉړ��ł��邩���肷��֐�
    bool IsWalkable(Vector3 targetPos)
    {
        // targetPos�𒆐S�ɉ~�`��Ray�����:SolidObjectsLayer�ɂԂ�������true���Ԃ��Ă���̂�false
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer)== false;
    }
}
