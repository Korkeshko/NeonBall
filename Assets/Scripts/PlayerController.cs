using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public VirtualJoystick joystick;
    public float speed = 5f;

    private void Update()
    {
        Vector2 movementInput = joystick.GetInput();
        // Используйте movementInput для управления персонажем
        // Например, перемещение:
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        transform.Translate(movement * Time.deltaTime * speed);
    }
}