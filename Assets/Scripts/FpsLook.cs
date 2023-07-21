using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLook : MonoBehaviour
{
    const float yMinimum = -90;
    const float yMaximum = 45;
    [SerializeField] Camera cam;
    [SerializeField] Transform Body;

    Vector3 mouseDelta;
    Vector3 viewAngle;


    public float sensitivity = 2;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
    }

    // Update is called once per frame
    void Update()
    {
        mouseDelta = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"),0);
        viewAngle.x = Mathf.Clamp(viewAngle.x + mouseDelta.x, yMinimum, yMaximum);
        viewAngle.y += mouseDelta.y * sensitivity;

        cam.transform.localRotation = Quaternion.Euler(viewAngle.x, 0, 0);
        Body.transform.rotation = Quaternion.Euler(0, viewAngle.y,0);
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0,200,Screen.width, Screen.height));
        GUILayout.Label($"Camera rotation: {cam.transform.localRotation.eulerAngles}");
        GUILayout.Label($"Mouse delta {mouseDelta}");
        GUILayout.EndArea();
    }
}
