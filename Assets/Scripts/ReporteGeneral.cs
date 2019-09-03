using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReporteGeneral : MonoBehaviour
{
    int asistencia = 0, faltas = 0, formacion = 0, nuevosMiembros = 0, Nmiembros = 0, referencias = 0;
    float unoauno = 0, invitados = 0, porcentajeasi = 0;
    double GNC = 0;

    public Text[] textosCapitulo;
    void Start()
    {

    }

    void Update()
    {

    }

    public void addDatos(double GPNC, int Faltas, int Presente, int UdeF, float Invitados, int RefDI, int RefDE, float UnoaUno)
    {
        GNC += GPNC;
        faltas += Faltas;
        asistencia += Presente;
        formacion += UdeF;
        invitados += Invitados;
        referencias += RefDE;
        referencias += RefDI;
        unoauno += UnoaUno;
        Nmiembros++;
    }

    public void Calcular()
    {
        float todas = asistencia + faltas;

        porcentajeasi = asistencia * 100 / todas;
    }

    public void ImprimirRG()
    {
        Debug.Log("Asistencia: " + porcentajeasi + "%, 1-a-1´s: " + unoauno + ", Formacion: " + formacion + ", invitados: " + invitados);
        Debug.Log("NMiembros: " + nuevosMiembros + ", # de Miembros: " + Nmiembros + ",Referencias: " + referencias + ",GNC: " + GNC);

        textosCapitulo[0].text = "Asistencia: " + porcentajeasi + "%";
        textosCapitulo[1].text = "1 - a - 1´s: " + unoauno;
        textosCapitulo[2].text = "Formacion: " + formacion;
        textosCapitulo[3].text = "invitados: " + invitados;
        textosCapitulo[4].text = "Nuevos Miembros: " + nuevosMiembros;
        textosCapitulo[5].text = "# de Miembros: " + Nmiembros;
        textosCapitulo[6].text = "Referencias: " + referencias;
        textosCapitulo[7].text = "GNC: " + GNC;

    }

    public void HideObject(GameObject miobj){
        miobj.SetActive(!miobj.activeSelf);
    }
}
