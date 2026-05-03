using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public static Chat instance;

    public GameObject chatWindow;

    private bool isVisible = true;

    public GameObject chatMessagePrefab;
    public GameObject chatMessageLinkPrefab;

    public RectTransform chatView;

    private List<GameObject> history = new();

    private void Awake()
    {
        instance = this;
    }

    public void NewChat(string name, string message)
    {
        GameObject chat = Instantiate(chatMessagePrefab);

        chat.transform.SetParent(chatView, false);
        chat.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        chat.GetComponent<ChatMessage>().SetChatMessage(name, message);

        history.Add(chat);
    }

    public void NewChat(string[] names, string[] messages)
    {
        // TODO
    }

    public void NewChatLink(string name, string message)
    {
        GameObject chat = Instantiate(chatMessageLinkPrefab);

        chat.transform.SetParent(chatView, false);
        chat.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        chat.GetComponent<ChatMessage>().SetChatMessage(name, message);

        history.Add(chat);
    }

    public void DeleteChatHistory()
    {
        while (history.Count > 0)
        {
            GameObject obj = history[0];
            history.RemoveAt(0);
            Destroy(obj);
        }
    }

    public void OpenChat()
    {
        isVisible = true;
        chatWindow.SetActive(true);
    }

    public void CloseChat()
    {
        isVisible = false;
        chatWindow.SetActive(false);
    }
}
