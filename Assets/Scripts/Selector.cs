using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Selector : MonoBehaviour
{
    List<Avatar> Seleccionados;
    Color elColor;
    public Material MaterialBordes;
    Renderer head, body;

    void Start()
    {
        Seleccionados = new List<Avatar>();
    }
    

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.D))
        {
            DeselectEverything();
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A))
        {
            SelectEverything();
        }
    }

    public void AddtoSelected(Avatar _ava)
    {
        if (!Seleccionados.Contains(_ava))
        {
            Seleccionados.Add(_ava);
            Shade(_ava);
        }
        else
        {
            Deselect(_ava);
        }
    }

    public void Select(Avatar _ava)
    {
        
        if (Seleccionados.Count > 0)
        {
            DeselectEverything();
        }
        Seleccionados.Add(_ava);
        Shade(_ava);
       
    }

    public void Deselect(Avatar _av)
    {
         int i = Seleccionados.IndexOf(_av);
         Seleccionados[i].ResetMat();
         Seleccionados.RemoveAt(i);
    }

    public void Shade(Avatar _a)
    {
        head = _a.transform.GetChild(0).GetChild(0).GetComponent<Renderer>();
        elColor = head.material.color;
        head.material = MaterialBordes;
        head.material.SetColor("_Color", elColor);

        body = _a.transform.GetChild(0).GetChild(1).GetComponent<Renderer>();
        elColor = body.material.color;
        body.material = MaterialBordes;
        body.material.SetColor("_Color", elColor);
    }

    public void DeselectEverything()
    {
        if (Seleccionados.Count > 0)
        {
            foreach (Avatar _av in Seleccionados)
            {
                _av.ResetMat();
            }
            Seleccionados.Clear();
        }  
    }

    public void SelectEverything()
    {
        Seleccionados=FindObjectsOfType<Avatar>().ToList();
        foreach(Avatar a in Seleccionados)
        {
            Shade(a);
        }
    }
}
