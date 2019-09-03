using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Camera mainCam;
    public Animator MiiDisplay;
    public GameObject DialogBox, btnCheckCharacter;
    public Text Name, Param1, Param2, Param3;
    [Header("Avatar Behaviour")]
    List<Avatar> Todos;
    List<Transform> objetivos;
    public GameObject miiAvatar;
    [Tooltip("Cuantos mii´s, habrá en la simulacion")]
    public int lastselected = 0;//0=idlewalk,1=edad,2=peso,3=genero,,4=nombre,5=color;
    int NumeroAvatares, nMujeres = 0;
    [SerializeField]
    ReporteGeneral Reporte;

    public float limitex = 10, limitez = 10;

    void Start()
    {

    }

    public void StartManager(List<JsonData> datos)
    {
        Todos = new List<Avatar>();
        objetivos = new List<Transform>();
        NumeroAvatares = datos.Count;
        for (int i = 0; i < datos.Count; i++)
        {
            GameObject go = Instantiate(miiAvatar, new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)), Quaternion.identity);
            Avatar currentAvatar = go.GetComponent<Avatar>();
            currentAvatar.InicializarAvatar(double.Parse(datos[i].GPNC), datos[i].Nombre, datos[i].Apellido, int.Parse(datos[i].Faltas), int.Parse(datos[i].Presente), int.Parse(datos[i].Tarde), int.Parse(datos[i].FaltasMedicas), int.Parse(datos[i].FaltasSustituidas), int.Parse(datos[i].RefRI), int.Parse(datos[i].RefRe), int.Parse(datos[i].UdeF), float.Parse(datos[i].Invitados), int.Parse(datos[i].RefDI), int.Parse(datos[i].RefDE), float.Parse(datos[i].UnoaUno));
            Reporte.addDatos(double.Parse(datos[i].GPNC), int.Parse(datos[i].Faltas), int.Parse(datos[i].Presente), int.Parse(datos[i].UdeF), float.Parse(datos[i].Invitados), int.Parse(datos[i].RefDI), int.Parse(datos[i].RefDE), float.Parse(datos[i].UnoaUno));
            Todos.Add(currentAvatar);

            GameObject obj = new GameObject();

            Transform currentrans = obj.GetComponent<Transform>();

            objetivos.Add(currentrans);
            currentAvatar.setObjective(currentrans, true);
        }
        Reporte.Calcular();
        Reporte.ImprimirRG();
        OcultarDialogo();
    }

    void Update()
    {

    }

    public void MostrarDialogo(Vector3 avatarPos, string nombre, string param1, string param2, string param3)
    {
        MiiDisplay.SetBool("Show", true);
        DialogBox.transform.position = mainCam.WorldToScreenPoint(avatarPos);

        Name.text = "Nombre: " + nombre;
        Param1.text = param1;
        Param2.text = param2;
        Param3.text = param3;
    }

    public void OcultarDialogo()
    {
        MiiDisplay.SetBool("Show", false);
    }

    public void OrdenarPor(int opcion)
    {
        switch (opcion)
        {
            case 1: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Puntuacion).Reverse().ToList(); } break;
            case 2: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Faltas).Reverse().ToList(); } break;
            case 4: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Nombre).ToList(); } break;
            case 5: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.GNC).Reverse().ToList(); } break;
            case 6: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Invitados).Reverse().ToList(); } break;
            case 7: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Formaciones).Reverse().ToList(); } break;
            case 8: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefGE).Reverse().ToList(); } break;
            case 9: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Uno_a_Uno).Reverse().ToList(); } break;
            default: break;
        }

        setwayandobjectives();
    }


    public void ordenarPorGenero()
    {
        if (lastselected != 3)
        {
            lastselected = 3;
            Todos = Todos.OrderBy(a => a.mujer).Reverse().ToList();
            int conter = 0;
            nMujeres = 0;
            foreach (Avatar ar in Todos)
            {
                if (ar.mujer)
                {
                    nMujeres++;
                }
            }
            setWaypointsGender();
            foreach (Avatar ar in Todos)
            {
                ar.setObjective(objetivos[conter], false);
                conter++;
            }
        }
    }


    public void setwayandobjectives()
    {
        int conter = 0;
        setWaypoints();
        foreach (Avatar ar in Todos)
        {
            ar.setObjective(objetivos[conter], false);
            conter++;
        }
    }

    void setWaypoints()
    {
        int filas = 1, columnas = 1;

        if (NumeroAvatares < 10)
        {
            columnas = NumeroAvatares;
        }
        else
        {
            columnas = 10;
            filas = NumeroAvatares / 10;
            if (NumeroAvatares % 10 != 0)
            {
                filas++;
            }
        }

        //print("filas "+filas+" y columnas " + columnas);

        float separacionX = limitex / (columnas * .5f), separacionZ = limitez / (filas * 0.5f);
        float contx = -limitex, contz = -limitez;
        int k = 0;

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {

                contx += separacionX;
                objetivos[k].position = new Vector3(contx, 0.1f, contz);
                k++;
                if (k >= NumeroAvatares) return;
            }
            contx = -limitex;
            contz += separacionZ;
        }

    }

    void setWaypointsGender()
    {
        int l = 0, k = 0;
        int filas = 1, columnas = 1;

        if (NumeroAvatares - nMujeres < 10)
        {
            columnas = NumeroAvatares - nMujeres;
        }
        else
        {
            columnas = 10;
            filas = (NumeroAvatares - nMujeres) / 10;
            if (NumeroAvatares - nMujeres % 10 != 0)
            {
                filas++;
            }
        }

        float separacionX = limitex / (columnas), separacionZ = limitez / (filas * 0.5f);
        float contx = -limitex - 2.5f, contz = -limitez;

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                contx += separacionX;
                objetivos[k].position = new Vector3(contx, 0.1f, contz);
                k++;
                if (k >= NumeroAvatares - nMujeres) break;
            }
            if (k >= NumeroAvatares - nMujeres) break;
            contx = -limitex - 2.5f;
            contz += separacionZ;
        }

        filas = 1; columnas = 1;

        if (nMujeres < 10)
        {
            columnas = nMujeres;
        }
        else
        {
            columnas = 10;
            filas = (nMujeres) / 10;
            if (nMujeres % 10 != 0)
            {
                filas++;
            }
        }

        separacionX = limitex / (columnas); separacionZ = limitez / (filas * 0.5f);
        contx = 2.5f; contz = -limitez;

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                contx += separacionX;
                objetivos[k].position = new Vector3(contx, 0.1f, contz);
                k++;
                l++;
                if (l >= nMujeres) return;
            }
            contx = 2.5f;
            contz += separacionZ;
        }

    }

    public void ActivarBtnChange(bool activar)
    {
        btnCheckCharacter.SetActive(activar);
    }
    //=======Toggle======
    public void ToggleMenuMoreOptions(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}


