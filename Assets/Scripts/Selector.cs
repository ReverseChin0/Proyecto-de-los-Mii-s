using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{
    [HideInInspector]
    public List<Avatar> Seleccionados;
    [HideInInspector]
    public int nSelected = 0;
    Color elColor;
    public Material MaterialBordes;
    Renderer head, body;
    public GameObject checarbtn;//, cambiarMail;

    public static Selector instancia;  

    void Start()
    {
        Seleccionados = new List<Avatar>();

        instancia = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl))
        {
            if (EventSystem.current.currentSelectedGameObject == null) {
                RaycastHit hitInfo;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.name == "Plane")
                    {
                        DeselectEverything();
                    }
                }
            };
            
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A))
        {
            SelectEverything();
        }

    }

    public void AddtoSelected(Avatar _ava)
    {
        checarbtn.SetActive(false);
        if (!Seleccionados.Contains(_ava))
        {
            Seleccionados.Add(_ava);
            Shade(_ava);
        }
        else
        {
            Deselect(_ava);
        }
        checknSelected();
    }

    public void Select(Avatar _ava)
    {
        checarbtn.SetActive(true);
        if (Seleccionados.Count > 0)
        {
            DeselectEverything();
        }
        Seleccionados.Add(_ava);
        Shade(_ava);
        checknSelected();

    }

    public void Deselect(Avatar _av)
    {
        
        int i = Seleccionados.IndexOf(_av);
         Seleccionados[i].ResetMat();
         Seleccionados.RemoveAt(i);
        checknSelected();
        _av.SelectBodyOutline(false);
    }

    public void Shade(Avatar _a)
    {
        /* head = _a.transform.GetChild(0).GetChild(0).GetComponent<Renderer>();
         elColor = head.material.color;
         head.material = MaterialBordes;
         head.material.SetColor("_Color", elColor);

         body = _a.transform.GetChild(0).GetChild(1).GetComponent<Renderer>();
         elColor = body.material.color;
         body.material = MaterialBordes;
         body.material.SetColor("_Color", elColor);*/
        _a.SelectBodyOutline(true);
    }

    public void DeselectEverything()
    {
        checarbtn.SetActive(false);
        if (Seleccionados.Count > 0)
        {
            foreach (Avatar _av in Seleccionados)
            {
                _av.ResetMat();
            }
            Seleccionados.Clear();
        }
        checknSelected();
    }

    public void SelectEverything()
    {
        Seleccionados = FindObjectsOfType<Avatar>().ToList();
        foreach(Avatar a in Seleccionados)
        {
            Shade(a);
        }
        checknSelected();
    }

    public void checknSelected()
    {
        nSelected=Seleccionados.Count;
        if (nSelected > 1)
        {
            checarbtn.SetActive(false);
            //cambiarMail.SetActive(false);
        }
        else if(nSelected == 1)
        {
            checarbtn.SetActive(true);
            //cambiarMail.SetActive(true);
        }
        else
        {
            checarbtn.SetActive(false);
            //cambiarMail.SetActive(false);
        }
    }

    public Avatar givefirstseleccionado()
    {
        if (nSelected == 1)
        {
            return Seleccionados[0];
        }
        return null;
    }
}
