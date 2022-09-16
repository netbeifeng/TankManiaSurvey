using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class ShootControl : OnScreenControl
{
    public void click()
    {
        Debug.Log("Clicked");
        SendValueToControl(1f);
    }

    public void release()
    {
        Debug.Log("Released");
        SendValueToControl(0.0f);
    }

    [InputControl(layout = "Button")]
    [SerializeField]
    private string m_ControlPath;

    protected override string controlPathInternal
    {
        get => m_ControlPath;
        set => m_ControlPath = value;
    }
}
