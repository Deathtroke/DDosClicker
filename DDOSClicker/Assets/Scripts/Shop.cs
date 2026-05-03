using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    public GameObject shopWindow;

    private bool isVisible = false;

    public GameObject shopItemPrefab;
    public RectTransform shopView;

    public Device[] testDevices;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = testDevices.Length - 1; i >= 0; i--)
        {
            Device device = testDevices[i];

            if (device != null)
            {
                AddShopItem(device);
            }
        }
    }

    public void AddShopItem(Device device)
    {
        GameObject deviceItem = Instantiate(shopItemPrefab);

        deviceItem.transform.SetParent(shopView, false);
        deviceItem.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        deviceItem.GetComponent<ShopItem>().SetShopItem(device);
    }

    public void OpenShop()
    {
        isVisible = true;
        shopWindow.SetActive(true);
    }

    public void CloseShop()
    {
        isVisible = false;
        shopWindow.SetActive(false);
    }
}
