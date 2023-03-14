using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject SelectWindow;

    private void Start()
    {
        CloseSelectWindow();
    }

    public void OpenSelectWindow()
    {
        SelectWindow.SetActive(true);
    }

    public void CloseSelectWindow()
    {
        SelectWindow?.SetActive(false);
    }

    public void OnSelectWindowSwitch(InputAction.CallbackContext callback)
    {
        if (SelectWindow.activeSelf)
            CloseSelectWindow();
        else
            OpenSelectWindow(); 
    }
}
