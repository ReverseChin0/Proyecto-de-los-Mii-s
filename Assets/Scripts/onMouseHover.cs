using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseHover : MonoBehaviour
{
    [SerializeField]
    bool suelo = false;

    bool hoverable = true;

    public Manager miMan;
    public SceneChanger changer;
    public Avatar miavatar;
    SceneChanger[] mychangers;

    public GameObject btnCheck;
    void Start()
    {
        mychangers = FindObjectsOfType<SceneChanger>();
        if (mychangers.Length > 1)
        {
            changer = mychangers[mychangers.Length-1];
        }
        else
        {
            changer = mychangers[0];
        }
        
        if (!suelo)
        {
            miavatar = GetComponent<Avatar>();
            miMan = FindObjectOfType<Manager>();
        }
    }

    public void OnMouseEnter()
    {
        if (!suelo && hoverable)
        {
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            miMan.MostrarDialogo(newpos, miavatar.Nombre, miavatar.Puntuacion, miavatar.Faltas, miavatar.mujer);
        }
        
    }

    public void OnMouseExit()
    {
        if (!suelo && hoverable)
        {
            miMan.OcultarDialogo();
        }
    }

    public void OnMouseDown()
    {
        if (!suelo && hoverable)
        {
            changer.miAvatar = gameObject.GetComponent<Avatar>();
            miMan.ActivarBtnChange(true);
        }
        else
        {
            //changer.ActivarBtnChange(false);
        }
    }

    public void setHover(bool t)
    {
        hoverable = t;
    }
}
