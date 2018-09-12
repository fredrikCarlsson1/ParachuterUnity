using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {
    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeftPressed;
    public static event ButtonPressed OnRightPressed;

    public bool left;

    private void OnMouseDown()
    {
        if (OnLeftPressed != null && left)
        {
            OnLeftPressed();
        }
        else if (OnRightPressed != null)
        {
            OnRightPressed();
        }
    }

}
