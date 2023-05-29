using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Spindle.Runtime {
    public class CharacterJump : MonoBehaviour {
        [SerializeField] Animator animator;
        readonly BoolBuffer inputBuffer = new();

        public bool JumpIntend {
            get => animator.GetBool(nameof(JumpIntend));
            set => animator.SetBool(nameof(JumpIntend), value);
        }
        
        public void OnJump(InputValue value) {
            inputBuffer.SetForFrames(5);
        }

        public void Update() {
            JumpIntend = inputBuffer.Value;
        }

        public void FixedUpdate() {
            inputBuffer.Tick();
        }
    }
}