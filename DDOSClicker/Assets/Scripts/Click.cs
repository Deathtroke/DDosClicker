using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    float lastClick;

    public Image siteImage;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastClick = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (siteImage)
        {
            siteImage.sprite = GameManager.Instance.websiteDown
                ? GameManager.Instance.currentLevel.WebsiteDown : GameManager.Instance.currentLevel.WebsiteUp;

        }
    }


    public void click()
    {
        float currentClick = Time.fixedTime;
        float deltatime = lastClick - currentClick;
        GameManager.Instance.clicks.Add(currentClick);
    }
}
