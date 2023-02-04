using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static PlayerInputActions;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions actions;

    private Coroutine m_vibrateCor;

    protected void OnEnable()
    {
        actions.Enable();
    }

    protected void OnDisable()
    {
        actions.Disable();
    }


    unsafe void Awake()
    {
        actions = new PlayerInputActions();
    }

    void OnDestroy()
    {
        StopAllCoroutines();
        Gamepad.current.ResetHaptics();
    }

    public void SetGamePlayCallbacks(IGameplayActions callbacks)
    {
        actions.Gameplay.SetCallbacks(callbacks);
    }

    public void Vibrate(float duration, float low = 0.3f, float high = 0.5f)
    {
        if (Gamepad.current == null) return;
        this.StartCoroutineRef(ref m_vibrateCor, vibrate(duration, low: low, high: high));
    }

    public void StopVibrate()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) return;
        gamepad.ResetHaptics();
    }

    private IEnumerator vibrate(float duration, float low = 0.3f, float high = 0.5f)
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) yield break;

        gamepad.SetMotorSpeeds(low, high);

        var time = Time.time;
        while(Time.time - time < duration)
        {
            yield return null;
        }

        gamepad.ResetHaptics();
    }
}
