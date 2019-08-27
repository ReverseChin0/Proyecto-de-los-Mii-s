using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseHover : MonoBehaviour
{
    [SerializeField]

    bool hoverable = true;

    public Manager miMan;
    public SceneChanger changer;
    public Avatar miavatar;
    SceneChanger[] mychangers;

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
        
        miavatar = GetComponent<Avatar>();
        miMan = FindObjectOfType<Manager>();
    }

    public void OnMouseEnter()
    {
      
        if (hoverable)
        {
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            switch (miMan.lastselected)
            {
                default: miMan.MostrarDialogo(newpos, miavatar.Nombre,"Puntuacion: "+ miavatar.Puntuacion.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + (miavatar.RefGE+ miavatar.RefGI).ToString()); break;
            }   
        }
        
    }

    public void OnMouseExit()
    {
        if (hoverable)
        {
            miMan.OcultarDialogo();
        }
    }

    public void OnMouseDown()
    {
        if (hoverable)
        {
            changer.miAvatar = gameObject.GetComponent<Avatar>();
            miMan.ActivarBtnChange(true);
        }
      
    }

    public void setHover(bool t)
    {
        hoverable = t;
    }
}
