using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class ShopItem : MonoBehaviour
{
    public Image image;
    public TMP_Text title;
    public TMP_Text description;
    public TMP_Text priceText;
    public TMP_Text youGotCountText;

    private devices device;
    bool isDevice = true;

    public void SetShopItem(Device device, bool asDevice)
    {
        if(asDevice)
        {
            image.sprite = device.deviceImage;
            title.SetText(device.deviceName);
            description.SetText(device.deviceDescription);
        }
        else
        {
            image.sprite = device.upgradeImage;
            title.SetText(device.upgradeName);
            description.SetText(device.upgradeDescription);
        }

        if (asDevice)
        {
            priceText.SetText(device.startBuyPrice.ToString());
        }
        else
        {
            priceText.SetText(device.startUpgradePrice.ToString());
        }

        this.device = device.device;
        isDevice = asDevice;

        youGotCountText.SetText("0");
    }

    public void TryBuyItem()
    {
        if (isDevice)
        {
            int nextPrice = GameManager.Instance.BuyDevice(device);

            if (nextPrice > 0)
            {
                priceText.text = nextPrice.ToString();
            }

            youGotCountText.text = GameManager.Instance.boughtDevices[device][0].ToString();
        }
        else
        {
            int nextPrice = GameManager.Instance.BuyUpgrades(device);

            if (nextPrice > 0)
            {
                priceText.text = nextPrice.ToString();
            }

            youGotCountText.text = GameManager.Instance.boughtDevices[device][1].ToString();
        }
    }
}
