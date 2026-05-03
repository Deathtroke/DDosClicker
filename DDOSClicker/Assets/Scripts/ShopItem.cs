using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class ShopItem : MonoBehaviour
{
    public Button upgradeButton;

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

        buyPriceText.SetText("Buy (" + device.startBuyPrice + ")");
        upgradePriceText.SetText("Upgrade (" + device.startUpgradePrice + ")");

        deviceCountText.SetText("0");
        upgradeCountText.SetText("0/" + device.maxUpgrades);

        upgradeButton.interactable = false;

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

        if(GameManager.Instance.boughtDevices[deviceType][0] == 1)
        {
            upgradeButton.interactable = true;
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

        if (GameManager.Instance.boughtDevices[deviceType][1] >= device.maxUpgrades)
        {
            upgradeButton.interactable = false;
            upgradePriceText.SetText("Upgrade MAX");
        }

        upgradeCountText.SetText(Mathf.Min(device.maxUpgrades, GameManager.Instance.boughtDevices[deviceType][1])
            + "/"
            + device.maxUpgrades
        );
    }
}
