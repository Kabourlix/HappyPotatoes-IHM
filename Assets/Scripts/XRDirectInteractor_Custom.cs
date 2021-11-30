using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRDirectInteractor_Custom : XRDirectInteractor
{

    protected new void OnTriggerEnter(Collider col)
    {
        base.OnTriggerEnter(col);
        XRBaseInteractable interactable = interactionManager.TryGetInteractableForCollider(col);
        attachTransform.SetPositionAndRotation(
            interactable.transform.position,
            interactable.transform.rotation);
    }
}
