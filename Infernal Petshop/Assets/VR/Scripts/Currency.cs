using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency currency;
    [SerializeField] private int money;
    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            if (money < 0) money = 0;
            moneyText.text = "$$: " + money.ToString();
        }
    }

    [SerializeField] private TextMeshProUGUI moneyText;
    private void Awake()
    {
        if (currency == null) currency = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        moneyText.text = "$$: " + money.ToString();
    }
}
