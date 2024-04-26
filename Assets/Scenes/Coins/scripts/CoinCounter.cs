using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    [SerializeField] private TMP_Text coinText;
    [SerializeField] private int currentCoins = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString() + " / 15";
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "COINS: " + currentCoins.ToString() + " / 15";
    }
}
