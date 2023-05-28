﻿using System;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Spindle.Runtime {
    public class CharacterMovement : MonoBehaviour {
        [SerializeField] CharacterController controller;
        [SerializeField] Animator animator;
        [field: SerializeField, Expandable] public MovementConfig Config { get; private set; }
        
        public Vector3 MoveIntend {
            get => new Vector3(MoveIntendX, MoveIntendY, 0f);
            set {
                MoveIntendX = value.x;
                MoveIntendY = value.y;
            }
        }
        
        float MoveIntendX {
            get => animator.GetFloat(nameof(MoveIntendX));
            set => animator.SetFloat(nameof(MoveIntendX), value);
        }
        
        float MoveIntendY {
            get => animator.GetFloat(nameof(MoveIntendY));
            set => animator.SetFloat(nameof(MoveIntendY), value);
        }

        public Vector3 Velocity {
            get => new Vector3(VelocityX, VelocityY, 0f);
            set {
                VelocityX = value.x;
                VelocityY = value.y;
            }
        }
        
        float VelocityX {
            get => animator.GetFloat(nameof(VelocityX));
            set => animator.SetFloat(nameof(VelocityX), value);
        }
        
        float VelocityY {
            get => animator.GetFloat(nameof(VelocityY));
            set => animator.SetFloat(nameof(VelocityY), value);
        }
        
        protected void FixedUpdate() {
            controller.Move(Velocity * Time.deltaTime);
        }

        protected void OnValidate() {
            if (!controller) {
                TryGetComponent(out controller);
            }
        }

        public void OnMove(InputValue value) {
            MoveIntendX = value.Get<float>();
        }
    }
}