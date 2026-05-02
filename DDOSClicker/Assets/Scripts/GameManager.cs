using System.Collections.Generic;
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

    public Dictionary<devices, int> boughtDevices = new Dictionary<devices, int>();

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
        if (boughtDevices.ContainsKey(device))
        {
            boughtDevices[device] += amount;
        }
        else
        {
            boughtDevices.Add(device, amount);
        }
    }
}
