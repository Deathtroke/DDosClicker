using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using static GameManager;

public class EconomyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static EconomyManager Instance { get; private set; }

    public float fame = 10000;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }



    public List<Device> Prices = new List<Device>();



    private void FixedUpdate()
    {
 

    }

    public int nextPuyPrice(devices device, int amount = 1)
    {
        if (amount == 0) return 0;
        amount -= 1;
        Device deviceData = Prices.FirstOrDefault(x => x.device == device);
        int deviceAmount = amount;
        if (GameManager.Instance.boughtDevices.ContainsKey(device)) deviceAmount += GameManager.Instance.boughtDevices[device][0];
        return (int)(deviceData.startBuyPrice + math.pow(deviceData.priceBuyIncrease, deviceAmount)) + nextPuyPrice(device, amount);
    }

    public int nextUpgradePrice(devices device, int amount = 1)
    {
        if (amount == 0) return 0;
        amount -= 1;
        Device deviceData = Prices.FirstOrDefault(x => x.device == device);
        int deviceAmount = amount;
        if (GameManager.Instance.boughtDevices.ContainsKey(device)) deviceAmount += GameManager.Instance.boughtDevices[device][1];
        return (int)(deviceData.startUpgradePrice + math.pow(deviceData.priceUpgradeIncrease, deviceAmount)) + nextPuyPrice(device, amount);
    }

    public float getRequestRate(devices device)
    {
        if (!GameManager.Instance.boughtDevices.ContainsKey(device)) return 0;
        Device deviceData = Prices.FirstOrDefault(x => x.device == device);
        int amount = GameManager.Instance.boughtDevices[device][0];
        int level = GameManager.Instance.boughtDevices[device][1];

        return math.clamp(deviceData.startRequestRate +deviceData.requestRateIncrease * level, 0, deviceData.maxRequestRate) * amount;

    }
}
