﻿using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Camera mainCam;
    public Animator MiiDisplay;
    public GameObject DialogBox;// btnCheckCharacter, mailchanger;
    public Text Name, Param1, Param2, Param3, CorreoOrigi;
    public MiGrid migri;
    Selector miselect;

    [Header("Avatar Behaviour")]
    List<Avatar> Todos;
    List<Transform> objetivos;
    public GameObject miiAvatar1,miiAvatar2;
    [Tooltip("Cuantos mii´s, habrá en la simulacion")]
    public int lastselected = 0;//0=idlewalk,1=edad,2=peso,3=genero,,4=nombre,5=color;
    int NumeroAvatares, nMujeres = 0;
    [SerializeField]
    ReporteGeneral Reporte;

    public float limitex = 10, limitez = 10;

    void Start()
    {
        miselect = GetComponent<Selector>();
    }

    /*public void StartManager(List<JData> datos)
    {
        Todos = new List<Avatar>();
        objetivos = new List<Transform>();
        NumeroAvatares = datos.Count;
        for (int i = 0; i < datos.Count; i++)
        {
            GameObject prefab = miiAvatar1;
            if (Random.Range(0, 2) == 0)
            {
                prefab = miiAvatar2;
            }
            GameObject go = Instantiate(prefab, new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)), Quaternion.identity);
            Avatar currentAvatar = go.GetComponent<Avatar>();
            currentAvatar.InicializarAvatar(double.Parse(datos[i].GPNC), datos[i].Nombre, datos[i].Apellido, int.Parse(datos[i].Faltas), int.Parse(datos[i].Presente), int.Parse(datos[i].Tarde), int.Parse(datos[i].FaltasMedicas), int.Parse(datos[i].FaltasSustituidas), int.Parse(datos[i].RefRI), int.Parse(datos[i].RefRe), int.Parse(datos[i].UdeF), float.Parse(datos[i].Invitados), int.Parse(datos[i].RefDI), int.Parse(datos[i].RefDE), float.Parse(datos[i].UnoaUno));
            Reporte.addDatos(double.Parse(datos[i].GPNC), int.Parse(datos[i].Faltas), int.Parse(datos[i].Presente), int.Parse(datos[i].UdeF), float.Parse(datos[i].Invitados), int.Parse(datos[i].RefDI), int.Parse(datos[i].RefDE), float.Parse(datos[i].UnoaUno));
            Todos.Add(currentAvatar);

            go.name = "avatar_" + datos[i].Nombre;
            
            GameObject obj = new GameObject();

            Transform currentrans = obj.GetComponent<Transform>();

            objetivos.Add(currentrans);
            currentAvatar.setObjective(currentrans, true);
        }
        Reporte.Calcular();
        Reporte.ImprimirRG();
        OcultarDialogo();
        FindObjectOfType<SceneChanger>().beginMainScene();
    }*/

    public void StartManager2(List<JsonData> datos)
    {
        Todos = new List<Avatar>();
        objetivos = new List<Transform>();
        NumeroAvatares = datos.Count;
        for (int i = 0; i < datos.Count; i++)
        {
            GameObject prefab = miiAvatar1;
            if (datos[i].Mujer == "1")
            {
                prefab = miiAvatar2;
            }
            GameObject go = Instantiate(prefab, new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)), Quaternion.identity);
            Avatar currentAvatar = go.GetComponent<Avatar>();
            currentAvatar.Puntuacion = float.Parse(datos[i].Puntos);
            currentAvatar.Correo = datos[i].Correo;
            currentAvatar.InicializarAvatar(double.Parse(datos[i].GNC), datos[i].Miembro, datos[i].Miembro, int.Parse(datos[i].A), int.Parse(datos[i].P), int.Parse(datos[i].L), int.Parse(datos[i].M), int.Parse(datos[i].S), int.Parse(datos[i].RR), int.Parse(datos[i].RR), int.Parse(datos[i].UdeF), float.Parse(datos[i].invitados), int.Parse(datos[i].RG), int.Parse(datos[i].RG), float.Parse(datos[i].uau), datos[i].Mujer);
            Reporte.addDatos(double.Parse(datos[i].GNC), int.Parse(datos[i].A), int.Parse(datos[i].P), int.Parse(datos[i].UdeF), float.Parse(datos[i].invitados), int.Parse(datos[i].RG), int.Parse(datos[i].RG), float.Parse(datos[i].uau));
            Todos.Add(currentAvatar);

            go.name = "avatar_" + datos[i].Miembro.Substring(0, datos[i].Miembro.IndexOf(" ")); ;

            GameObject obj = new GameObject();

            Transform currentrans = obj.GetComponent<Transform>();

            objetivos.Add(currentrans);
            currentAvatar.setObjective(currentrans, true);
        }
        Reporte.Calcular();
        Reporte.ImprimirRG();
        OcultarDialogo();
        FindObjectOfType<SceneChanger>().beginMainScene();
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
            //derecho
            case 1: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Puntuacion).Reverse().ToList(); } break;
            case 2: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Faltas).Reverse().ToList(); } break;
            case 4: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Nombre).ToList(); } break;
            case 5: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.GNC).Reverse().ToList(); } break;
            case 6: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Invitados).Reverse().ToList(); } break;
            case 7: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Formaciones).Reverse().ToList(); } break;
            case 8: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefGTotal).Reverse().ToList(); } break;
            case 9: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Uno_a_Uno).Reverse().ToList(); } break;
            //reves
            case 10: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Puntuacion).ToList(); } break;
            case 11: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Faltas).ToList(); } break;
            case 12: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Nombre).Reverse().ToList(); } break;
            case 13: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.GNC).ToList(); } break;
            case 14: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Invitados).ToList(); } break;
            case 15: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Formaciones).ToList(); } break;
            case 16: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefGTotal).ToList(); } break;
            case 17: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.Uno_a_Uno).ToList(); } break;
            
                //Referencias Dadas/Recibidas
            case 18: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefGI).Reverse().ToList(); } break;
            case 19: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefGI).ToList(); } break;
            case 20: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefGE).Reverse().ToList(); } break;
            case 21: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefGE).ToList(); } break;

            case 22: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefRI).Reverse().ToList(); } break;
            case 23: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefRI).ToList(); } break;
            case 24: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefRE).Reverse().ToList(); } break;
            case 25: if (opcion != lastselected) { lastselected = opcion; Todos = Todos.OrderBy(a => a.RefRE).ToList(); } break;
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
     //GRID
    public void SetObjectivesWithGrid()
    {
        List<Avatar> negros = new List<Avatar>();
        List<Avatar> rojos = new List<Avatar>();
        List<Avatar> amarillos = new List<Avatar>();
        List<Avatar> verdes = new List<Avatar>();

        Todos = Todos.OrderBy(a => a.Puntuacion).ToList();
        foreach (Avatar a in Todos)
        {
            if (a.Puntuacion < 30)
            {
                negros.Add(a);
            }
            else if (a.Puntuacion < 50)
            {
                rojos.Add(a);
            }
            else if(a.Puntuacion < 70)
            {
                amarillos.Add(a);
            }
            else
            {
                verdes.Add(a);
            }
        }

        List<Vector3>posiciones = migri.OrdenarAvataresconGrid(negros, rojos, amarillos, verdes);

        int n = 0;
        foreach(Vector3 pos in posiciones)
        {
            objetivos[n].position = pos;
            n++;
        }

        int conter=0;
        foreach (Avatar ar in Todos)
        {
            ar.setWander(false);
            ar.setObjective(objetivos[conter], false);
            conter++;
        }
    }

    public void setwayandobjectives()
    {
        int conter = 0;
        setWaypoints();
        foreach (Avatar ar in Todos)
        {
            ar.setWander(false);
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

    /*public void ActivarBtnChange(bool activar, string avatrmail)
    {
        btnCheckCharacter.SetActive(activar);
        mailchanger.SetActive(activar);
        CorreoOrigi.text = avatrmail;
    }*/
    //=======Toggle======

    public void ToggleMenuMoreOptions(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }

    public void RomperFormacion()
    {
        foreach(Avatar av in Todos)
        {
            av.setWander(true);
        }
    }

    public void SelectionType(int _t, Avatar _av)
    {
        switch (_t)
        {
            case 0: miselect.AddtoSelected(_av); break;
            case 1: miselect.Select(_av); break;
            case 2: miselect.DeselectEverything(); break;
            default: miselect.DeselectEverything(); break;
        }
    }
}


