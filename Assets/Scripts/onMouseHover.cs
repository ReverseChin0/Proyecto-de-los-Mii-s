using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseHover : MonoBehaviour
{
    [SerializeField]
    bool suelo = false;
        
    public Manager miMan;
    public SceneChanger changer;
    public Avatar miavatar;
    void Start()
    {
        changer = FindObjectOfType<SceneChanger>();
        if (!suelo)
        {
            miavatar = GetComponent<Avatar>();
            miMan = FindObjectOfType<Manager>();
        }
    }

    public void OnMouseEnter()
    {
        if (!suelo)
        {
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            miMan.MostrarDialogo(newpos, miavatar.Nombre, miavatar.Puntuacion, miavatar.Faltas, miavatar.mujer);
        }
        
    }

    public void OnMouseExit()
    {
        if (!suelo)
        {
            miMan.OcultarDialogo();
        }
    }

    public void OnMouseDown()
    {
        if (!suelo)
        {
            changer.miAvatar = gameObject.GetComponent<Avatar>();
        }
    }
}
