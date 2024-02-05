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


    // 徐々に近づける
    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 targetPos = transform.position + direction;
        if(IsWalkable(targetPos)==false)
        {
            isMoving = false;
            yield break;
        }

        // 現在のターゲットの場所が違うなら近づけ続ける
        while ((targetPos-transform.position).sqrMagnitude>Mathf.Epsilon)
        {
            // 近づける
            transform.position = Vector3.MoveTowards(transform.position,targetPos,5f*Time.deltaTime);// （現在地、目標値、速度）
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    // 特定の位置に移動できるか判定する関数
    bool IsWalkable(Vector3 targetPos)
    {
        // targetPosを中心に円形のRayを作る:SolidObjectsLayerにぶつかったらtrueが返ってくるのでfalse
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer)== false;
    }
}
