using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;
    private MoveBehaviour _mb;

    private Vector2 vectorInput;

    public AudioClip jumpSoundFX;
    public AudioClip[] miawSoundsFX;


    public void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        _mb = GetComponent<MoveBehaviour>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("----> OnInteract");
            SoundFXManager._instance.PlayRandomSoundFXClip(miawSoundsFX, transform, 0.5f);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("----> OnJump");
        if (context.performed)
        {
            _mb.JumpCharacter();
            SoundFXManager._instance.PlaySoundFXClip(jumpSoundFX, transform, 0.5f);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("----> OnMove");
        vectorInput = context.ReadValue<Vector2>();
    }

    public void OnInvertGravityToggle(InputAction.CallbackContext context)
    {
        //Debug.Log("----> OnPowerUp");
        if (context.performed)
        {
            _mb.InvertGravity();
            SoundFXManager._instance.PlaySoundFXClip(jumpSoundFX, transform, 0.5f);
        }
    }

    public void Die()
    {
        Debug.Log("Player has died.");
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
