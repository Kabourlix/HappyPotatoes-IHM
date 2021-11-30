using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRayInteractor_Custom : XRRayInteractor
{

    protected override void OnSelectEntering(XRBaseInteractable interactable)
    {
        base.OnSelectEntering(interactable);

        if (!useForceGrab)
        {
            if (GetCurrentRaycastHit(out var raycastHit))
            {
                attachTransform.SetPositionAndRotation(
                    interactable.transform.position +
                        (gameObject.transform.position - raycastHit.point),
                    interactable.transform.rotation);
            }
        }
        else
        {
            attachTransform.SetPositionAndRotation(
                interactable.transform.position,
                interactable.transform.rotation);
        }
    }
}
