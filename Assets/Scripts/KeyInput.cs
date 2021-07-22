// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/KeyInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @KeyInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyInput"",
    ""maps"": [
        {
            ""name"": ""CharicterControls"",
            ""id"": ""91e6bb24-866c-4829-a099-0c4e48eae7dd"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e269a3e8-b663-4268-a5de-5df1ca7e37ed"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""5fc9f10c-3208-4977-b260-cb0d755b02b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""16c84e99-91c8-44c0-9adc-0af563d1824a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""81b1cb31-f198-4823-9f2d-ac62ab22b8b3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ec0c2dee-fc01-497d-a340-fc7aceeb63dc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5b0b718a-bcb0-449d-9713-4e77aa3696e6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c6d31f31-1004-4d5d-bbfd-f0ce34e7fe3a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""dae9993c-f51a-4f2c-9027-8561784fd695"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""363078a5-7cb9-4a1a-8f50-1dcda1e0f9b8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f5107f0b-2564-49f0-a060-b8777bc08e5d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""084e1053-3927-4f3f-b7f7-e37ed6e9e621"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d4846d13-72fd-441b-80f1-6eb20ef94ebf"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aa4770ee-9a38-4505-90ec-b79b4f366926"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharicterControls
        m_CharicterControls = asset.FindActionMap("CharicterControls", throwIfNotFound: true);
        m_CharicterControls_Move = m_CharicterControls.FindAction("Move", throwIfNotFound: true);
        m_CharicterControls_Run = m_CharicterControls.FindAction("Run", throwIfNotFound: true);
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

    // CharicterControls
    private readonly InputActionMap m_CharicterControls;
    private ICharicterControlsActions m_CharicterControlsActionsCallbackInterface;
    private readonly InputAction m_CharicterControls_Move;
    private readonly InputAction m_CharicterControls_Run;
    public struct CharicterControlsActions
    {
        private @KeyInput m_Wrapper;
        public CharicterControlsActions(@KeyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharicterControls_Move;
        public InputAction @Run => m_Wrapper.m_CharicterControls_Run;
        public InputActionMap Get() { return m_Wrapper.m_CharicterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharicterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharicterControlsActions instance)
        {
            if (m_Wrapper.m_CharicterControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharicterControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharicterControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharicterControlsActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_CharicterControlsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharicterControlsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharicterControlsActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_CharicterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public CharicterControlsActions @CharicterControls => new CharicterControlsActions(this);
    public interface ICharicterControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}
