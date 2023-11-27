using UnityEngine;

/// <summary>
/// Set the rotation of an object
/// </summary>
public class RotateObject : MonoBehaviour
{
    [Tooltip("The value at which the speed is applied")]
    [Range(0, 1)] public float sensitivity = 1.0f;

    [Tooltip("The max speed of the rotation")]
    public float speed = 10.0f;

    private bool isRotatingRight = false;
    private bool isRotatingLeft = false;

    public void SetIsRotating(bool value)
    {
        if(value)
        {
            RightBegin();
            LeftBegin();
        }
        else
        {
            RightEnd();
            LeftEnd();
        }
    }
    public void LeftBegin()
    {
        isRotatingLeft = true;
    }

    public void RightBegin()
    {
        isRotatingRight = true;
    }

    public void RightEnd()
    {
        isRotatingRight = false;
    }

    public void LeftEnd()
    {
        isRotatingLeft = false;
    }

    public void ToggleRotateRight()
    {
        isRotatingRight = !isRotatingRight;
    }
    public void ToggleRotateLeft()
    {
        isRotatingLeft = !isRotatingLeft;
    }


    public void SetSpeed(float value)
    {
        sensitivity = Mathf.Clamp(value, 0, 1);
        isRotatingRight = (sensitivity * speed) != 0.0f;
        isRotatingLeft = (sensitivity * speed) != 0.0f;
    }

    private void Update()
    {
        if (isRotatingRight)
        {
            RightRotate();
        }

        if (isRotatingLeft)
        {
            LeftRotate();
        }

    }

    private void RightRotate()
    {
        transform.Rotate(transform.up, (sensitivity * -speed) * Time.deltaTime);
    }

    private void LeftRotate()
    {
        transform.Rotate(transform.up, (sensitivity *  speed) * Time.deltaTime);
    }
}
