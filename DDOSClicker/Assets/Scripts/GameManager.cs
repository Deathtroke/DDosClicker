using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum devices { PC, Fridge, Server }
    public static GameManager Instance { get; private set; }

    private void Awake()
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
    }

    public List<float> clicks = new List<float>();
    [SerializeField] private float lastCalc = 0f;

    public float manualRpS = 0f;

    public Dictionary<devices, int[]> boughtDevices = new Dictionary<devices, int[]>();

    public float totalRpS => manualRpS + boughtDevices.Keys.Sum(x => EconomyManager.Instance.getRequestRate(x));

    private void FixedUpdate()
    {
        if (lastCalc + 0.2f < Time.time)
        {
            manualRpS = clicks.FindAll(x => x > lastCalc - 1).Count;
            clicks = clicks.FindAll(x => x > lastCalc - 1);
            lastCalc = Time.time;
        }

    }

    public void BuyDevice(devices device, int amount = 1)
    {
        
        if (EconomyManager.Instance.fame < EconomyManager.Instance.nextPuyPrice(device, amount)) return;
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
    }

    public void BuyUpgrades(devices device, int amount = 1)
    {
        if (EconomyManager.Instance.fame < EconomyManager.Instance.nextUpgradePrice(device))
        {
            return;
        }
        if (boughtDevices.ContainsKey(device))
        {
            boughtDevices[device][1] += amount;
        }
        else
        {
            boughtDevices.Add(device, new int[] {0, amount});
        }
    }

    public string bigNumber(int number)
    {
        string str = number.ToString();
        int length = str.Length;
        if (length < 5) return str;
        return str[0] + "," + str[1..3] + "E" + --length;
    }
}
