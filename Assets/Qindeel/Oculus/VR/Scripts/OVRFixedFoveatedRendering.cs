using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Setting a high Fixed Foveated Rendering can increase performance by reducing the visual quality at the edge of the view.
/// By default (without this script), the level is set dynamically by the headset.
/// 
/// To verify that the FFR level is working, look at the FOV metric in OVR Metrics Tool.
/// 
/// References:
/// - https://developer.oculus.com/documentation/unity/unity-fixed-foveated-rendering/
/// - https://developer.oculus.com/resources/unity-settings-features-minimize-iteration/
/// </summary>
public class OVRFixedFoveatedRendering : MonoBehaviour
{
    [SerializeField] private OVRManager.FixedFoveatedRenderingLevel ffrLevel = OVRManager.FixedFoveatedRenderingLevel.Off;

    private void Start()
    {
        SetFFRLevel(ffrLevel);
    }

    public void SetFFRLevel(OVRManager.FixedFoveatedRenderingLevel level) {
        OVRManager.fixedFoveatedRenderingLevel = level;
        OVRManager.useDynamicFixedFoveatedRendering = false;
    }

    public void IncreaseFFRLevel() {
        ffrLevel = (OVRManager.FixedFoveatedRenderingLevel)((int)++OVRManager.fixedFoveatedRenderingLevel % 5);
        SetFFRLevel(ffrLevel);
    }

    public void DecreaseFFRLevel() {
        ffrLevel = (OVRManager.FixedFoveatedRenderingLevel)((int)++OVRManager.fixedFoveatedRenderingLevel % 5);
        SetFFRLevel(ffrLevel);
    }
}
