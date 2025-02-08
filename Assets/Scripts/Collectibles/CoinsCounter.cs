using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter Instance;
    
    public TextMeshProUGUI coins;
    public int currentCoins = 0;
    private void Awake() 
    {
        Instance = this;
    }
    void Start()
    {
        coins.text = "Coins: " + currentCoins;
    }

    public void IncreaseCoins()
    {
        currentCoins += 1;
        coins.text = "Coins: " + currentCoins;
    }
}
