using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleGrabTemporally : MonoBehaviour
{
    private XRRayInteractor _xrRayInteractor;
    private IXRSelectInteractable _xrGrabLayer;

    // Start is called before the first frame update
    void Start()
    {
        _xrRayInteractor = GetComponent<XRRayInteractor>();
    }

    public void ChangeToNotGrabbable()
    {
        if (_xrRayInteractor.interactablesSelected.Count == 1)
        {
            _xrGrabLayer = _xrRayInteractor.interactablesSelected[0];
            _xrGrabLayer.transform.gameObject.layer = 6;
        }
    }

    public void ChangeToDefault()
    {
        _xrGrabLayer.transform.gameObject.layer = 0;
    }
}
