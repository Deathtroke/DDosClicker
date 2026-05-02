using TMPro;
using UnityEngine;

public class DisplayPrices : MonoBehaviour
{
    public TMP_Text FridgeBuy1;
    public TMP_Text FridgeBuy10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FridgeBuy1 != null)
        {
            FridgeBuy1.text = "buy Fridge"+ EconomyManager.Instance.nextPuyPrice(GameManager.devices.Fridge, 1);
        }
        if (FridgeBuy10 != null)
        {
            FridgeBuy10.text = "buy 10 Fridge" + GameManager.Instance.bigNumber(EconomyManager.Instance.nextPuyPrice(GameManager.devices.Fridge, 10));
        }
    }
}
