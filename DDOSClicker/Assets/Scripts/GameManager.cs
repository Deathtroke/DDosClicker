using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEditor.Search;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum devices { PC, Fridge, Server }
    public static GameManager Instance { get; private set; }

    public List<Websites> levels = new List<Websites>();

    public int currentLevelID  = 0;
    public void NextLevel()
    {
        currentLevelID++;

        Chat.instance.DeleteChatHistory();
        Chat.instance.NewChat(currentLevel.loadNames, currentLevel.loadChats);
        currentLevel.lastCaptcha = 0;
    }

    public int maxLevel = 0;

    public Websites currentLevel => levels[currentLevelID];

    public Dictionary<Websites, float> downWebsites = new Dictionary<Websites, float>();

    public CaptchaInstance captcha;

    public bool captchaUp => captcha ? captcha.gameObject.activeInHierarchy: false;

    private void Start()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        lastCalc = Time.time;

        Chat.instance.NewChat(currentLevel.loadNames, currentLevel.loadChats);
    }

    public List<float> clicks = new List<float>();
    [SerializeField] private float lastCalc = 0f;

    public float manualRpS = 0f;

    public Dictionary<devices, int[]> boughtDevices = new Dictionary<devices, int[]>();

    public bool websiteDown => (downWebsites.ContainsKey(currentLevel));// && downWebsites[currentLevel] >= Time.time);
    public float totalRpS => captchaUp || websiteDown ? 0: manualRpS + boughtDevices.Keys.Sum(x => EconomyManager.Instance.getRequestRate(x));

    private void FixedUpdate()
    {
        if (lastCalc + 0.2f < Time.time)
        {
            manualRpS = clicks.FindAll(x => x > lastCalc - 1).Count;
            clicks = clicks.FindAll(x => x > lastCalc - 1);
            lastCalc = Time.time;


            if ((totalRpS < currentLevel.capacity))
            {
                EconomyManager.Instance.fame += (totalRpS / currentLevel.capacity) * currentLevel.passiveIncome * 0.2f;
            }
            else
            {
                EconomyManager.Instance.fame += currentLevel.onDDoS;
                if (currentLevelID == maxLevel) { 
                    maxLevel++;
                    Chat.instance.DeleteChatHistory();
                    Chat.instance.NewChat(currentLevel.completeNames, currentLevel.completeChats);
                    Invoke(nameof(LinkForNewLevel), 6.5f);
                }
                if (downWebsites.ContainsKey(currentLevel)) {
                    downWebsites[currentLevel] = Time.time + 2;
                } else downWebsites.Add(currentLevel, Time.time + 2);

            }
            

            if (captcha != null && currentLevel.captchaRate != 0)
            {
                if (currentLevel.lastCaptcha + currentLevel.captchaRate < Time.time)
                {
                    currentLevel.lastCaptcha = Time.time;
                    if (!captcha.gameObject.activeInHierarchy && !websiteDown)
                    {
                        captcha.InitializeNew();
                    }
                }
            }            
        }
    }

    public void LinkForNewLevel()
    {
        Chat.instance.NewChatLink(currentLevel.nameLinkToNextLevel, currentLevel.linkToNextLevel);
    }

    public int BuyDevice(devices device, int amount = 1)
    {
        if (EconomyManager.Instance.fame < EconomyManager.Instance.nextPuyPrice(device, amount)) return -1;
        EconomyManager.Instance.fame -= EconomyManager.Instance.nextPuyPrice(device, amount);
        if (boughtDevices.ContainsKey(device))
        {
            boughtDevices[device][0] += amount;
        }
        else
        {
            boughtDevices.Add(device, new int[]{ amount,0});
        }
        Debug.Log(boughtDevices[device][0]);

        return EconomyManager.Instance.nextPuyPrice(device);
    }

    public int BuyUpgrades(devices device, int amount = 1)
    {
        if (EconomyManager.Instance.fame < EconomyManager.Instance.nextUpgradePrice(device, amount)) return -1;
        EconomyManager.Instance.fame -= EconomyManager.Instance.nextUpgradePrice(device, amount);
        if (boughtDevices.ContainsKey(device))
        {
            boughtDevices[device][1] += amount;
        }
        else
        {
            boughtDevices.Add(device, new int[] {0, amount});
        }

        return EconomyManager.Instance.nextUpgradePrice(device);
    }

    public string bigNumber(int number)
    {
        string str = number.ToString();
        int length = str.Length;
        if (length < 5) return str;
        return str[0] + "," + str[1..3] + "E" + --length;
    }
}
