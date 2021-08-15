using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using AttTypeDefine;

public class CommomJoyBtn : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    #region Sys Funcs
    private void Awake()
    {
        pressDown = new GameBtnEvent();
        onDragEvent = new GameBtnEvent();
        pressUp = new GameBtnEvent();
    }
    #endregion
    #region Joy Stick Event Callback
    public Image imageBackGround;
    public Image imageHandle;
    public float maxRadius;

    public GameBtnEvent pressDown;
    public GameBtnEvent onDragEvent;
    public GameBtnEvent pressUp;

    protected Vector3 _Dir;
    public Vector3 Dir => (_Dir);

    Vector3 pointDownPos;
    int FingerId = int.MinValue;

    public void OnPointerDown(PointerEventData eventData)
    {
        if((FingerId = eventData.pointerId) < -1)
        {
            return;
        }
        imageBackGround.transform.position = pointDownPos = eventData.position;
        pressDown?.Invoke(eventData);
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
        imageHandle.transform.localPosition = localPos;
        _Dir = imageHandle.transform.localPosition.normalized;

        onDragEvent?.Invoke(eventData);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if ((FingerId = eventData.pointerId) < -1)
        {
            return;
        }
        _Dir = imageHandle.transform.localPosition = Vector3.zero;

        pressUp?.Invoke(eventData);
    }
    #endregion
}
