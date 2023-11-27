using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public Transform startPos;
    public Vector3 startScale;
    public Vector3 startLoc;
    public Quaternion startRot;
    public Transform newPosition;
    public bool forward;
    public bool origPos;
    // Start is called before the first frame update
    public void Start()
    {
        startRot = this.transform.rotation;
        startPos = this.transform;
        startLoc = this.transform.localPosition;
        startScale = this.transform.localScale;
    }
    public void MovePosForward()
    {
        this.transform.localPosition = newPosition.localPosition;
        forward = true;
        Debug.Log("Movingforward");
        origPos = false;
    }

    public void MovePosBackWards()
    {
        
        origPos = true;
        this.transform.localPosition = startLoc;
        Debug.Log("MovingBack");
        forward = false;
        this.transform.localScale = startScale;
        this.transform.rotation = startRot;
    }

    //public void ChangeObj()
    //{
        //Manager.instance.GetComponent<Manager>().changePos = this;
    //}
}
