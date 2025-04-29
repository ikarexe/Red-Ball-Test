using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isHolding;
    public UnityEvent unityEvent;

    void Update()
    {
        if (_isHolding)
        {
            Debug.Log("Holding...");
            unityEvent.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown...");
        _isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp...");
        _isHolding = false;
    }
}