using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;

    string displayMoney;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.GetMoney());
        float money = GameManager.GetMoney();
        string displayMoney = CalcMoney(money);
        moneyText.text = displayMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string CalcMoney(float money)
    {
        displayMoney = "";

        const int TEN_THOUSAND = 10000;

        if (money > 0)
        {
            int tenThousand = Mathf.FloorToInt(money / TEN_THOUSAND);

            if (tenThousand > 0)
            {
                displayMoney += $"{tenThousand}億";
            }

            int fourDigits = Mathf.FloorToInt(money % TEN_THOUSAND);

            if (fourDigits > 0)
            {
                displayMoney += $"{fourDigits}万";
            }
        }
        else
        {
            displayMoney = "0";
        }

        return displayMoney;
    }
    //void CalcMoney()
    //{
    //    // 数字が5桁以上の場合
    //    if (money >= 10000)
    //    {
    //        int tenThousand = Mathf.FloorToInt(money / 10000); // 万の位を取得
    //        int billion = Mathf.FloorToInt(money / 100000000); // 億の位を取得

    //        if (billion > 0)
    //        {
    //            displayMoney = $"{billion}億";
    //        }

    //        int remainder = Mathf.FloorToInt(money % 100000000); // 億以上の部分の計算

    //        if (remainder > 0)
    //        {
    //            displayMoney += $"{tenThousand}万";
    //        }
    //    }
    //    // 数字が4桁以下の場合
    //    else if (money < 10000)
    //    {
    //        displayMoney = $"{money}万";
    //    }

    //    moneyText.text = displayMoney;


    //}
}
