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

    public bool clickedOnce = false;

    public void click()
    {
        if (!clickedOnce)
            GameManager.Instance.NextLevel();
        clickedOnce = true;
    }
}
