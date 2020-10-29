// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Minigame"",
            ""id"": ""f06e5dc7-547a-4f16-aabc-270f926ac71c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""967d3d5a-a4c3-478f-b5cd-6c2b7cf7fce6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5fcea672-9523-4c57-91f5-69859fdc793d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""21b2df99-46d4-4982-bdf1-a63ad2d56cba"",
            ""actions"": [
                {
                    ""name"": ""ReadyPlayer"",
                    ""type"": ""Button"",
                    ""id"": ""18e777e6-ab5d-4ba1-9509-ba12c4ca1348"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreasePlayerAmount"",
                    ""type"": ""Button"",
                    ""id"": ""01230db3-df9b-4c4d-ac9f-dfc59a2e9a0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreasePlayerAmount"",
                    ""type"": ""Button"",
                    ""id"": ""437b9ec1-4cf4-46f2-a18c-38af165769fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""66e0f3ac-520b-40ed-a128-9650599eeb1e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""ReadyPlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0425700b-44f8-4b86-8eee-dafafd37f33b"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""IncreasePlayerAmount"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5006bc7-883a-4e23-ab1a-41860e0adee0"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""DecreasePlayerAmount"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Minigame
        m_Minigame = asset.FindActionMap("Minigame", throwIfNotFound: true);
        m_Minigame_Movement = m_Minigame.FindAction("Movement", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_ReadyPlayer = m_UI.FindAction("ReadyPlayer", throwIfNotFound: true);
        m_UI_IncreasePlayerAmount = m_UI.FindAction("IncreasePlayerAmount", throwIfNotFound: true);
        m_UI_DecreasePlayerAmount = m_UI.FindAction("DecreasePlayerAmount", throwIfNotFound: true);
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

    // Minigame
    private readonly InputActionMap m_Minigame;
    private IMinigameActions m_MinigameActionsCallbackInterface;
    private readonly InputAction m_Minigame_Movement;
    public struct MinigameActions
    {
        private @PlayerInputActions m_Wrapper;
        public MinigameActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Minigame_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Minigame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MinigameActions set) { return set.Get(); }
        public void SetCallbacks(IMinigameActions instance)
        {
            if (m_Wrapper.m_MinigameActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MinigameActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MinigameActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MinigameActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_MinigameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public MinigameActions @Minigame => new MinigameActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_ReadyPlayer;
    private readonly InputAction m_UI_IncreasePlayerAmount;
    private readonly InputAction m_UI_DecreasePlayerAmount;
    public struct UIActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReadyPlayer => m_Wrapper.m_UI_ReadyPlayer;
        public InputAction @IncreasePlayerAmount => m_Wrapper.m_UI_IncreasePlayerAmount;
        public InputAction @DecreasePlayerAmount => m_Wrapper.m_UI_DecreasePlayerAmount;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @ReadyPlayer.started -= m_Wrapper.m_UIActionsCallbackInterface.OnReadyPlayer;
                @ReadyPlayer.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnReadyPlayer;
                @ReadyPlayer.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnReadyPlayer;
                @IncreasePlayerAmount.started -= m_Wrapper.m_UIActionsCallbackInterface.OnIncreasePlayerAmount;
                @IncreasePlayerAmount.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnIncreasePlayerAmount;
                @IncreasePlayerAmount.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnIncreasePlayerAmount;
                @DecreasePlayerAmount.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDecreasePlayerAmount;
                @DecreasePlayerAmount.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDecreasePlayerAmount;
                @DecreasePlayerAmount.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDecreasePlayerAmount;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ReadyPlayer.started += instance.OnReadyPlayer;
                @ReadyPlayer.performed += instance.OnReadyPlayer;
                @ReadyPlayer.canceled += instance.OnReadyPlayer;
                @IncreasePlayerAmount.started += instance.OnIncreasePlayerAmount;
                @IncreasePlayerAmount.performed += instance.OnIncreasePlayerAmount;
                @IncreasePlayerAmount.canceled += instance.OnIncreasePlayerAmount;
                @DecreasePlayerAmount.started += instance.OnDecreasePlayerAmount;
                @DecreasePlayerAmount.performed += instance.OnDecreasePlayerAmount;
                @DecreasePlayerAmount.canceled += instance.OnDecreasePlayerAmount;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IMinigameActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnReadyPlayer(InputAction.CallbackContext context);
        void OnIncreasePlayerAmount(InputAction.CallbackContext context);
        void OnDecreasePlayerAmount(InputAction.CallbackContext context);
    }
}
