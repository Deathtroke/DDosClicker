using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCpS : MonoBehaviour
{
    public TMP_Text label;
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(label != null)
        {
            label.text = "RpS" + GameManager.Instance.totalRpS;
        }
        if (slider != null)
        {
            slider.value = GameManager.Instance.totalRpS / GameManager.Instance.currentLevel.capacity;
        }
    }
}
