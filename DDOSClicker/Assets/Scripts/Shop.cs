using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    public GameObject shopWindow;

    private bool isVisible = false;

    // public GameObject chatMessagePrefab;
    // public RectTransform chatView;

    private void Awake()
    {
        instance = this;
    }

    /*
    public void NewChat(string name, string message)
    {
        GameObject chat = Instantiate(chatMessagePrefab);

        chat.transform.SetParent(chatView, false);
        chat.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        chat.GetComponent<ChatMessage>().SetChatMessage(name, message);
    }
    */

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
