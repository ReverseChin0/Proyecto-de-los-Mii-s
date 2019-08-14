using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public Camera cam;

    public float limitx=40,limitz=40,sensibilidadZoom=2;
    float currentzoom=60;
    void Start()
    {
        
    }
    void Update()
    {

        currentzoom += -Input.GetAxis("Mouse ScrollWheel") * currentzoom * 10f * Time.deltaTime;
        currentzoom = Mathf.Clamp(currentzoom, 10f, 60f);
        cam.fieldOfView = currentzoom;

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        if (transform.position.x + move.x < -limitx) move.x = 0;
        if (transform.position.x + move.x > limitx) move.x = 0;
        if (transform.position.z + move.z < -limitz*1.5f) move.z = 0;
        if (transform.position.z + move.z > limitz) move.z = 0;
        transform.Translate(move, Space.World);
    }
}
