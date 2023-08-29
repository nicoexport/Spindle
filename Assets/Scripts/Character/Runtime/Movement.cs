using UnityEngine;
using UnityEngine.InputSystem;

namespace Spindle.Character {
    public class Movement : MonoBehaviour {
        [SerializeField] CharacterController controller;
        [SerializeField] Animator animator;

        public Vector3 MoveIntend {
            get; set;
        }

        public Vector3 Velocity {
            get; set;
        }   

        public Vector3 resultingForce { get; set; }

        public bool IsGrounded {
            get; set;
        }

        protected void FixedUpdate() {
            IsGrounded = controller.isGrounded;
            controller.Move(Velocity * Time.deltaTime);
        }

        protected void OnValidate() {
            if (!controller) {
                TryGetComponent(out controller);
            }

            if (!animator) {
                TryGetComponent(out animator);
            }
        }

        public void OnMove(InputValue value) {
            MoveIntend = new Vector3(value.Get<float>(), 0f, 0f);
        }
    }
}