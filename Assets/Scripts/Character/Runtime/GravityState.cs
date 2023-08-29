using Spindle.Character;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Character.Runtime {
    class GravityState : StateMachineBehaviour {
        [SerializeField] float gravity = 9.81f;
        Movement movement;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
            animator.TryGetComponent(out movement);
            Assert.IsNotNull(movement);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
        }
        
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
            var currentVelocity = movement.Velocity;
            currentVelocity.y -= gravity * Time.deltaTime;
            movement.Velocity = currentVelocity;
        }
    }
}
