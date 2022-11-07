using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleGrabTemporally : MonoBehaviour
{
    private XRRayInteractor _xrRayInteractor;
    private IXRSelectInteractable _xrGrabLayer;
    private int _notGrabbable = 6;
    private int _grabbable = 7;

    // Start is called before the first frame update
    void Start()
    {
        _xrRayInteractor = GetComponent<XRRayInteractor>();
    }

    public void ChangeToNotGrabbable()
    {
        _xrGrabLayer = _xrRayInteractor.interactablesSelected[0];
        if (_xrGrabLayer.transform.gameObject.layer == _grabbable)
        {
            _xrGrabLayer.transform.gameObject.layer = _notGrabbable;
            var componentsInChildren = _xrGrabLayer.transform.gameObject.GetComponentsInChildren<Transform>(includeInactive : true);
            Debug.Log(componentsInChildren.Length);
            if (componentsInChildren.Length == 1)
            {
                return;
            }
            else
            {
                foreach (Transform child in componentsInChildren)
                {
                    child.gameObject.layer = _notGrabbable;
                }
            }
        }
    }

    public void ChangeToDefault()
    {
        if (_xrGrabLayer.transform.gameObject.layer == _notGrabbable)
        {
            _xrGrabLayer.transform.gameObject.layer = _grabbable;
            var componentsInChildren = _xrGrabLayer.transform.gameObject.GetComponentsInChildren<Transform>(includeInactive: true);
            Debug.Log(componentsInChildren.Length);
            if (componentsInChildren.Length == 1)
            {
                return;
            }
            else
            {
                foreach (Transform child in componentsInChildren)
                {
                    child.gameObject.layer = _grabbable;
                }
            }
        }
    }
}
