//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/InputControls.inputactions
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

public partial class @InputControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""7a4e558c-17f6-4e42-8c33-d3d6f82e79e5"",
            ""actions"": [
                {
                    ""name"": ""LeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""ada27484-178d-4c84-ba73-3f397a276458"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MiddleButton"",
                    ""type"": ""Button"",
                    ""id"": ""dd5eebcb-4d8d-473a-adf9-54c50f381a64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightButton"",
                    ""type"": ""Button"",
                    ""id"": ""a3f4066a-790d-43c4-a94a-1bfd1794db0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""bc6bd122-6f6e-4ec3-bb96-aa677c013d90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""9b3f7db2-09d4-47ad-b79c-15983bf9c258"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eac2218a-87d9-48ea-a076-ea55edff21fe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f10c1ba5-9722-4167-ad66-88bd6c2cd025"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Button"",
                    ""id"": ""fca024cf-d0b0-4b34-aa58-8c157602e281"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DeltaPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7f4eb2d6-a4c9-41c7-b25b-1aa42a8b814f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e7d30526-f3b2-4635-8edb-21154f2e5258"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e696c6f-620c-43b6-a1c3-80ea0c806b3a"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f966551d-9927-494f-acd8-276c3fdcd0a2"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MiddleButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5d75cd0-734f-4c16-a340-748a66605e2e"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4af796e-15c5-41ec-8a86-c05f0733e036"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb76996e-a534-4ef4-a12d-38a94c475024"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fdc8894-d14e-4d6e-b30b-fb09942f1a7b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9b9fd2b-b8e8-4133-92a2-b22f7f7a1032"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bbc5f1a-8b79-440a-85c8-bb647f2786d5"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e155f11-1325-4d72-aa1d-22b5426ece86"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""11ba8436-ec9a-4add-b8d5-eda3f4ca3eee"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f9e70be1-532b-4a29-89b5-9f8678f784c5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b071e1ab-114d-4b1d-890e-499e91cae808"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""92b516a4-ccc7-41b7-bbed-d8e00370daac"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3f1564ec-3c6f-483b-9559-ab6638ed491a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""976c1fb1-ef6e-414e-b61a-4d7bf7a12294"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9cd9564e-db10-4920-936c-a4c9fc649c7b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0b54b300-fb40-4ccc-a7dd-ce4d97c2f027"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7a272a27-ddcb-4324-8374-5b021540ffc1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""6f2e882e-4708-4d42-bf1b-78bf9264f201"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e5b145e4-cc42-4b81-8293-60c924f3138f"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5fcd6cbc-ea64-451f-a3c4-2150baab7b44"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""de8b30af-841f-4def-8276-a0e351423b39"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b757a7b7-e0cc-4bf2-8021-ed2064315367"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""22fada0c-3e11-41e0-ad9e-75659fd497d0"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""402cfc5c-31eb-4166-9e23-f9a37a13b893"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e13b5eaf-a7e4-4789-8396-df11bc7d9475"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""19685361-7f05-46ba-b07d-e3e2e012751a"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b61c4c41-926d-4e56-9500-af3afcf7dca2"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ac3d046-c69e-4eff-b3b8-7af0d56fd21c"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d2d12f8a-5c92-483b-a325-9b4ab58e8d72"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""55ce76c6-b68a-4160-8986-46098967dd04"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""28aa6805-28fd-46e5-9038-7882a2ee6a14"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2a7b9944-d8da-4bb5-8be8-31c4c3462b6e"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""63f58fe2-8238-4b93-b3d0-1f560e22ab60"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeltaPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""177f1ccf-17d6-4e41-b7cf-6d329de1d1f0"",
                    ""path"": ""<Pen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeltaPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7742c0bf-6255-4f29-8e9e-74080c584776"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeltaPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86f04d77-fcb0-4684-abe4-fc5beeb8eac5"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_LeftButton = m_Mouse.FindAction("LeftButton", throwIfNotFound: true);
        m_Mouse_MiddleButton = m_Mouse.FindAction("MiddleButton", throwIfNotFound: true);
        m_Mouse_RightButton = m_Mouse.FindAction("RightButton", throwIfNotFound: true);
        m_Mouse_Submit = m_Mouse.FindAction("Submit", throwIfNotFound: true);
        m_Mouse_Cancel = m_Mouse.FindAction("Cancel", throwIfNotFound: true);
        m_Mouse_ScrollWheel = m_Mouse.FindAction("ScrollWheel", throwIfNotFound: true);
        m_Mouse_Position = m_Mouse.FindAction("Position", throwIfNotFound: true);
        m_Mouse_Navigate = m_Mouse.FindAction("Navigate", throwIfNotFound: true);
        m_Mouse_DeltaPosition = m_Mouse.FindAction("DeltaPosition", throwIfNotFound: true);
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

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_LeftButton;
    private readonly InputAction m_Mouse_MiddleButton;
    private readonly InputAction m_Mouse_RightButton;
    private readonly InputAction m_Mouse_Submit;
    private readonly InputAction m_Mouse_Cancel;
    private readonly InputAction m_Mouse_ScrollWheel;
    private readonly InputAction m_Mouse_Position;
    private readonly InputAction m_Mouse_Navigate;
    private readonly InputAction m_Mouse_DeltaPosition;
    public struct MouseActions
    {
        private @InputControls m_Wrapper;
        public MouseActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftButton => m_Wrapper.m_Mouse_LeftButton;
        public InputAction @MiddleButton => m_Wrapper.m_Mouse_MiddleButton;
        public InputAction @RightButton => m_Wrapper.m_Mouse_RightButton;
        public InputAction @Submit => m_Wrapper.m_Mouse_Submit;
        public InputAction @Cancel => m_Wrapper.m_Mouse_Cancel;
        public InputAction @ScrollWheel => m_Wrapper.m_Mouse_ScrollWheel;
        public InputAction @Position => m_Wrapper.m_Mouse_Position;
        public InputAction @Navigate => m_Wrapper.m_Mouse_Navigate;
        public InputAction @DeltaPosition => m_Wrapper.m_Mouse_DeltaPosition;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @LeftButton.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftButton;
                @LeftButton.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftButton;
                @LeftButton.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftButton;
                @MiddleButton.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMiddleButton;
                @MiddleButton.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMiddleButton;
                @MiddleButton.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMiddleButton;
                @RightButton.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnRightButton;
                @RightButton.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnRightButton;
                @RightButton.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnRightButton;
                @Submit.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnCancel;
                @ScrollWheel.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnScrollWheel;
                @Position.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
                @Navigate.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnNavigate;
                @DeltaPosition.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnDeltaPosition;
                @DeltaPosition.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnDeltaPosition;
                @DeltaPosition.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnDeltaPosition;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftButton.started += instance.OnLeftButton;
                @LeftButton.performed += instance.OnLeftButton;
                @LeftButton.canceled += instance.OnLeftButton;
                @MiddleButton.started += instance.OnMiddleButton;
                @MiddleButton.performed += instance.OnMiddleButton;
                @MiddleButton.canceled += instance.OnMiddleButton;
                @RightButton.started += instance.OnRightButton;
                @RightButton.performed += instance.OnRightButton;
                @RightButton.canceled += instance.OnRightButton;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @DeltaPosition.started += instance.OnDeltaPosition;
                @DeltaPosition.performed += instance.OnDeltaPosition;
                @DeltaPosition.canceled += instance.OnDeltaPosition;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IMouseActions
    {
        void OnLeftButton(InputAction.CallbackContext context);
        void OnMiddleButton(InputAction.CallbackContext context);
        void OnRightButton(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
        void OnDeltaPosition(InputAction.CallbackContext context);
    }
}
