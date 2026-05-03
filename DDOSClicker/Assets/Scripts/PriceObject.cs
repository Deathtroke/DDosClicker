using UnityEditor.Hardware;
using UnityEngine;
using static GameManager;

[CreateAssetMenu(fileName ="Data", menuName ="ScriptableObjects/Prices")]
public class Device : ScriptableObject
{
    public devices device;
    public float startBuyPrice;
    public float priceBuyIncrease;
    public float startUpgradePrice;
    public float priceUpgradeIncrease;

    public Sprite image;
    public string deviceName;
    public string description;

    public float startRequestRate;
    public float requestRateIncrease;
    public float maxRequestRate;

    public int maxUpgrades;
}
