using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject target; // �Ǐ]����Ώۂ����߂�ϐ�
    Vector3 pos; // �J�����̏����ʒu���L�����邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        pos = Camera.main.gameObject.transform.position; // �J�����̏����ʒu��ϐ�pos�ɓ����   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.transform.position; // cameraPos�Ƃ����ϐ������Ǐ]����Ώۂ̈ʒu������
        cameraPos.z = -10; // �J�����̉��s���̈ʒu��-10������
        Camera.main.gameObject.transform.position = cameraPos; //�@�J�����̈ʒu�ɕϐ�cameraPos�̈ʒu������
    }
}