using UnityEngine;

public class Click : MonoBehaviour
{
    float lastClick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastClick = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void click()
    {
        float currentClick = Time.fixedTime;
        float deltatime = lastClick - currentClick;
        GameManager.Instance.clicks.Add(currentClick);
    }
}
