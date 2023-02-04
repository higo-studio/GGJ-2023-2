//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/QTE.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @QTEInputAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @QTEInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""QTE"",
    ""maps"": [
        {
            ""name"": ""QTE"",
            ""id"": ""cbb17d97-e99f-4d17-938f-46ebc1db8052"",
            ""actions"": [
                {
                    ""name"": ""W"",
                    ""type"": ""Button"",
                    ""id"": ""a937f147-5154-4d29-8f7e-1432d4542862"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""S"",
                    ""type"": ""Button"",
                    ""id"": ""1d2a2118-a23e-4963-9ffc-1d641640736b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""ce893221-1ffd-4e98-9458-4d50c901b1c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""D"",
                    ""type"": ""Button"",
                    ""id"": ""aeccc2a3-2dbe-4531-946f-c85f6522b56a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ready"",
                    ""type"": ""Button"",
                    ""id"": ""09450882-44b6-4ba4-b63c-5fa47f9fef77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""53a4ecbb-9c4b-4610-8602-e3ca648c9954"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""685441a1-201b-4865-8eb3-d1a964feff3e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c082209e-88ea-4e1c-a4da-a1260ad91db4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73b5965b-f9d5-48f3-830e-56bed40c8bda"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91c669bf-897f-4849-9165-9e6026156b32"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c57d4db3-f290-4b19-ba1c-1346000dbca1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7633ea8-dbf7-44c6-8eee-0666b3c96a5f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // QTE
        m_QTE = asset.FindActionMap("QTE", throwIfNotFound: true);
        m_QTE_W = m_QTE.FindAction("W", throwIfNotFound: true);
        m_QTE_S = m_QTE.FindAction("S", throwIfNotFound: true);
        m_QTE_A = m_QTE.FindAction("A", throwIfNotFound: true);
        m_QTE_D = m_QTE.FindAction("D", throwIfNotFound: true);
        m_QTE_Ready = m_QTE.FindAction("Ready", throwIfNotFound: true);
        m_QTE_Enter = m_QTE.FindAction("Enter", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // QTE
    private readonly InputActionMap m_QTE;
    private IQTEActions m_QTEActionsCallbackInterface;
    private readonly InputAction m_QTE_W;
    private readonly InputAction m_QTE_S;
    private readonly InputAction m_QTE_A;
    private readonly InputAction m_QTE_D;
    private readonly InputAction m_QTE_Ready;
    private readonly InputAction m_QTE_Enter;
    public struct QTEActions
    {
        private @QTEInputAction m_Wrapper;
        public QTEActions(@QTEInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @W => m_Wrapper.m_QTE_W;
        public InputAction @S => m_Wrapper.m_QTE_S;
        public InputAction @A => m_Wrapper.m_QTE_A;
        public InputAction @D => m_Wrapper.m_QTE_D;
        public InputAction @Ready => m_Wrapper.m_QTE_Ready;
        public InputAction @Enter => m_Wrapper.m_QTE_Enter;
        public InputActionMap Get() { return m_Wrapper.m_QTE; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QTEActions set) { return set.Get(); }
        public void SetCallbacks(IQTEActions instance)
        {
            if (m_Wrapper.m_QTEActionsCallbackInterface != null)
            {
                @W.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnW;
                @W.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnW;
                @W.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnW;
                @S.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnS;
                @S.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnS;
                @S.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnS;
                @A.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnA;
                @D.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnD;
                @D.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnD;
                @D.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnD;
                @Ready.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnReady;
                @Ready.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnReady;
                @Ready.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnReady;
                @Enter.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnEnter;
            }
            m_Wrapper.m_QTEActionsCallbackInterface = instance;
            if (instance != null)
            {
                @W.started += instance.OnW;
                @W.performed += instance.OnW;
                @W.canceled += instance.OnW;
                @S.started += instance.OnS;
                @S.performed += instance.OnS;
                @S.canceled += instance.OnS;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @D.started += instance.OnD;
                @D.performed += instance.OnD;
                @D.canceled += instance.OnD;
                @Ready.started += instance.OnReady;
                @Ready.performed += instance.OnReady;
                @Ready.canceled += instance.OnReady;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
            }
        }
    }
    public QTEActions @QTE => new QTEActions(this);
    public interface IQTEActions
    {
        void OnW(InputAction.CallbackContext context);
        void OnS(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnD(InputAction.CallbackContext context);
        void OnReady(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
    }
}