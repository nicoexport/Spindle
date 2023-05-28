using MyBox;
using UnityEngine;

namespace Spindle.Runtime {
    [CreateAssetMenu(fileName = "SO_MovementConfig_New", menuName = "Config/Movement", order = 0)]
    public class MovementConfig : ScriptableObject {
        [field: Header("Velocity")]
        [field: SerializeField] 
        public float MaxVelocity { get; private set; }
        
        [field: Separator]
        [field: Header("Drag")]
        [field: SerializeField] 
        public float Drag { get; private set; }
        [field: SerializeField, Range(1f, 10f)]
        public float DecelerationMultiplier { get; private set; } = 1f;
        
        [field: SerializeField]
        public float Gravity { get; private set; } = 9.81f;
    }
}