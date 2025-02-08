using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject gameObject;
    private void OnTriggerEnter(Collider other) 
    {
        CoinsCounter.Instance.IncreaseCoins();
        Destroy(gameObject);
    }
}
