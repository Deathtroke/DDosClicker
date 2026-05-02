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

}
