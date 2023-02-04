using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(QTEManager))]
public class QTEInput : MonoBehaviour
{
    public PlayerInput playerInput;
    private QTEManager manager;
    private void Awake()
    {
        manager = GetComponent<QTEManager>();
        playerInput.OnKeyChanged += OnKeyChanged;
    }

    void OnDestroy()
    {
        playerInput.OnKeyChanged -= OnKeyChanged;
    }


    private void OnKeyChanged(string arg1, InputAction.CallbackContext context)
    {
        if (!manager.isValid)
            return;

        if (arg1 == "start" && context.phase == InputActionPhase.Canceled)
        {
            manager.InputQTE(EmQTE.Enter);
        }
        else if (context.phase == InputActionPhase.Started)
        {
            manager.InputQTE((EmQTE)QTEManager.name2EmQte[arg1]);
        }
    }

    //public void OnInputKey(InputAction.CallbackContext context)
    //{
    //    if (!manager.isValid || !context.started)
    //        return;
    //    manager.InputQTE((EmQTE)QTEManager.name2EmQte[context.action.name]);
    //}
}
