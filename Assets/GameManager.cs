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
    private int PAttack = 4;// プレイヤーの基礎攻撃力
   

    public GameObject cur;

    private int curNum = 0;
    
     
    private string[] EnemyName = { "スライム", "ゴブリン", "ゾンビ", "騎士", "ドラゴン" };
    private int [] EnemyHP= { 5, 10, 20, 50, 100 };
    private int[] EnemyAttack = { 3, 5, 7, 9, 11 };

    private int EnemyEncount = 0;


    private int EHP = 0; // 敵のHP
    

    private int Damage = 0; //プレイヤーの攻撃力
    private int Critical = 0;


    // Start is called before the first frame update
    void Start()
    {
        CurStart();
        //CurOff();
        EnemyEncount = Random.Range(0, 5); // 敵の情報をランダムに出す
        EHP = EnemyHP[EnemyEncount];　// randを代入する
        name = EnemyName[EnemyEncount];　// 上と同じ

        NametextCompornent.text = name; //敵の名前
        UItextComponent.text = name + "が現れた！";//UI
        HPtextComponent.text = "HP : " + EHP;// 敵のHP
    }

    // Update is called once per frame

    private void BattleStart()
    {
        EnemyEncount = Random.Range(0, 5);
        EHP = EnemyHP[EnemyEncount];　// randを代入する
        name = EnemyName[EnemyEncount];　// 上と同じ
    }
    void Update()
    {
      
        switch(faze)
        {
            case 0: // コマンド選択
                CurUpdate();
                UItextComponent.text = "攻撃\n魔法\n防御";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    
                    if (curNum == 0)
                    {
                        Critical =Random.Range(0, 100); // クリティカル判定
                        Damage = Random.Range(-2, 3); // プレイヤーの攻撃力にブレをつける
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

            case 1: // 与ダメログ
                HPtextComponent.text = "HP : " + EHP;
                UItextComponent.text = Damage + "のダメージを与えた";
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

            case 2: //戦闘勝利ログ
                UItextComponent.text = name + "を倒した！";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    BattleStart();
                    faze = 3;
                    SceneManager.LoadScene("FieldScene");
                }   
                break;

            case 3: //敵エンカウント
                NametextCompornent.text = name; //敵の名前
                UItextComponent.text = name + "が現れた！";//UI
                HPtextComponent.text = "HP : " + EHP;// 敵のHP
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    CurStart();
                    faze = 0;
                }
                break;

            case 4: // 魔法選択
                CurUpdate();
                UItextComponent.text = "フレア\nアイス\nボルト";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (curNum == 0)
                    {
                        if(EnemyEncount==0||EnemyEncount==2)
                        {
                            Damage = Random.Range(0, 3); // プレイヤーの攻撃力にブレをつける
                            Damage = (PAttack + Damage) * 2;
                            EHP -= Damage;

                            faze = 1;
                        }
                        if(EnemyEncount == 3 || EnemyEncount == 4)
                        {
                            Damage = Random.Range(0, 3); // プレイヤーの攻撃力にブレをつける
                            Damage = (PAttack + Damage) /2;
                            EHP -= Damage;

                            faze = 1;
                        }
                        if(EnemyEncount==1)
                        {
                            Damage = Random.Range(0, 3); // プレイヤーの攻撃力にブレをつける
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
                            Damage = Random.Range(4, 7); // プレイヤーの攻撃力にブレをつける
                            Damage = (PAttack + Damage);
                            EHP -= Damage;

                            faze = 1;
                        }
                        if (EnemyEncount == 3)
                        {
                            Damage = Random.Range(4, 7); // プレイヤーの攻撃力にブレをつける
                            Damage = (PAttack + Damage)*0;
                            EHP -= Damage;

                            faze = 1;
                        }
                        if (EnemyEncount == 4)
                        {
                            Damage = Random.Range(4, 7); // プレイヤーの攻撃力にブレをつける
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
                            Damage = Random.Range(2, 5); // プレイヤーの攻撃力にブレをつける
                            Damage = (PAttack + Damage) * 3;
                            EHP -= Damage;

                            faze = 1;
                        }
                        if (EnemyEncount == 4)
                        {
                            Damage = Random.Range(2, 5); // プレイヤーの攻撃力にブレをつける
                            Damage = (PAttack + Damage);
                            Damage = Damage + (Damage / 2);
                            EHP -= Damage;

                            faze = 1;
                        }
                        if (EnemyEncount == 0||EnemyEncount == 1||EnemyEncount == 2)
                        {
                            Damage = Random.Range(2, 5); // プレイヤーの攻撃力にブレをつける
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
        //        case 0:// プレイヤーの攻撃フェーズ
        //            if (curNum == 0)
        //            { 

        //                int Prand = Random.Range(-2, 3); // プレイヤーの攻撃力にブレをつける
        //                UItextComponent.text = (PAttack + Prand) + "のダメージを与えた";
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

        //    case 1:// コマンド選択
        //        UItextComponent.text = " 攻撃\n　防御\n　魔法";
             
                    
        //        CurStart();
        //        faze = 0;
                
                
        //        break;

        //    case 2://戦闘終了（勝利）
        //            UItextComponent.text = name+"を倒した！";
        //            faze = 3;
        //            break;

        //    case 3://戦闘開始
        //            Start();

        //            faze = 1;
        //            break;

        //    }
            
        //}
    }
    // カーソル移動処理
    private void CurUpdate()
    {
        // 下移動
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            curNum += 1;
            if (curNum >= 2) curNum = 2;
        }
        // 上移動
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            curNum -= 1;
            if (curNum <= 0) curNum = 0; 
        }
     
            // カーソル位置指定
            cur.transform.position = new Vector3(-8.0f, (curNum * -1.0f)-1, 0);
    }

    // カーソル初期化処理
    private void CurStart()
    {
        curNum = 0;
        cur.SetActive(true);
    }

    // カーソルオフ
    private void CurOff()
    {
        cur.SetActive(false);
    }
}
