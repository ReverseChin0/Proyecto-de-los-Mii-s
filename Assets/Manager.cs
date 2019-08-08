using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    List<Avatar> Todos;
    List<Transform> objetivos;
    public GameObject miiAvatar;
    [Tooltip("Cuantos mii´s, habrá en la simulacion")]
    public int NumeroAvatares;

    public float limitex=10, limitez=10;

    void Start()
    {
        Todos = new List<Avatar>();
        objetivos = new List<Transform>();

        for (int i=0; i < NumeroAvatares; i++) {
            GameObject go=Instantiate(miiAvatar, new Vector3(Random.Range(-5f,5f), 0, Random.Range(-5, 5)), Quaternion.identity);
            Avatar currentAvatar = go.GetComponent<Avatar>();
            Todos.Add(currentAvatar);

            GameObject obj = new GameObject();
            /*Instantiate(obj, transform.position, Quaternion.identity);*/
            Transform currentrans = obj.GetComponent<Transform>();
            //print(currentrans);
            objetivos.Add(currentrans);
            currentAvatar.setObjective(currentrans, true);

        }

        setWaypoints();
    }

    void Update()
    {
       
    }

    public void OrdenarPorEdad()
    {
        AvatarSortByEdad AvSortEdad = new AvatarSortByEdad();
        Todos.Sort(AvSortEdad);
        int conter=0;
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
        foreach (Avatar ar in Todos)
        {
            ar.setObjective(objetivos[conter], false);
            conter++;
        }
    }

    void setWaypoints()
    {
        /*float espacioX = limitex*2;  //20
        float espacioZ = limitez*2; //20

        int filas = NumeroAvatares/10; //10

        if (filas == 0)
        {
            filas++;
        }

        float distanciaX = espacioX / filas;
        float distanciaZ = espacioZ / filas;

        float contX = 0, contZ = 0;
       
        foreach(Transform tr in objetivos)
        {
            print("contz"+contX);
            tr.position = new Vector3(-limitex+contX, 1, -limitez + contZ);
            contX += distanciaX; 
            if (contX >= espacioX)
            {
                contX = 0;
                contZ += distanciaZ;
            }

        }*/

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
                objetivos[k].position = new Vector3(contx,1,contz);
                k++;
                if (k >= NumeroAvatares) return;
            }
            contx = -limitex;
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