using UnityEngine;
using UnityEngine.EventSystems;

public class CommomJoyBtn : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    #region Joy Stick Event Callback
    public Transform transBackground;
    public Transform transHandle;
    public float maxRadius;

    Vector3 _Dir;
    public Vector3 Dir => (_Dir);

    Vector3 pointDownPos;
    int FingerId = int.MinValue;
    public void OnPointerDown(PointerEventData eventData)
    {
        if((FingerId = eventData.pointerId) < -1)
        {
            return;
        }
        transBackground.position = pointDownPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if ((FingerId = eventData.pointerId) < -1)
        {
            return;
        }

        var distance = (eventData.position - (Vector2)pointDownPos);
        var radius = Mathf.Clamp(Vector3.Magnitude(distance), 0, maxRadius);
        var tmp = radius * distance.normalized;
        var localPos = new Vector2()
        {
            x = tmp.x, 
            y = tmp.y
        };
        transHandle.localPosition = localPos;
        _Dir = transHandle.localPosition.normalized;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if ((FingerId = eventData.pointerId) < -1)
        {
            return;
        }
        _Dir = transHandle.localPosition = Vector3.zero;
    }
    #endregion
}
