using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform joystickHandle;
    public float moveRange = 50f; // Максимальное расстояние, на которое может двигаться джойстик

    private Vector2 inputVector;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Начало перетаскивания
        UpdateJoystickPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Обновление позиции джойстика во время перетаскивания
        UpdateJoystickPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Сброс джойстика при завершении перетаскивания
        joystickHandle.anchoredPosition = Vector2.zero;
        inputVector = Vector2.zero;
    }

    private void UpdateJoystickPosition(PointerEventData eventData)
    {
        Vector2 position = eventData.position - (Vector2)transform.position;
        inputVector = Vector2.ClampMagnitude(position, moveRange) / moveRange;
        joystickHandle.anchoredPosition = inputVector * moveRange;
    }

    public Vector2 GetInput()
    {
        return inputVector;
    }
}