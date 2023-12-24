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
                displayMoney += $"{tenThousand}��";
            }

            int fourDigits = Mathf.FloorToInt(money % TEN_THOUSAND);

            if (fourDigits > 0)
            {
                displayMoney += $"{fourDigits}��";
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
    //    // ������5���ȏ�̏ꍇ
    //    if (money >= 10000)
    //    {
    //        int tenThousand = Mathf.FloorToInt(money / 10000); // ���̈ʂ��擾
    //        int billion = Mathf.FloorToInt(money / 100000000); // ���̈ʂ��擾

    //        if (billion > 0)
    //        {
    //            displayMoney = $"{billion}��";
    //        }

    //        int remainder = Mathf.FloorToInt(money % 100000000); // ���ȏ�̕����̌v�Z

    //        if (remainder > 0)
    //        {
    //            displayMoney += $"{tenThousand}��";
    //        }
    //    }
    //    // ������4���ȉ��̏ꍇ
    //    else if (money < 10000)
    //    {
    //        displayMoney = $"{money}��";
    //    }

    //    moneyText.text = displayMoney;


    //}
}
