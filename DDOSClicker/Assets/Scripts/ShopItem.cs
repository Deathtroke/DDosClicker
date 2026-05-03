using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class ShopItem : MonoBehaviour
{
    public Image image;
    public TMP_Text title;
    public TMP_Text description;
    public TMP_Text buyPriceText, upgradePriceText;
    public TMP_Text deviceCountText, upgradeCountText;

    private devices deviceType;
    private Device device;

    public void SetShopItem(Device device)
    {
        image.sprite = device.image;
        title.SetText(device.deviceName);
        description.SetText(device.description);

        buyPriceText.SetText(device.startBuyPrice.ToString());
        upgradePriceText.SetText(device.startUpgradePrice.ToString());

        deviceCountText.SetText("0");
        upgradeCountText.SetText("0/" + device.maxUpgrades);

        deviceType = device.device;
        this.device = device;
    }

    public void TryBuyDevice()
    {
        int nextPrice = GameManager.Instance.BuyDevice(deviceType);

        if (nextPrice > 0)
        {
            buyPriceText.SetText("Buy (" + GameManager.Instance.bigNumber(nextPrice) + ",-)");
        }

        deviceCountText.SetText(GameManager.Instance.boughtDevices[deviceType][0].ToString());
    }

    public void TryBuyUpgrade()
    {
        int nextPrice = GameManager.Instance.BuyUpgrades(deviceType);

        if (nextPrice > 0)
        {
            upgradePriceText.SetText("Upgrade (" + GameManager.Instance.bigNumber(nextPrice) + ",-)");
        }

        upgradeCountText.SetText(Mathf.Min(device.maxUpgrades, GameManager.Instance.boughtDevices[deviceType][1]).ToString()
            + "/"
            + GameManager.Instance.boughtDevices[deviceType][1]
        );
    }
}
