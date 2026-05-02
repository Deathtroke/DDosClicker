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

    Sprite image;

    public float startRequestRate;
    public float requestRateIncrease;
    public float maxRequestRate;
}
