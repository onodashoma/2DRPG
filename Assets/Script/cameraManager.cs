using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject target; // 追従する対象を決める変数
    Vector3 pos; // カメラの初期位置を記憶するための変数

    // Start is called before the first frame update
    void Start()
    {
        pos = Camera.main.gameObject.transform.position; // カメラの初期位置を変数posに入れる   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.transform.position; // cameraPosという変数を作り追従する対象の位置を入れる
        cameraPos.z = -10; // カメラの奥行きの位置に-10を入れる
        Camera.main.gameObject.transform.position = cameraPos; //　カメラの位置に変数cameraPosの位置を入れる
    }
}
