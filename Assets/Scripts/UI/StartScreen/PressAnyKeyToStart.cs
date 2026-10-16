using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressAnyKeyToStart : MonoBehaviour
{

    [SerializeField] GameObject MainScreenPanal;
    [SerializeField] GameObject StartScreenPanal;

    private bool Started;



    private void Update()
    {
        if (Started || !Keyboard.current.anyKey.wasPressedThisFrame && !Mouse.current.leftButton.wasPressedThisFrame)
        {
             return;   
        }
        Started = true;

        MainScreenPanal.SetActive(true);
        StartScreenPanal.SetActive(false);
    }
}
