using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class onClickSund : MonoBehaviour
{

    public AudioSource m_AudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            m_AudioSource.pitch = Random.Range(0.8f, 1.2f);
            m_AudioSource.Play();
        }
    }
}
