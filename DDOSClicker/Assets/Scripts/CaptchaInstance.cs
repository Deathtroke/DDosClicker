using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaptchaInstance : MonoBehaviour
{

    public List<CaptchaData> possibleCaptchas = new List<CaptchaData>();

    public CaptchaData captcha;

    public Button option1;
    public Button option2;
    public Button option3;
    public Button option4;

    public TMP_Text caption;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        captcha = possibleCaptchas[Random.Range(0, possibleCaptchas.Count)];
        option1.onClick.AddListener(click1);
        option2.onClick.AddListener(click2);
        option3.onClick.AddListener(click3);
        option4.onClick.AddListener(click4);
        option1.image.sprite = captcha.option1;
        option2.image.sprite = captcha.option2;
        option3.image.sprite = captcha.option3;
        option4.image.sprite = captcha.option4;
        caption.text = captcha.caption;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        option1.onClick.RemoveAllListeners();
        option2.onClick.RemoveAllListeners();
        option3.onClick.RemoveAllListeners();
        option4.onClick.RemoveAllListeners();
    }

    public void click1()
    {
        option1.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option1.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void click2()
    {
        option2.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option2.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void click3()
    {
        option3.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option3.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void click4()
    {
        option4.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option4.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void confirm()
    {
        if (option1.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[0]
            && option2.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[1]
            && option3.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[2]
            && option4.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[3])
        {
            Destroy(this.gameObject);
        }
    }
}
