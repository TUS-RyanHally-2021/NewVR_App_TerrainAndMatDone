using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RightSelect : MonoBehaviour
{
    public XRRayInteractor rightRayInteractor;
    public bool selected;
    public GameObject rightSelectedObject;
    // Start is called before the first frame update
    private void Start()
    {
        rightSelectedObject = null;
        rightRayInteractor = gameObject.GetComponent<XRRayInteractor>();
    }
    private void Update()
    {
       
    }
    public void OnRightSelectEntered(SelectEnterEventArgs args)
    {
        rightSelectedObject = args.interactable.gameObject;
    }
    public void OnRightSelect()
    {
        selected = true;
    }

    public void OnRightUnSelect()
    {
        selected = false;
    }
}
