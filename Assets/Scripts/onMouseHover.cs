using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseHover : MonoBehaviour
{
    public Manager miMan;
    public Avatar miavatar;
    void Start()
    {
        miavatar=GetComponent<Avatar>();
        miMan = FindObjectOfType<Manager>();
    }

    public void OnMouseEnter()
    {
        Vector3 newpos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        miMan.MostrarDialogo(newpos,miavatar.Nombre, miavatar.Puntuacion, miavatar.Faltas, miavatar.mujer);    
    }

    public void OnMouseExit()
    {
        miMan.OcultarDialogo();
    }

}
