using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Camera mainCam;
    public Animator MiiDisplay;
    public GameObject DialogBox;
    public Text Name, Age, Weight, Gender;
    [Header("Avatar Behaviour")]
    List<Avatar> Todos;
    List<Transform> objetivos;
    public GameObject miiAvatar;
    [Tooltip("Cuantos mii´s, habrá en la simulacion")]
    public int NumeroAvatares;
    int nMujeres=0;

    public float limitex=10, limitez=10;

    void Start()
    {
        Todos = new List<Avatar>();
        objetivos = new List<Transform>();

        for (int i=0; i < NumeroAvatares; i++) {
            GameObject go=Instantiate(miiAvatar, new Vector3(Random.Range(-10f,10f), 0, Random.Range(-10f, 10f)), Quaternion.identity);
            Avatar currentAvatar = go.GetComponent<Avatar>();
            Todos.Add(currentAvatar);

            GameObject obj = new GameObject();
            /*Instantiate(obj, transform.position, Quaternion.identity);*/
            Transform currentrans = obj.GetComponent<Transform>();
            //print(currentrans);
            objetivos.Add(currentrans);
            currentAvatar.setObjective(currentrans, true);

        }

        OcultarDialogo();
        setWaypoints();
    }

    void Update()
    {
       
    }

    public void MostrarDialogo(Vector3 avatarPos,string nombre, float edad, float peso, bool genero)
    {
        MiiDisplay.SetBool("Show",true);
        DialogBox.transform.position = mainCam.WorldToScreenPoint(avatarPos);

        Name.text = "Nombre: "+nombre;
        Age.text = "Edad: " + edad.ToString();
        Weight.text = "Peso: "+ peso.ToString();

        if (genero)
        {
            Gender.text = "Genero: Mujer";
        }
        else
        {
            Gender.text = "Genero: Hombre";
        }
    }

    public void OcultarDialogo()
    {
        MiiDisplay.SetBool("Show", false);
    }

    public void OrdenarPorEdad()
    {
        AvatarSortByEdad AvSortEdad = new AvatarSortByEdad();
        Todos.Sort(AvSortEdad);
        int conter=0;
        setWaypoints();
        foreach (Avatar ar in Todos)
        {
            ar.setObjective(objetivos[conter], false);
            conter++;
        }
    }

    public void OrdenarPorPeso()
    {
        AvatarSortByWeight AvSortPeso = new AvatarSortByWeight();
        Todos.Sort(AvSortPeso);
        int conter = 0;
        setWaypoints();
        foreach (Avatar ar in Todos)
        {
            ar.setObjective(objetivos[conter], false);
            conter++;
        }
    }

    public void ordenarPorGenero()
    {
        Todos = Todos.OrderBy(a => a.mujer).ToList();
        int conter = 0;
        
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

    public void ordenarPorNombre()
    {
        Todos = Todos.OrderBy(a => a.Nombre).ToList();
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
            columnas =  10;
            filas = NumeroAvatares / 10;
            if (NumeroAvatares % 10 != 0)
            {
                filas++;
            }
        }

        //print("filas "+filas+" y columnas " + columnas);

        float separacionX = limitex/(columnas*.5f), separacionZ = limitez/(filas*0.5f);
        float contx = -limitex,contz= -limitez;
        int k = 0;
        
        for(int i=0; i<filas; i++)
        {
            for(int j = 0; j < columnas; j++)
            {
                
                contx += separacionX;
                objetivos[k].position = new Vector3(contx,0.1f,contz);
                k++;
                if (k >= NumeroAvatares) return;
            }
            contx = -limitex;
            contz += separacionZ;
        }

    }

    void setWaypointsGender()
    {
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
        float contx = -limitex-2.5f, contz = -limitez;
        int k = 0;
        
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                contx += separacionX;
                objetivos[k].position = new Vector3(contx, 1, contz);
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
        int l = 0;
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

}

class AvatarSortByEdad : IComparer<Avatar>
{
    #region IComparer<Avatar> Members

    public int Compare(Avatar x, Avatar y)
    {
        if (x.Edad > y.Edad) return 1;
        else if (x.Edad < y.Edad) return -1;
        else return 0;
    }

    #endregion
}

class AvatarSortByWeight : IComparer<Avatar>
{
    #region IComparer<Avatar> Members

    public int Compare(Avatar x, Avatar y)
    {
        if (x.Peso > y.Peso) return 1;
        else if (x.Peso < y.Peso) return -1;
        else return 0;
    }

    #endregion
}
