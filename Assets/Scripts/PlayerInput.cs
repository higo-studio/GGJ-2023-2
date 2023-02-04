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

public class PlayerInput : MonoBehaviour, IGameplayActions, IObserver<InputControl>
{
    private PlayerInputActions actions;

    private Coroutine m_vibrateCor;
    public event Action<string, InputAction.CallbackContext> OnKeyChanged;
    public static string s_LastDeviceDisplayName;
    public static string s_LastDeviceSubType;
    public static event Action OnLastInputChanged;

    IDisposable anyKeyDispable;

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
        anyKeyDispable = InputSystem.onAnyButtonPress.Subscribe(this);
    }

    void OnDestroy()
    {
        StopAllCoroutines();
        Gamepad.current.ResetHaptics();
        if (anyKeyDispable != null)
            anyKeyDispable.Dispose();
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
        while (Time.time - time < duration)
        {
            yield return null;
        }

        gamepad.ResetHaptics();
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        OnKeyChanged?.Invoke("start", context);
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        OnKeyChanged?.Invoke("up", context);
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        OnKeyChanged?.Invoke("down", context);
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        OnKeyChanged?.Invoke("left", context);
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        OnKeyChanged?.Invoke("right", context);
    }

    public void OnCompleted()
    {
        Debug.Log("OnComplete");
    }

    public void OnError(Exception error)
    {
        Debug.LogException(error);
    }

    public void OnNext(InputControl value)
    {
        var device = value.device;
        s_LastDeviceDisplayName = device.displayName;
        OnLastInputChanged?.Invoke();
    }
}
