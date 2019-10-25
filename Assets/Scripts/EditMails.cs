using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    void GenerateList(GameObject obj)
    {
        nombres.Clear();
        correos.Clear();
        nContenidos = 0;
        CkeckSelected();
        InsertContenido();
    }

    void CkeckSelected()
    {
        if (Selector.instancia.nSelected > 0)
        {
            foreach(Avatar S in Selector.instancia.Seleccionados)
            {
                nombres.Add(S.Nombre +" "+S.Apellido);
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
            GO.transform.GetChild(1).GetComponent<Text>().text = nombres[i];
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
