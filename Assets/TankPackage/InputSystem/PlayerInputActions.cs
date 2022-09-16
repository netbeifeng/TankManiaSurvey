//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/TankPackage/InputSystem/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b032a121-65ff-431a-869b-51dc8a4be8e4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""83b01d07-2aca-48a6-b793-aa9517d49e22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""1785a81f-8b28-4b9d-b82d-107e024f97e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attacking"",
                    ""type"": ""Button"",
                    ""id"": ""e60f161a-794d-41e4-91e6-bd59981ea877"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ControllerAiming"",
                    ""type"": ""Value"",
                    ""id"": ""3fa712e7-96e8-4d30-bd5a-72d71eaee287"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mobile Drag"",
                    ""type"": ""Value"",
                    ""id"": ""66b6f979-fb19-4059-bb2d-e63950eca875"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Mobile Hold Single"",
                    ""type"": ""Button"",
                    ""id"": ""64f2c0fe-e9ef-4361-a278-8718993220c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mobile Hold Multi"",
                    ""type"": ""Button"",
                    ""id"": ""57a685b1-498c-4257-802c-766c6e5246bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""118aa939-a669-4317-b87b-fe193faf9571"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Touch0Delta"",
                    ""type"": ""Value"",
                    ""id"": ""f7e44396-3c3f-478f-a2a1-59b43d7fe53d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch1Delta"",
                    ""type"": ""Value"",
                    ""id"": ""f38f3be7-fffd-4b7f-ada9-8ba95e20a705"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch0Pos"",
                    ""type"": ""Value"",
                    ""id"": ""58d2a247-7e43-400f-bb22-c5f0e0852e88"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch1Pos"",
                    ""type"": ""Value"",
                    ""id"": ""a1b09677-3ae7-41ff-b01e-d1bf7c8cf6ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch1Press"",
                    ""type"": ""Button"",
                    ""id"": ""af926357-a134-4e72-9572-1067893d7b7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Touch0Press"",
                    ""type"": ""Button"",
                    ""id"": ""b20b0774-1376-495d-a123-7ad4ff5c2fb5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6bf2fa1e-df1e-4641-9a28-b3b2caa450c0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a19952ea-5938-4996-838e-2a7c077b6ec9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1751d34a-1d00-463d-b01f-e0955bfff242"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""aad6a885-d975-4cb5-bd3b-57754d551f94"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""14b82558-6d6f-4613-9c6b-65e1fbdb0dc1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""82eccf3b-9b5f-4993-b7bd-57190b39f23c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""General Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78c00299-56dc-4c15-ac15-f254199a77e1"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""341c2334-1407-47a7-bc54-cbf27c37db3c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attacking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46fde8c0-2c10-44ea-bc70-39066a1e7a2f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attacking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d49b822-2e69-4fe1-9701-3891f5091f26"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attacking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a19875a6-200c-443d-86df-2194657c60b5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerAiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1447b247-e10c-432c-9b0f-1edbf89b4a57"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mobile Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14bb253d-ea1a-49f0-93a9-c8821f960a2b"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mobile Hold Single"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""947fa677-6355-4b12-9533-adec3992035e"",
                    ""path"": ""<Touchscreen>/touch*/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mobile Hold Multi"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9e7616e-4dfc-4382-93b1-9f2004ac7918"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da0548b5-759b-4ce6-9c64-af866137a3c1"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7420c22f-4c92-42de-b985-6ab7df55d8cd"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch0Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d33fe49b-204a-4612-b486-5bdd96e625ce"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch0Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be9b7a9e-88f3-4dfb-a0a6-f95d2c5985ad"",
                    ""path"": ""<Touchscreen>/touch1/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch1Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3eeb9bee-719f-4e9d-8060-f57617b3570e"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch1Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e505bdb7-0fc0-4826-b8cc-f9457a329e5f"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch1Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7eeb5e95-c52e-41bc-9cbe-d0ef13aeed14"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch0Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""General Gamepad"",
            ""bindingGroup"": ""General Gamepad"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Aiming = m_Player.FindAction("Aiming", throwIfNotFound: true);
        m_Player_Attacking = m_Player.FindAction("Attacking", throwIfNotFound: true);
        m_Player_ControllerAiming = m_Player.FindAction("ControllerAiming", throwIfNotFound: true);
        m_Player_MobileDrag = m_Player.FindAction("Mobile Drag", throwIfNotFound: true);
        m_Player_MobileHoldSingle = m_Player.FindAction("Mobile Hold Single", throwIfNotFound: true);
        m_Player_MobileHoldMulti = m_Player.FindAction("Mobile Hold Multi", throwIfNotFound: true);
        m_Player_Menu = m_Player.FindAction("Menu", throwIfNotFound: true);
        m_Player_Touch0Delta = m_Player.FindAction("Touch0Delta", throwIfNotFound: true);
        m_Player_Touch1Delta = m_Player.FindAction("Touch1Delta", throwIfNotFound: true);
        m_Player_Touch0Pos = m_Player.FindAction("Touch0Pos", throwIfNotFound: true);
        m_Player_Touch1Pos = m_Player.FindAction("Touch1Pos", throwIfNotFound: true);
        m_Player_Touch1Press = m_Player.FindAction("Touch1Press", throwIfNotFound: true);
        m_Player_Touch0Press = m_Player.FindAction("Touch0Press", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Aiming;
    private readonly InputAction m_Player_Attacking;
    private readonly InputAction m_Player_ControllerAiming;
    private readonly InputAction m_Player_MobileDrag;
    private readonly InputAction m_Player_MobileHoldSingle;
    private readonly InputAction m_Player_MobileHoldMulti;
    private readonly InputAction m_Player_Menu;
    private readonly InputAction m_Player_Touch0Delta;
    private readonly InputAction m_Player_Touch1Delta;
    private readonly InputAction m_Player_Touch0Pos;
    private readonly InputAction m_Player_Touch1Pos;
    private readonly InputAction m_Player_Touch1Press;
    private readonly InputAction m_Player_Touch0Press;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Aiming => m_Wrapper.m_Player_Aiming;
        public InputAction @Attacking => m_Wrapper.m_Player_Attacking;
        public InputAction @ControllerAiming => m_Wrapper.m_Player_ControllerAiming;
        public InputAction @MobileDrag => m_Wrapper.m_Player_MobileDrag;
        public InputAction @MobileHoldSingle => m_Wrapper.m_Player_MobileHoldSingle;
        public InputAction @MobileHoldMulti => m_Wrapper.m_Player_MobileHoldMulti;
        public InputAction @Menu => m_Wrapper.m_Player_Menu;
        public InputAction @Touch0Delta => m_Wrapper.m_Player_Touch0Delta;
        public InputAction @Touch1Delta => m_Wrapper.m_Player_Touch1Delta;
        public InputAction @Touch0Pos => m_Wrapper.m_Player_Touch0Pos;
        public InputAction @Touch1Pos => m_Wrapper.m_Player_Touch1Pos;
        public InputAction @Touch1Press => m_Wrapper.m_Player_Touch1Press;
        public InputAction @Touch0Press => m_Wrapper.m_Player_Touch0Press;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Aiming.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @Attacking.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttacking;
                @Attacking.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttacking;
                @Attacking.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttacking;
                @ControllerAiming.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerAiming;
                @ControllerAiming.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerAiming;
                @ControllerAiming.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerAiming;
                @MobileDrag.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileDrag;
                @MobileDrag.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileDrag;
                @MobileDrag.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileDrag;
                @MobileHoldSingle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileHoldSingle;
                @MobileHoldSingle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileHoldSingle;
                @MobileHoldSingle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileHoldSingle;
                @MobileHoldMulti.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileHoldMulti;
                @MobileHoldMulti.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileHoldMulti;
                @MobileHoldMulti.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMobileHoldMulti;
                @Menu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenu;
                @Touch0Delta.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Delta;
                @Touch0Delta.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Delta;
                @Touch0Delta.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Delta;
                @Touch1Delta.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Delta;
                @Touch1Delta.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Delta;
                @Touch1Delta.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Delta;
                @Touch0Pos.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Pos;
                @Touch0Pos.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Pos;
                @Touch0Pos.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Pos;
                @Touch1Pos.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Pos;
                @Touch1Pos.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Pos;
                @Touch1Pos.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Pos;
                @Touch1Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Press;
                @Touch1Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Press;
                @Touch1Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch1Press;
                @Touch0Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Press;
                @Touch0Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Press;
                @Touch0Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch0Press;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @Attacking.started += instance.OnAttacking;
                @Attacking.performed += instance.OnAttacking;
                @Attacking.canceled += instance.OnAttacking;
                @ControllerAiming.started += instance.OnControllerAiming;
                @ControllerAiming.performed += instance.OnControllerAiming;
                @ControllerAiming.canceled += instance.OnControllerAiming;
                @MobileDrag.started += instance.OnMobileDrag;
                @MobileDrag.performed += instance.OnMobileDrag;
                @MobileDrag.canceled += instance.OnMobileDrag;
                @MobileHoldSingle.started += instance.OnMobileHoldSingle;
                @MobileHoldSingle.performed += instance.OnMobileHoldSingle;
                @MobileHoldSingle.canceled += instance.OnMobileHoldSingle;
                @MobileHoldMulti.started += instance.OnMobileHoldMulti;
                @MobileHoldMulti.performed += instance.OnMobileHoldMulti;
                @MobileHoldMulti.canceled += instance.OnMobileHoldMulti;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Touch0Delta.started += instance.OnTouch0Delta;
                @Touch0Delta.performed += instance.OnTouch0Delta;
                @Touch0Delta.canceled += instance.OnTouch0Delta;
                @Touch1Delta.started += instance.OnTouch1Delta;
                @Touch1Delta.performed += instance.OnTouch1Delta;
                @Touch1Delta.canceled += instance.OnTouch1Delta;
                @Touch0Pos.started += instance.OnTouch0Pos;
                @Touch0Pos.performed += instance.OnTouch0Pos;
                @Touch0Pos.canceled += instance.OnTouch0Pos;
                @Touch1Pos.started += instance.OnTouch1Pos;
                @Touch1Pos.performed += instance.OnTouch1Pos;
                @Touch1Pos.canceled += instance.OnTouch1Pos;
                @Touch1Press.started += instance.OnTouch1Press;
                @Touch1Press.performed += instance.OnTouch1Press;
                @Touch1Press.canceled += instance.OnTouch1Press;
                @Touch0Press.started += instance.OnTouch0Press;
                @Touch0Press.performed += instance.OnTouch0Press;
                @Touch0Press.canceled += instance.OnTouch0Press;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GeneralGamepadSchemeIndex = -1;
    public InputControlScheme GeneralGamepadScheme
    {
        get
        {
            if (m_GeneralGamepadSchemeIndex == -1) m_GeneralGamepadSchemeIndex = asset.FindControlSchemeIndex("General Gamepad");
            return asset.controlSchemes[m_GeneralGamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnAttacking(InputAction.CallbackContext context);
        void OnControllerAiming(InputAction.CallbackContext context);
        void OnMobileDrag(InputAction.CallbackContext context);
        void OnMobileHoldSingle(InputAction.CallbackContext context);
        void OnMobileHoldMulti(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnTouch0Delta(InputAction.CallbackContext context);
        void OnTouch1Delta(InputAction.CallbackContext context);
        void OnTouch0Pos(InputAction.CallbackContext context);
        void OnTouch1Pos(InputAction.CallbackContext context);
        void OnTouch1Press(InputAction.CallbackContext context);
        void OnTouch0Press(InputAction.CallbackContext context);
    }
}
