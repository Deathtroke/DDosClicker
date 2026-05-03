using Unity.Collections;
using UnityEditor.Hardware;
using UnityEngine;
using static GameManager;

[CreateAssetMenu(fileName ="Data", menuName ="ScriptableObjects/Websites")]
public class Websites : ScriptableObject
{
    public string webisteName;
    public float capacity;
    public float passiveIncome;
    public float onDDoS;

    public Sprite WebsiteUp;
    public Sprite WebsiteDown;

    public float captchaRate;
    [ReadOnly] public float lastCaptcha = 0;
    public int packageFilter;
    public float rateLimiting;

    public string nameLoadChat;
    public string contentLoadChat;

    public string nameCompleteChat;
    public string contentCompleteChat;

    public string linkToNextLevel;
}
