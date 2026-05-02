using UnityEngine;
using static GameManager;


public class UpgradeButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyFridge1()
    {
        GameManager.Instance.BuyDevice(devices.Fridge, 1);
    }
    public void buyFridge5()
    {
        GameManager.Instance.BuyDevice(devices.Fridge, 5);
    }

    public void buyFridge10()
    {
        GameManager.Instance.BuyDevice(devices.Fridge, 10);
    }
}
