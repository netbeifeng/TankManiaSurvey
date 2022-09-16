using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VirtualStickAutoShoot : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    [FormerlySerializedAs("movementRange")]
    [SerializeField]
    private float m_MovementRange = 100;

    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string m_ControlPath;

    private Vector3 m_StartPos;
    private Vector2 m_PointerDownPos;

    public Transform stickBtn;
    public Turret tankTurret;

    private bool shooting=false;

    private void Start()
    {
        m_StartPos = ((RectTransform)stickBtn).anchoredPosition;
        InvokeRepeating("AutomaticShooting",0, 0.7f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out m_PointerDownPos);
        stickBtn.transform.localPosition = m_PointerDownPos;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out var fingerPosition);
        var delta = fingerPosition - m_PointerDownPos;

        delta = Vector2.ClampMagnitude(delta, movementRange);
        ((RectTransform)stickBtn).anchoredPosition = m_StartPos + (Vector3)delta;

        var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
        SendValueToControl(newPos);

        Vector3 stickPosition = stickBtn.transform.localPosition;
        isAbleToShootDisToCenter(stickPosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        //comparing mouse/finger position on screen to joystick background rect
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponentInParent<RectTransform>(), eventData.position, eventData.pressEventCamera, out var fingerPosition);

        //compare stick center pos to stick background center pos
        Vector3 position = stickBtn.transform.localPosition;

        Debug.Log("Right Stick Released");
        shooting = false;
        

        //Resetting stick position to original
        ((RectTransform)stickBtn).anchoredPosition = m_StartPos;
        SendValueToControl(Vector2.zero);
    }

    private bool isAbleToShootDisToCenter(Vector3 vec)
    {
        float currentDis = (vec - this.transform.localPosition).magnitude;
        Debug.Log("Dist comp:" + vec + "..." + this.transform.localPosition + " Dist:" + currentDis);
        if (currentDis > 95)
        {
            shooting = true;
            stickBtn.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            return true;
        }
        else
        {
            stickBtn.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            return false;
        }
    }

   
    private void AutomaticShooting()
    {
        if (shooting)
        {
            tankTurret.Shoot();
        }
    }


    public float movementRange
    {
        get => m_MovementRange;
        set => m_MovementRange = value;
    }

    protected override string controlPathInternal
    {
        get => m_ControlPath;
        set => m_ControlPath = value;
    }
}
