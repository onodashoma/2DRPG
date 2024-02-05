using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
//using UnityEditor.U2D.IK;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text UItextComponent;
    public Text HPtextComponent;
    public Text NametextCompornent;

    private int faze = 0;
    private int PAttack = 4;// �v���C���[�̊�b�U����
   

    public GameObject cur;

    private int curNum = 0;
    
     
    private string[] EnemyName = { "�X���C��", "�S�u����", "�]���r", "�R�m", "�h���S��" };
    private int [] EnemyHP= { 5, 10, 20, 50, 100 };
    private int[] EnemyAttack = { 3, 5, 7, 9, 11 };

    private int EnemyEncount = 0;


    private int EHP = 0; // �G��HP
    

    private int Damage = 0; //�v���C���[�̍U����
    private int Critical = 0;


    // Start is called before the first frame update
    void Start()
    {
        CurStart();
        //CurOff();
        EnemyEncount = Random.Range(0, 5); // �G�̏��������_���ɏo��
        EHP = EnemyHP[EnemyEncount];�@// rand��������
        name = EnemyName[EnemyEncount];�@// ��Ɠ���

        NametextCompornent.text = name; //�G�̖��O
        UItextComponent.text = name + "�����ꂽ�I";//UI
        HPtextComponent.text = "HP : " + EHP;// �G��HP
    }

    // Update is called once per frame

    private void BattleStart()
    {
        EnemyEncount = Random.Range(0, 5);
        EHP = EnemyHP[EnemyEncount];�@// rand��������
        name = EnemyName[EnemyEncount];�@// ��Ɠ���
    }
    void Update()
    {
      
        switch(faze)
        {
            case 0: // �R�}���h�I��
                CurUpdate();
                UItextComponent.text = "�U��\n���@\n�h��";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    
                    if (curNum == 0)
                    {
                        Critical =Random.Range(0, 100); // �N���e�B�J������
                        Damage = Random.Range(-2, 3); // �v���C���[�̍U���͂Ƀu��������
                        if (Critical > 80)
                        {
                            Damage = (PAttack + Damage)*2;
                            EHP -= Damage;
                        }
                        if (Critical < 80)
                        {
                            Damage = (PAttack + Damage);
                            EHP -= Damage;
                        }

                        faze = 1;
                        
                        CurOff();
                    }
                    if(curNum == 1)
                    {
                        faze = 4;
                        CurStart();
                    }
                    
                }
                break;

            case 1: // �^�_�����O
                HPtextComponent.text = "HP : " + EHP;
                UItextComponent.text = Damage + "�̃_���[�W��^����";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (EHP > 0)
                    {
                        faze = 0;
                        CurStart();
                    }
                    if (EHP <= 0)
                    {
                        faze = 2;
                    }
                }
                break;

            case 2: //�퓬�������O
                UItextComponent.text = name + "��|�����I";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    BattleStart();
                    faze = 3;
                    SceneManager.LoadScene("FieldScene");
                }   
                break;

            case 3: //�G�G���J�E���g
                NametextCompornent.text = name; //�G�̖��O
                UItextComponent.text = name + "�����ꂽ�I";//UI
                HPtextComponent.text = "HP : " + EHP;// �G��HP
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    CurStart();
                    faze = 0;
                }
                break;

            case 4: // ���@�I��
                CurUpdate();
                UItextComponent.text = "�t���A\n�A�C�X\n�{���g";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (curNum == 0)
                    {
                        if(EnemyEncount==0||EnemyEncount==2)
                        {
                            Damage = Random.Range(0, 3); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage) * 2;
                            EHP -= Damage;

                            faze = 1;
                        }
                        if(EnemyEncount == 3 || EnemyEncount == 4)
                        {
                            Damage = Random.Range(0, 3); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage) /2;
                            EHP -= Damage;

                            faze = 1;
                        }
                        if(EnemyEncount==1)
                        {
                            Damage = Random.Range(0, 3); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage);
                            EHP -= Damage;

                            faze = 1;
                            
                        }
                        
                        CurOff();
                    }

                    if (curNum == 1)
                    {
                        if (EnemyEncount == 0 || EnemyEncount == 1|| EnemyEncount == 2 )
                        {
                            Damage = Random.Range(4, 7); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage);
                            EHP -= Damage;

                            faze = 1;
                        }
                        if (EnemyEncount == 3)
                        {
                            Damage = Random.Range(4, 7); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage)*0;
                            EHP -= Damage;

                            faze = 1;
                        }
                        if (EnemyEncount == 4)
                        {
                            Damage = Random.Range(4, 7); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage) / 2;
                            EHP -= Damage;

                            faze = 1;

                        }

                        CurOff();
                    }

                    if (curNum == 2)
                    {
                        if (EnemyEncount == 3)
                        {
                            Damage = Random.Range(2, 5); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage) * 3;
                            EHP -= Damage;

                            faze = 1;
                        }
                        if (EnemyEncount == 4)
                        {
                            Damage = Random.Range(2, 5); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage);
                            Damage = Damage + (Damage / 2);
                            EHP -= Damage;

                            faze = 1;
                        }
                        if (EnemyEncount == 0||EnemyEncount == 1||EnemyEncount == 2)
                        {
                            Damage = Random.Range(2, 5); // �v���C���[�̍U���͂Ƀu��������
                            Damage = (PAttack + Damage);
                            EHP -= Damage;

                            faze = 1;

                        }

                        CurOff();
                    }
                }
                break;
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    switch (faze)
        //    {
        //        case 0:// �v���C���[�̍U���t�F�[�Y
        //            if (curNum == 0)
        //            { 

        //                int Prand = Random.Range(-2, 3); // �v���C���[�̍U���͂Ƀu��������
        //                UItextComponent.text = (PAttack + Prand) + "�̃_���[�W��^����";
        //                EHP -= PAttack + Prand;
        //                HPtextComponent.text = "HP : " + EHP;
        //                if (EHP > 0)
        //                {
        //                    faze = 1;
        //                }
        //                if (EHP <= 0)
        //                {

        //                    faze = 2;
        //                }
        //                CurOff();
        //            }

        //            if (curNum == 1)
        //            {
        //                faze = 0;
        //            }

        //            break;

        //    case 1:// �R�}���h�I��
        //        UItextComponent.text = " �U��\n�@�h��\n�@���@";
             
                    
        //        CurStart();
        //        faze = 0;
                
                
        //        break;

        //    case 2://�퓬�I���i�����j
        //            UItextComponent.text = name+"��|�����I";
        //            faze = 3;
        //            break;

        //    case 3://�퓬�J�n
        //            Start();

        //            faze = 1;
        //            break;

        //    }
            
        //}
    }
    // �J�[�\���ړ�����
    private void CurUpdate()
    {
        // ���ړ�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            curNum += 1;
            if (curNum >= 2) curNum = 2;
        }
        // ��ړ�
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            curNum -= 1;
            if (curNum <= 0) curNum = 0; 
        }
     
            // �J�[�\���ʒu�w��
            cur.transform.position = new Vector3(-8.0f, (curNum * -1.0f)-1, 0);
    }

    // �J�[�\������������
    private void CurStart()
    {
        curNum = 0;
        cur.SetActive(true);
    }

    // �J�[�\���I�t
    private void CurOff()
    {
        cur.SetActive(false);
    }
}
