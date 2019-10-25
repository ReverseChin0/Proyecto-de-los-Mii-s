using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    float HighHeight, MediumHeigh, LowHeight;
    Quaternion HighRot, MedRot, LowRot, current;

    public Camera cam;

    public float limitx=40,limitz=40,sensibilidadZoom=2;
    float currentzoom=50;

    bool canMove = true;
    int indexPose = 0;

    float ValorT = 0, factorMov, tiempoMov;
    Vector3 newPos;
    void Start()
    {
        tiempoMov = 0.5f;
        HighHeight = transform.position.y;
        MediumHeigh = 12.0f;
        LowHeight = 6.0f;

        HighRot = transform.rotation;
        MedRot = Quaternion.Euler(35.0f, 0, 0);
        LowRot = Quaternion.Euler(25.0f, 0, 0);

        factorMov = 1 / tiempoMov;
    }


    void Update()
    {
        if (canMove)
        {
            currentzoom += -Input.GetAxis("Mouse ScrollWheel") * currentzoom * 10f * Time.deltaTime;
            currentzoom = Mathf.Clamp(currentzoom, 10f, 50f);
            cam.fieldOfView = currentzoom;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                canMove = false;
                indexPose--;
                if (indexPose < 0) indexPose = 0;

                switch (indexPose)
                {
                    case 0: newPos = new Vector3(transform.position.x, HighHeight, transform.position.z); current = HighRot; break;
                    case 1: newPos = new Vector3(transform.position.x, MediumHeigh, transform.position.z); current = MedRot; break;
                }
                ValorT = 0;
                return;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                canMove = false;
                indexPose++;
                if (indexPose > 2) indexPose = 2;

                switch (indexPose)
                {
                    case 1: newPos = new Vector3(transform.position.x, MediumHeigh, transform.position.z); current = MedRot; break;
                    case 2: newPos = new Vector3(transform.position.x, LowHeight, transform.position.z); current = LowRot; break;
                }
                ValorT = 0;
                return;
            }

            if (Input.GetMouseButtonDown(1))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(1)) return;

            Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

            if (transform.position.x + move.x < -limitx) move.x = 0;
            if (transform.position.x + move.x > limitx) move.x = 0;
            if (transform.position.z + move.z < -limitz * 2.4f) move.z = 0;
            if (transform.position.z + move.z > limitz * 0.6f) move.z = 0;
            transform.Translate(move, Space.World);
        }
        else
        {
            ReacomodarCamara();
        }
        
    }

    public void ReacomodarCamara()
    {
        if (ValorT < 1.0f)
        {
            ValorT += factorMov * Time.deltaTime;
            if(ValorT>1.0f)
                ValorT =1.0f;

            transform.position = Vector3.Lerp(transform.position,newPos, ValorT);
            transform.rotation = Quaternion.Lerp(transform.rotation, current, ValorT);
        }
        else
        {
            canMove = true;
        }
    }
}
