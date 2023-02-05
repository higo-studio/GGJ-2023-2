using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Launch : MonoBehaviour
{
    public PlayerInput input;
    public string nextScene;
    private void Awake()
    {
        input.OnKeyChanged += OnKeyChanged;
    }

    private void OnDestroy()
    {
        input.OnKeyChanged -= OnKeyChanged;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnKeyChanged(string arg1, InputAction.CallbackContext arg2)
    {
        if (arg1 == "down")
        {
            SceneManager.LoadScene(nextScene);
        }
        else if (arg1 == "right")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.Exit(0);
#else
            Application.Quit();
#endif
        }
    }

}
