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
                case 2: miMan.MostrarDialogo(newpos, miavatar.Nombre, "Faltas: " + miavatar.Faltas.ToString(), "Puntuacion: " + miavatar.Puntuacion.ToString(), "GNC: " + miavatar.GNC.ToString()); break;
                case 5: miMan.MostrarDialogo(newpos, miavatar.Nombre, "GNC: " + miavatar.GNC.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;
                case 6: miMan.MostrarDialogo(newpos, miavatar.Nombre, "Invitados: " + miavatar.Invitados.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;
                case 7: miMan.MostrarDialogo(newpos, miavatar.Nombre, "UdeF: " + miavatar.Formaciones.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;
                case 8: miMan.MostrarDialogo(newpos, miavatar.Nombre, "RefGeneradas: " + miavatar.RefGTotal.ToString(), "Internas: " + miavatar.RefGI.ToString(), "Externas: " + miavatar.RefGE.ToString()); break;
                case 9: miMan.MostrarDialogo(newpos, miavatar.Nombre, "Uno a Uno: " + miavatar.Uno_a_Uno.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;

                case 13: miMan.MostrarDialogo(newpos, miavatar.Nombre, "GNC: " + miavatar.GNC.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;
                case 14: miMan.MostrarDialogo(newpos, miavatar.Nombre, "Invitados: " + miavatar.Invitados.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;
                case 15: miMan.MostrarDialogo(newpos, miavatar.Nombre, "UdeF: " + miavatar.Formaciones.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;
                case 16: miMan.MostrarDialogo(newpos, miavatar.Nombre, "RefGeneradas: " + miavatar.RefGTotal.ToString(), "Internas: " + miavatar.RefGI.ToString(), "Externas: " + miavatar.RefGE.ToString()); break;
                case 17: miMan.MostrarDialogo(newpos, miavatar.Nombre, "Uno a Uno: " + miavatar.Uno_a_Uno.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;

                case 18:
                case 19: 
                case 20:
                case 21: miMan.MostrarDialogo(newpos, miavatar.Nombre, "RefGeneradas: " + miavatar.RefGTotal.ToString(), "Internas: " + miavatar.RefGI.ToString(), "Externas: " + miavatar.RefGE.ToString()); break;
                case 22:
                case 23:
                case 24:
                case 25: miMan.MostrarDialogo(newpos, miavatar.Nombre, "RefRecibidas: " + miavatar.RefRTotal.ToString(), "Internas: " + miavatar.RefRI.ToString(), "Externas: " + miavatar.RefRE.ToString()); break;
                default: miMan.MostrarDialogo(newpos, miavatar.Nombre,"Puntuacion: "+ miavatar.Puntuacion.ToString(), "Faltas: " + miavatar.Faltas.ToString(), "Referencias: " + miavatar.RefGTotal.ToString()); break;
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
            //miMan.ActivarBtnChange(true, changer.miAvatar.Correo);

            if (Input.GetKey(KeyCode.LeftControl))
            {
                miMan.SelectionType(0, changer.miAvatar);
            }
            else
            {
                miMan.SelectionType(1, changer.miAvatar);
            }
        }
    }

    public void setHover(bool t)
    {
        hoverable = t;
    }
}
