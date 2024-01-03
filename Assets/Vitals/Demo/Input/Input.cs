//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/Vitals System/Demo/Input/Input.inputactions
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

namespace Vitals
{
    public partial class @Input : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }

        public @Input()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""ActionMap"",
            ""id"": ""c071e0db-e626-4b08-a0b0-c3731af6db9a"",
            ""actions"": [
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""a7e71857-4349-4628-92ff-8651b0905548"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2072b648-b56e-4827-9e66-7a264f8375dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8f56fdc-d96c-48b3-a32a-487625fc6d56"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91bf4a0d-cbc6-4e76-bf19-ce879ea5a734"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""EnemyDemo"",
            ""id"": ""f0cdabf5-fa7f-46b8-bb16-57d36cf633ac"",
            ""actions"": [
                {
                    ""name"": ""Spawn"",
                    ""type"": ""Button"",
                    ""id"": ""b41c9859-08db-4241-ad72-6bf3f3c6e109"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Damage"",
                    ""type"": ""Button"",
                    ""id"": ""95b86cd1-945d-4a52-a6c8-7fe33b2cde86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0da5791-cffe-4603-a25e-43488ae4cb1e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe28baeb-50ee-4e50-84fc-b3ba87e0d8fe"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Damage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // ActionMap
            m_ActionMap = asset.FindActionMap("ActionMap", throwIfNotFound: true);
            m_ActionMap_Sprint = m_ActionMap.FindAction("Sprint", throwIfNotFound: true);
            m_ActionMap_Attack = m_ActionMap.FindAction("Attack", throwIfNotFound: true);
            // EnemyDemo
            m_EnemyDemo = asset.FindActionMap("EnemyDemo", throwIfNotFound: true);
            m_EnemyDemo_Spawn = m_EnemyDemo.FindAction("Spawn", throwIfNotFound: true);
            m_EnemyDemo_Damage = m_EnemyDemo.FindAction("Damage", throwIfNotFound: true);
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

        // ActionMap
        private readonly InputActionMap m_ActionMap;
        private List<IActionMapActions> m_ActionMapActionsCallbackInterfaces = new List<IActionMapActions>();
        private readonly InputAction m_ActionMap_Sprint;
        private readonly InputAction m_ActionMap_Attack;

        public struct ActionMapActions
        {
            private @Input m_Wrapper;

            public ActionMapActions(@Input wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction @Sprint => m_Wrapper.m_ActionMap_Sprint;
            public InputAction @Attack => m_Wrapper.m_ActionMap_Attack;

            public InputActionMap Get()
            {
                return m_Wrapper.m_ActionMap;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(ActionMapActions set)
            {
                return set.Get();
            }

            public void AddCallbacks(IActionMapActions instance)
            {
                if (instance == null || m_Wrapper.m_ActionMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_ActionMapActionsCallbackInterfaces.Add(instance);
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }

            private void UnregisterCallbacks(IActionMapActions instance)
            {
                @Sprint.started -= instance.OnSprint;
                @Sprint.performed -= instance.OnSprint;
                @Sprint.canceled -= instance.OnSprint;
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
            }

            public void RemoveCallbacks(IActionMapActions instance)
            {
                if (m_Wrapper.m_ActionMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IActionMapActions instance)
            {
                foreach (var item in m_Wrapper.m_ActionMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_ActionMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }

        public ActionMapActions @ActionMap => new ActionMapActions(this);

        // EnemyDemo
        private readonly InputActionMap m_EnemyDemo;
        private List<IEnemyDemoActions> m_EnemyDemoActionsCallbackInterfaces = new List<IEnemyDemoActions>();
        private readonly InputAction m_EnemyDemo_Spawn;
        private readonly InputAction m_EnemyDemo_Damage;

        public struct EnemyDemoActions
        {
            private @Input m_Wrapper;

            public EnemyDemoActions(@Input wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction @Spawn => m_Wrapper.m_EnemyDemo_Spawn;
            public InputAction @Damage => m_Wrapper.m_EnemyDemo_Damage;

            public InputActionMap Get()
            {
                return m_Wrapper.m_EnemyDemo;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(EnemyDemoActions set)
            {
                return set.Get();
            }

            public void AddCallbacks(IEnemyDemoActions instance)
            {
                if (instance == null || m_Wrapper.m_EnemyDemoActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_EnemyDemoActionsCallbackInterfaces.Add(instance);
                @Spawn.started += instance.OnSpawn;
                @Spawn.performed += instance.OnSpawn;
                @Spawn.canceled += instance.OnSpawn;
                @Damage.started += instance.OnDamage;
                @Damage.performed += instance.OnDamage;
                @Damage.canceled += instance.OnDamage;
            }

            private void UnregisterCallbacks(IEnemyDemoActions instance)
            {
                @Spawn.started -= instance.OnSpawn;
                @Spawn.performed -= instance.OnSpawn;
                @Spawn.canceled -= instance.OnSpawn;
                @Damage.started -= instance.OnDamage;
                @Damage.performed -= instance.OnDamage;
                @Damage.canceled -= instance.OnDamage;
            }

            public void RemoveCallbacks(IEnemyDemoActions instance)
            {
                if (m_Wrapper.m_EnemyDemoActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IEnemyDemoActions instance)
            {
                foreach (var item in m_Wrapper.m_EnemyDemoActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_EnemyDemoActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }

        public EnemyDemoActions @EnemyDemo => new EnemyDemoActions(this);

        public interface IActionMapActions
        {
            void OnSprint(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
        }

        public interface IEnemyDemoActions
        {
            void OnSpawn(InputAction.CallbackContext context);
            void OnDamage(InputAction.CallbackContext context);
        }
    }
}