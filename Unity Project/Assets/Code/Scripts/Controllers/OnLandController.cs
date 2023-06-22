using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.CustomInput;
using UnityEngine;
using UnityEngine.Serialization;

public class OnLandController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField]
    private OnLandInput input;

    private Vector3 _playerMoveInput = Vector3.zero;

    [FormerlySerializedAs("_movementMultiplier")]
    [Header("Movement")]
    [SerializeField] private float movementMultiplier = 30f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _playerMoveInput = GetMoveInput();
        PlayerMove();
        
        _rigidbody.AddRelativeForce(_playerMoveInput, ForceMode.Force);
    }
    
    private Vector3 GetMoveInput()
    {
        return new Vector3(input.MoveInput.x, 0f, input.MoveInput.y);
    }
    
    private void PlayerMove()
    {
        var mass = _rigidbody.mass;

        _playerMoveInput = new Vector3(
            _playerMoveInput.x * movementMultiplier * mass,
             _playerMoveInput.y,
             _playerMoveInput.z * movementMultiplier * mass
        );
    }
}
