using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public static Chat instance;

    public GameObject chatMessagePrefab;
    public RectTransform chatView;

    private List<GameObject> history = new();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Test
        /*
        NewChat("Bernd", "Hallo?");
        NewChat("Dirk", "Ich bin auch dabei. Ach ne, das war ja Uwe. Wer bin ich? Wie bin ich hierhergekommen?");
        NewChat("Bernd", "Hey Dirk, was geht?");
        NewChat("Dirk", "Hallo?");
        */
    }

    public void NewChat(string name, string message)
    {
        GameObject chat = Instantiate(chatMessagePrefab);

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
}
