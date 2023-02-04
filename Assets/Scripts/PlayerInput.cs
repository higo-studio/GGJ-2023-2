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

public class PlayerInput : MonoBehaviour, IGameplayActions
{
    private PlayerInputActions actions;

    private Coroutine m_vibrateCor;
    public event Action<InputAction.CallbackContext> OnKeyChanged;
    public static string s_LastDeviceDisplayName;
    public static string s_LastDeviceSubType;
    public static event Action OnLastInputChanged;

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
        actions.Gameplay.SetCallbacks(this);
    }

    void OnDestroy()
    {
        StopAllCoroutines();
        Gamepad.current.ResetHaptics();
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

    public void OnStart(InputAction.CallbackContext context)
    {
        OnCommand(context);
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        OnCommand(context);
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        OnCommand(context);
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        OnCommand(context);
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        OnCommand(context);
    }

    public void OnCommand(InputAction.CallbackContext context)
    {
        OnKeyChanged?.Invoke(context);

        var device = context.control.device;
        s_LastDeviceDisplayName = device.displayName;
        OnLastInputChanged?.Invoke();
    }
}
