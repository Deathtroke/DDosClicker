using TMPro;
using UnityEngine;

public class DisplayCpS : MonoBehaviour
{
    public TMP_Text label;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(label != null)
        {
            label.text = "RpS" + GameManager.Instance.manualRpS;
        }
    }
}
