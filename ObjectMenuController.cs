using TMPro;
using UnityEngine;

public class ObjectMenuController : MonoBehaviour
{
    public TMP_Text objectName;

    public TMP_InputField positionX;
    public TMP_InputField positionY;
    public TMP_InputField positionZ;

    public TMP_InputField rotationX;
    public TMP_InputField rotationY;
    public TMP_InputField rotationZ;

    public TMP_InputField scaleX;
    public TMP_InputField scaleY;
    public TMP_InputField scaleZ;

    private GameObject _selectedObject;

    void Start()
    {
        gameObject.SetActive(false);
        ObjectManager.OnObjectSelect += OnObjectSelected;
        ObjectManager.OnObjectDeselect += OnObjectDeselected;
    }

    //error check these and reset to old value if invalid input
    public void SetNewPosition(TMP_InputField obj)
    {
        Vector3 position = _selectedObject.transform.localPosition;

        switch(obj.name)
        {
            case "PositionX":
                _selectedObject.transform.localPosition = new Vector3(float.Parse(obj.text), position.y, position.z);
                break;
            case "PositionY":
                _selectedObject.transform.localPosition = new Vector3(position.x, float.Parse(obj.text), position.z);
                break;
            case "PositionZ":
                _selectedObject.transform.localPosition = new Vector3(position.x, position.y, float.Parse(obj.text));
                break;
        }
        
    }

    public void SetNewRotation(TMP_InputField obj)
    {
        Vector3 rotation = _selectedObject.transform.localRotation.eulerAngles;

        switch (obj.name)
        {
            case "RotationX":
                _selectedObject.transform.localRotation = Quaternion.Euler(float.Parse(obj.text), rotation.y, rotation.z);
                break;
            case "RotationY":
                _selectedObject.transform.localRotation = Quaternion.Euler(rotation.x, float.Parse(obj.text), rotation.z);
                break;
            case "RotationZ":
                _selectedObject.transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, float.Parse(obj.text));
                break;
        }
    }

    public void SetNewScale(TMP_InputField obj)
    {
        Vector3 scale = _selectedObject.transform.localScale;

        switch (obj.name)
        {
            case "ScaleX":
                _selectedObject.transform.localScale = new Vector3(float.Parse(obj.text), scale.y, scale.z);
                break;
            case "ScaleY":
                _selectedObject.transform.localScale = new Vector3(scale.x, float.Parse(obj.text), scale.z);
                break;
            case "ScaleZ":
                _selectedObject.transform.localScale = new Vector3(scale.x, scale.y, float.Parse(obj.text));
                break;
        }
    }

    private void OnObjectSelected(GameObject obj)
    {
        gameObject.SetActive(true);
        _selectedObject = obj;

        objectName.text = obj.name;

        Vector3 position = obj.transform.localPosition;
        positionX.text = position.x.ToString("F");
        positionY.text = position.y.ToString("F");
        positionZ.text = position.z.ToString("F");

        Vector3 rotation = obj.transform.localRotation.eulerAngles;
        rotationX.text = rotation.x.ToString("F");
        rotationY.text = rotation.y.ToString("F");
        rotationZ.text = rotation.z.ToString("F");

        Vector3 scale = obj.transform.localScale;
        scaleX.text = scale.x.ToString("F");
        scaleY.text = scale.y.ToString("F");
        scaleZ.text = scale.z.ToString("F");
    }

    private void OnObjectDeselected(GameObject obj)
    {
        gameObject.SetActive(false);
        _selectedObject = null;
    }

}
