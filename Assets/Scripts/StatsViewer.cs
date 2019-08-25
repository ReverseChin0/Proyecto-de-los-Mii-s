using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatsViewer : MonoBehaviour
{
    public Text[] textstats;
    public Avatar MiAvatar;

    private void Start()
    {
        StartCoroutine(getAvatar());
    }

    IEnumerator getAvatar()
    {
        yield return new WaitForSeconds(0.1f);
        MiAvatar = FindObjectOfType<Avatar>();
        setStats();
    }

    public void setStats()
    {
        if(MiAvatar != null)
        {
            textstats[0].text = "Nombre:" + MiAvatar.Nombre;
            textstats[1].text = "Faltas:" + MiAvatar.Faltas;
            textstats[2].text = "Presencias:" + MiAvatar.Presencias;
            textstats[3].text = "Tarde:" + MiAvatar.Tarde;
            textstats[4].text = "F.Medicas:" + MiAvatar.Medica;
            textstats[5].text = "Sustituto:" + MiAvatar.Sustituto;
            textstats[6].text = "Ref. Recibidas:" + MiAvatar.RefReci;
            textstats[7].text = "Formaciones:" + MiAvatar.Formaciones;
            textstats[8].text = "Puntualidad:" + MiAvatar.Puntualidad;
            textstats[9].text = "Invitados:" + MiAvatar.Invitados;
            textstats[10].text = "Ref. Generadas:" + MiAvatar.RefGene;
            textstats[11].text = "Unos a Unos:" + MiAvatar.Uno_a_Uno;
            textstats[12].text = "GPNC:" + MiAvatar.GNC;
            textstats[13].text = "Puntaje:" + MiAvatar.Puntuacion;
        }
    }
}
