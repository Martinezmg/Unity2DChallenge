using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

/// <summary>
/// Tap controller using TouchScript package
/// </summary>
public class GlobalTap : MonoBehaviour
{
    private TapGesture tap_g;

    public Vector2Variable touchPosition;
    public Vector2Variable touchPositionRaw;


    private void OnEnable()
    {
        tap_g = GetComponent<TapGesture>();

        tap_g.Tapped += tappedHandler;
    }

    private void OnDisable()
    {
        tap_g.Tapped -= tappedHandler;
		
		touchPositionRaw.SetValue(Vector2.zero);
        touchPosition.SetValue(Vector2.zero); 
    }

    private void tappedHandler(object sender, System.EventArgs e)
    {
        touchPositionRaw.SetValue(tap_g.ScreenPosition);
        touchPosition.SetValue(Camera.main.ScreenToWorldPoint(tap_g.ScreenPosition));        
    }
}
