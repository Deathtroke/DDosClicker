using UnityEditor.Hardware;
using UnityEngine;
using static GameManager;

[CreateAssetMenu(fileName ="Data", menuName ="ScriptableObjects/Captcha")]
public class CaptchaData : ScriptableObject
{
    public string caption;
    public Sprite option1;
    public Sprite option2;
    public Sprite option3;
    public Sprite option4;

    public bool[] correctOptions = new bool[4];

}
