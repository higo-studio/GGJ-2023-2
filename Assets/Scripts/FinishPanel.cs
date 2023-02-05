using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPanel : MonoBehaviour
{
    public PlayerInput input { get; set; }
    public Transform success;
    public Transform fail;

    public void init(bool isSucceed)
    {
        (isSucceed ? success : fail).gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        input.OnKeyChanged += onKeyChanged;
    }

    private void OnDisable()
    {
        input.OnKeyChanged -= onKeyChanged;
    }

    private void onKeyChanged(string arg1, UnityEngine.InputSystem.InputAction.CallbackContext arg2)
    {
        if (arg1 == "start")
        {
            SceneManager.LoadScene("Launch");
        }
        else if (arg1 == "right")
        {
            Application.Quit();
        }
    }
}
