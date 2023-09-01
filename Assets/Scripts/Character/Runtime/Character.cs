using MyBox;
using UnityEngine;

namespace Spindle.Character {
    public class Character : MonoBehaviour {
        [SerializeField] CharacterController controller;
        [SerializeField] float mass = 1.0f;
        [SerializeField] float gravity = 9.81f;
        [SerializeField] float jumpForce = 1.0f;

        bool jump;

        [SerializeField, ReadOnly()]
        Vector3 velocity = Vector3.zero;

        [SerializeField, ReadOnly()]
        Vector3 resultingForce = Vector3.zero;

        protected void FixedUpdate() {
            resultingForce = Vector3.zero;
            ApplyGravity();
            Jump();
            velocity +=  resultingForce / mass * Time.deltaTime;
            controller.Move(velocity *Time.deltaTime);
        }

        void ApplyGravity() {
            if(controller.isGrounded) {
                velocity.y -= velocity.y;
                return;
            }

            resultingForce.y -= gravity * mass;
        }

        void Jump() {
            if(!jump) {
                return;
            }
            resultingForce.y += jumpForce;
            jump = false;
        }

        void OnJump() {
            jump = true;
            Debug.Log("Jump");
        }

        protected void OnValidate() {
            if (!controller) {
                TryGetComponent(out controller);
            }
        }
    }
}