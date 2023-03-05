using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 80;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
