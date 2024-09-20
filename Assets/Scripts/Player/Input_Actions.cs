using UnityEngine;

public class Input_Actions : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    public float Horizontal;
    public float Vertical;

    private void Update()
    {
        Horizontal = _inputActions.Player.Move.ReadValue<Vector2>().x;
        Vertical = _inputActions.Player.Move.ReadValue<Vector2>().y;
    }

    private void Awake() { _inputActions = new InputSystem_Actions(); }
    
    private void OnEnable () { _inputActions.Enable(); _inputActions.Player.Enable(); }
    
    private void OnDisable() { _inputActions.Disable(); }
}
