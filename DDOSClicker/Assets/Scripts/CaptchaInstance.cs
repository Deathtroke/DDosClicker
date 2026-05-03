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
    public Button option5;
    public Button option6;
    public Button option7;
    public Button option8;
    public Button option9;

    public TMP_Text caption;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        captcha = possibleCaptchas[Random.Range(0, possibleCaptchas.Count)];
        option1.onClick.AddListener(click1);
        option2.onClick.AddListener(click2);
        option3.onClick.AddListener(click3);
        option4.onClick.AddListener(click4);
        option5.onClick.AddListener(click5);
        option6.onClick.AddListener(click6);
        option7.onClick.AddListener(click7);
        option8.onClick.AddListener(click8);
        option9.onClick.AddListener(click9);
        option1.image.sprite = captcha.option1;
        option2.image.sprite = captcha.option2;
        option3.image.sprite = captcha.option3;
        option4.image.sprite = captcha.option4;
        option5.image.sprite = captcha.option5;
        option6.image.sprite = captcha.option6;
        option7.image.sprite = captcha.option7;
        option8.image.sprite = captcha.option8;
        option9.image.sprite = captcha.option9;
        caption.text = captcha.caption;

        GameManager.Instance.captcha = this;
    }

    public void InitializeNew()
    {
        captcha = possibleCaptchas[Random.Range(0, possibleCaptchas.Count)];
        option1.image.sprite = captcha.option1;
        option2.image.sprite = captcha.option2;
        option3.image.sprite = captcha.option3;
        option4.image.sprite = captcha.option4;
        option5.image.sprite = captcha.option5;
        option6.image.sprite = captcha.option6;
        option7.image.sprite = captcha.option7;
        option8.image.sprite = captcha.option8;
        option9.image.sprite = captcha.option9;

        option1.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        option2.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        option3.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        option4.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        option5.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        option6.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        option7.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        option8.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        option9.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        caption.text = captcha.caption;
        gameObject.SetActive(true);
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
        option5.onClick.RemoveAllListeners();
        option6.onClick.RemoveAllListeners();
        option7.onClick.RemoveAllListeners();
        option8.onClick.RemoveAllListeners();
        option9.onClick.RemoveAllListeners();

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

    public void click5()
    {
        option5.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option5.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void click6()
    {
        option6.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option6.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void click7()
    {
        option7.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option7.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void click8()
    {
        option8.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option8.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void click9()
    {
        option9.gameObject.transform.GetChild(0).gameObject.SetActive(
            !option9.gameObject.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void confirm()
    {
        if (option1.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[0]
            && option2.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[1]
            && option3.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[2]
            && option4.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[3]
            && option5.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[4]
            && option6.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[5]
            && option7.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[6]
            && option8.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[7]
            && option9.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == captcha.correctOptions[8])
        {
            this.gameObject.SetActive(false);
        }
    }
}
