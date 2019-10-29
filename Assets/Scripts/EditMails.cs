using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class EditMails : MonoBehaviour
{
    Selector miSelector;
    public Transform Parent;

    [SerializeField]
    private GameObject Prefab;
    GameObject currentGO;
    Button Btn;

    List<string> nombres = new List<string>();
    List<string> correos = new List<string>();
    int nContenidos = 0;

    bool showing = false;
    public void GenerateList()
    {
        if (!showing)
        {
            nombres.Clear();
            correos.Clear();
            nContenidos = 0;
            CkeckSelected();
            InsertContenido();
            showing = true;
        }
        else
        {
            showing = false;
            DeleteContenidos();
        }
    }

    void CkeckSelected()
    {
        if (Selector.instancia.nSelected > 0)
        {
            foreach(Avatar S in Selector.instancia.Seleccionados)
            {
                nombres.Add(S.Nombre);
                correos.Add(S.Correo);
                nContenidos++;
            }
        }
        else
        {
            foreach (Avatar S in FindObjectsOfType<Avatar>().ToList())
            {
                nombres.Add(S.Nombre);
                correos.Add(S.Correo);
                nContenidos++;
            }
        }
    }

    void InsertContenido()
    {
        for(int i = 0; i < nContenidos; i++)
        {
            GameObject GO = Instantiate(Prefab);
            GO.transform.GetChild(0).GetComponent<Text>().text = nombres[i];
            GO.transform.GetChild(1).GetComponentInChildren<Text>().text = correos[i];
          //Debug.Log(GO.transform.GetChild(1).GetComponentInChildren<Text>() + " "+ correos[i]);
            GO.transform.SetParent(Parent);
            GO.transform.localScale = new Vector3(1,1,1);
        }
    }

    void DeleteContenidos()
    {
        foreach(Transform t in Parent)
        {
            Destroy(t.gameObject);
        }
    }

    void getBtn()
    {
        Btn = currentGO.transform.GetChild(2).GetComponent<Button>();
        Btn.onClick.AddListener(SendDataToDataBase);
    }

    void SendDataToDataBase()
    {
        Debug.Log("Info was Sent");
    }
}
