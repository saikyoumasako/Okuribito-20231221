using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera; // カメラオブジェクトの参照
    public GameObject kabuSpawner; // カブスポナーの参照
    public GameObject kabukaColliderOb;//カブコライダーの参照

    private float money = 0f;
    private float kabuka = 100f;
    private float fallkabuka = 0f;
    private float gameTime = 180f;
    public float increaseRange = 1.5f; // 増加の閾値を設定する
    public float initialY = -3.15f; // 初期のY座標
    public float kabukaIncrease = 10f; // Y座標が増加するごとのkabukaの増加量
    private float newYIncreases = 0f;

    private bool positionUp = false;
    private bool positionUpUp = false;
    private bool positionUpUpUp = false;
    private bool positionUpUpUpUp = false;

    public TMPro.TMP_Text moneyText;
    public TMPro.TMP_Text kabukaText;
    public TMPro.TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTime(); //時間経過
    }

    private void UpdateGameTime()
    {
        gameTime -= Time.deltaTime; // 経過時間を減算
        if (gameTime <= 0)
        {
            gameTime = 0; // 時間が0未満にならないようにする
            // 時間切れ時の処理を追加（ゲームオーバーなど）

        }
        timeText.text = Mathf.Round(gameTime).ToString(); // 時間を整数で表示
    }
    private void UpdateTexts() //カブ価と資産テキストを書き換える
    {
        kabukaText.text = Mathf.Floor(kabuka) + "%".ToString();
        moneyText.text =  Mathf.Floor(money).ToString();
    }

    public void FallKabuka(float fall) //下落したカブ
    {
        fallkabuka += fall / 10; //落ちたカブの10分の１がカブ価から減る
    }

    public void Kabukachange(float Yposition)　//カブ価を変える
    {
        if(Yposition > initialY)
        {
            newYIncreases = (Yposition - initialY); // 増加したY座標の個数
            //Debug.Log(newYIncreases);
            float kabukaIncreasevalue = newYIncreases * kabukaIncrease; // kabukaの増加量
            kabuka = 100 + kabukaIncreasevalue - fallkabuka;

            CheckPosition();
            UpdateTexts();
        }
    }

    void CheckPosition() //カブの高さが一定値以上超えたときに処理を行う
    {
        if(newYIncreases > increaseRange)
        {
            if (!positionUp)
            {
                CameraPosition();
                KabuSpawnerPosition();
                kabukaIncrease = kabukaIncrease * 2;
                positionUp = true;
            }

        }
        if (newYIncreases > increaseRange * 2) //2倍
        {
            if (!positionUpUp)
            {
                CameraPosition();
                KabuSpawnerPosition();
                kabukaIncrease = kabukaIncrease * 2;

                positionUpUp = true;
            }

        }
        if (newYIncreases > increaseRange * 3) //3倍
        {
            if (!positionUpUpUp)
            {
                CameraPosition();
                KabuSpawnerPosition();
                kabukaIncrease = kabukaIncrease * 2;

                positionUpUpUp = true;
            }

        }
        if (newYIncreases > increaseRange * 4) //4倍
        {
            if (!positionUpUpUpUp)
            {
                CameraPosition();
                KabuSpawnerPosition();
                kabukaIncrease = kabukaIncrease * 2;

                positionUpUpUpUp = true;
            }

        }


    }

    void CameraPosition()         // カメラオブジェクトのY座標を更新
    {
        float cameraY = mainCamera.transform.position.y; // 現在のY座標を取得
        float cameraYposition = cameraY + (increaseRange / 2); // newYIncreases分だけY座標を増加
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, cameraYposition, mainCamera.transform.position.z);
    }

    public void KabuSpawnerPosition() //カブスポーンポジション変更
    {
        float kabuSpawnerY = kabuSpawner.transform.position.y; // 現在のY座標を取得
        float kabuSpawnerYposition = kabuSpawnerY + (increaseRange * 0.8f);
        kabuSpawner.transform.position = new Vector3(kabuSpawner.transform.position.x, kabuSpawnerYposition, kabuSpawner.transform.position.z);
        kabukaColliderOb.GetComponent<KabukaCollider>().InitialPosition(increaseRange); //かぶかコライダーの上昇
    }



    public void MoneyIncrease(int value) //資産増加
    {
        money += value * (kabuka / 100);
        UpdateTexts();
    }

    public void MoneyDecrease(int value) //資産減算
    {
        kabuka -= value / 10;
        money -= value * (kabuka / 100);
        UpdateTexts();
    }
}
