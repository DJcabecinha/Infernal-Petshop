using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Button3DVR : XRBaseInteractable
{
    public UnityEvent onClick;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (onClick != null)
        {
            onClick.Invoke();
        }
    }
}
