using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;
    private MoveBehaviour _mb;

    private Vector2 vectorInput;


    public void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        _mb = GetComponent<MoveBehaviour>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("----> OnInteract");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("----> OnJump");
        _mb.JumpCharacter();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("----> OnMove");
        vectorInput = context.ReadValue<Vector2>();
    }

    public void OnInvertGravityToggle(InputAction.CallbackContext context)
    {
        //Debug.Log("----> OnPowerUp");
        _mb.InvertGravity();
    }

    public void OnEnable()
    {
        inputActions.Player.Enable();
    }

    public void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Update()
    {
        _mb.MoveCharacter(vectorInput);
    }
}
