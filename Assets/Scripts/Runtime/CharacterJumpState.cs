using UnityEngine;
using UnityEngine.Assertions;

namespace Spindle.Runtime {
    public class CharacterJumpState : StateMachineBehaviour {
        [SerializeField] float jumpForce;
        CharacterMovement attachedMovement;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
            GetAttachedMovement(animator);
            Jump();
        }
        
        void GetAttachedMovement(Animator animator)
        {
            animator.TryGetComponent(out CharacterMovement movement);
            Assert.IsTrue(
                movement,
                $"Animator {animator} does not have a {typeof(CharacterMovement)} component!");
            attachedMovement = movement;
        }
        
        void Jump()
        {
            var newVelocity = attachedMovement.Velocity;
            newVelocity.y = jumpForce;
            attachedMovement.Velocity = newVelocity;
        }
    }
}