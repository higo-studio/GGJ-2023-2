using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(QTEManager))]
public class QTEInput : MonoBehaviour
{
    private QTEManager manager;
    private void Awake()
    {
        manager = GetComponent<QTEManager>();
    }

    public void OnInputKey(InputAction.CallbackContext context)
    {
        if (!manager.isValid || !context.started)
            return;
        manager.InputQTE((EmQTE)QTEManager.name2EmQte[context.action.name]);
    }
}
