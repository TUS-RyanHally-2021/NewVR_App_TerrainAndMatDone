using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public RightSelect rightSelect;
    public LeftSelect leftSelect;
    public ChangePosition changePos;
    public RotateObject rotateObj;
    public GameObject leftObjectIWant;
    public GameObject rightObjectIWant;
    public Material mat;
    public Color startmatColor;
    public Material otherMat;
    public Color startOtherMatColor;
    // Start is called before the first frame update
    void Start()
    {
        mat.color = startmatColor;
        otherMat.color = startOtherMatColor;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (rightSelect.rightSelectedObject.GetComponent<ChangePosition>() != null)
        {
            rightObjectIWant = rightSelect.rightSelectedObject;
            changePos = rightObjectIWant.GetComponent<ChangePosition>();
            rotateObj = changePos.gameObject.GetComponent<RotateObject>();
        } else
        {
            rightObjectIWant = null;
        }
         if (leftSelect.leftSelectedObject.GetComponent<ChangePosition>() != null)
        {
            leftObjectIWant = leftSelect.leftSelectedObject;
            changePos = leftObjectIWant.GetComponent<ChangePosition>();
            rotateObj = changePos.gameObject.GetComponent<RotateObject>();
        } else
        {
            leftObjectIWant = null;
        }
       if (rightSelect.selected && leftSelect.selected)
        {
            Debug.Log("BOTHHANDS");
            rightSelect.GetComponent<XRInteractorLineVisual>().enabled = false;
            leftSelect.GetComponent<XRInteractorLineVisual>().enabled = false;
        }  else
        {
            rightSelect.GetComponent<XRInteractorLineVisual>().enabled = true;
            leftSelect.GetComponent<XRInteractorLineVisual>().enabled = true;
        }
    }
    //public void GetObjects()
    //{
        //theObjectIWant = gameObject.Find
        //changePos = GameObject.FindObjectOfType<ChangePosition>().GetComponent<ChangePosition>();
        //rotateObj = changePos.gameObject.GetComponent<RotateObject>();
   // }

    public void UnSelectObject()
    {
        if(rightSelect.selected && changePos.forward)
        {
            changePos.transform.position = changePos.transform.position;
            rightSelect.selected = false;
        }

        if (leftSelect.selected && changePos.forward)
        {
            changePos.transform.position = changePos.transform.position;
            leftSelect.selected = false;
        }
    }
    public void ResetObj()
    {
        changePos.MovePosBackWards();
    }
    public void RotateClockWise()
    {

        if (rightSelect.selected && changePos.forward)
        {
            rotateObj.RightBegin();
        }

        if (leftSelect.selected && changePos.forward)
        {
            rotateObj.RightBegin();
        }
    }

    public void RotateAntiClockWise()
    {

        if (rightSelect.selected && changePos.forward)
        {
            rotateObj.LeftBegin();
        }
        

        if (leftSelect.selected && changePos.forward)
        {
            rotateObj.LeftBegin();
        }
    }

    public void RotateClockWiseEnd()
    {
        rotateObj.RightEnd();
    }

    public void RotateAntiClockWiseEnd()
    {
        rotateObj.LeftEnd();
    }

    public void LoadNextScene()
    {
        Debug.Log("Loading");
        SceneManager.LoadScene("Experience");
    }
    public void HoverMat()
    {
        mat.color = Color.red;
    }

    public void ExitHoverMat()
    {
        mat.color = startmatColor;
    }

    public void HoverWallMat()
    {
        otherMat.color = Color.red;
    }
    public void ExitHoverWallMat()
    {
        otherMat.color = startOtherMatColor;
    }
}
