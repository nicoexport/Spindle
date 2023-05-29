using UnityEngine;
using UnityEngine.Assertions;

namespace Spindle.Runtime {
    public class CharacterMovementState : StateMachineBehaviour {
        [SerializeField] bool applyMovement;
        [SerializeField] bool applyGravity;
        CharacterMovement attachedMovement;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
            GetAttachedMovement(animator);
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
            Move();
            Gravity();
        }
        
        void GetAttachedMovement(Animator animator)
        {
            animator.TryGetComponent(out CharacterMovement movement);
            Assert.IsTrue(
                movement,
                $"Animator {animator} does not have a {typeof(CharacterMovement)} component!");
            attachedMovement = movement;
        }
        
        void Move() {
            if (!applyMovement) {
                return;
            }
            
            float drag = attachedMovement.Config.Drag;

            if (attachedMovement.MoveIntend.magnitude == 0f) {
                drag *= 1f / attachedMovement.Config.DecelerationMultiplier;
            }
            
            Vector3 newVelocity = new();
            attachedMovement.Velocity = Vector3.SmoothDamp(
                attachedMovement.Velocity,
                attachedMovement.MoveIntend * attachedMovement.Config.MaxVelocity,
                ref newVelocity,
                drag);
        }

        void Gravity() {
            if (!applyGravity || attachedMovement.IsGrounded) {
                return;
            }

            var newVelocity = attachedMovement.Velocity;
            newVelocity.y -= attachedMovement.Config.Gravity;
            attachedMovement.Velocity = newVelocity;
        }
    }
}
