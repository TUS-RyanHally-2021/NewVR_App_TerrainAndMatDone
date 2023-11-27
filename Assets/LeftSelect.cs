using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftSelect : MonoBehaviour
{
    public XRRayInteractor leftRayInteractor;
    public GameObject leftSelectedObject;
    public bool selected;
    // Start is called before the first frame update
    private void Start()
    {
        leftSelectedObject = null;
        leftRayInteractor = gameObject.GetComponent<XRRayInteractor>();
    }

    private void Update()
    {

    }

    public void OnLeftSelectEntered(SelectEnterEventArgs args)
    {
        leftSelectedObject = args.interactable.gameObject;
    }

    public void OnLeftSelect()
    {
        selected = true;
    }

    public void OnLeftUnSelect()
    {
        selected = false;
    }
}
