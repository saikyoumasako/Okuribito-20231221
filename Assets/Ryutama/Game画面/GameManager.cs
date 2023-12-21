using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private float money = 0f;
    private float kabuka = 100f;
    private float gameTime = 180f;

    public float initialY = -3.15f; // 初期のY座標
    public float kabukaIncrease = 10; // Y座標が増加するごとのkabukaの増加量

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
    private void UpdateTexts()
    {
        kabukaText.text = Mathf.Floor(kabuka) + "%".ToString();
        moneyText.text =  Mathf.Floor(money).ToString();
    }

    public void Kabukachange(float Yposition)
    {
        Debug.Log(Yposition);
        if(Yposition > initialY)
        {
            int newYIncreases = Mathf.FloorToInt((Yposition - initialY) + 3.15f); // 増加したY座標の個数
            Debug.Log(newYIncreases);
            float kabukaIncreasevalue = newYIncreases * kabukaIncrease; // kabukaの増加量
            kabuka += kabukaIncreasevalue;

            UpdateTexts();

            // Y座標を初期化する
            initialY = Yposition;
        }
    }

    public void MoneyIncrease(int value)
    {
        money += value * (kabuka / 100);
        UpdateTexts();
    }

    public void MoneyDecrease(int value)
    {
        kabuka -= value / 10;
        money -= value * (kabuka / 100);
        UpdateTexts();
    }
}
