using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatsViewer : MonoBehaviour
{
    public Text[] textstats;
    Avatar MiAvatar;

    Animator an;
    Transform trans;
    Collider coli;
    Vector3 Bounds;
    bool Air = true, gotAvatar=false;

    private void Start()
    {
        StartCoroutine(getAvatar());
    }

    private void Update()
    {
        if (Air && gotAvatar)
        {
            Debug.DrawLine(trans.position + Bounds, trans.position + Bounds + Vector3.down,Color.red);
            if (Physics.Raycast(trans.position + Bounds,Vector3.down,0.5f))
            {
                //Debug.Log("Aterrizó");
                an.SetTrigger("Land");
                Air = false;
            }
        }
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
            textstats[0].text = "Nombre:" + MiAvatar.Nombre /*+" "+ MiAvatar.Apellido*/;
            textstats[1].text = "RG:" + MiAvatar.RefGTotal;
            textstats[2].text = "RR:" + MiAvatar.RefRTotal;
            textstats[3].text = "Invitados:" + MiAvatar.Invitados;
            textstats[4].text = "1-a-1:" + MiAvatar.Uno_a_Uno;
            textstats[5].text = "UDF:" + MiAvatar.Formaciones;
            textstats[6].text = "GNC:" + MiAvatar.GNC;
            textstats[7].text = "P:" + MiAvatar.Presencias;
            textstats[8].text = "A:" + MiAvatar.Faltas;
            textstats[9].text = "L:" + MiAvatar.Tarde;
            textstats[10].text = "M:" + MiAvatar.Medica ;
            textstats[11].text = "S:" + MiAvatar.Sustituto;
            textstats[12].text = "Puntaje:" + MiAvatar.Puntuacion;
            gotAvatar = true;
            trans = MiAvatar.GetComponent<Transform>();
            coli = MiAvatar.GetComponent<Collider>();
            an = MiAvatar.GetComponent<Animator>();
                
            Bounds = new Vector3(0,coli.bounds.min.y-0.05f,0);
        }
    }
}
