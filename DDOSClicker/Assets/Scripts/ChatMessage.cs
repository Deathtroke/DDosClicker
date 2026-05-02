using TMPro;
using UnityEngine;

public class ChatMessage : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text messageText;

    public void SetChatMessage(string name, string message)
    {
        nameText.SetText(name);
        messageText.SetText(message);
    }
}
