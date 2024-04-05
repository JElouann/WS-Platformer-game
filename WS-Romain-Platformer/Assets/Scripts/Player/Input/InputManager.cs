using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _input;

    public event Action<InputAction.CallbackContext, Vector2> Movement;

    public event Action<InputAction.CallbackContext> Jump;

    public event Action<InputAction.CallbackContext> Roll;

    private void Awake()
    {
        this._input = this.GetComponent<PlayerInput>();
        this._input.onActionTriggered += this.OnInput;
    }
     
    private void OnInput(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Movement":
                this.Movement?.Invoke(context, context.ReadValue<Vector2>());
                break;

            case "Jump":
                this.Jump?.Invoke(context);
                break;

            case "Roll":
                this.Roll?.Invoke(context);
                break;
        }
    }
}