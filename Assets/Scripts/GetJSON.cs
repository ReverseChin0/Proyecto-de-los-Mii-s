using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class GetJSON : MonoBehaviour
{
    public Manager miman;
    //public SceneChanger sChanger;
    //public int tipoexcel = 2;

    void Start()
    {
        StartCoroutine(Service());
    }

    IEnumerator Service()
    {

        UnityWebRequest www;
    
            
          www = UnityWebRequest.Get("http://desarrolloweb.socresanet.com.mx/mii_plaza/GetNewContent.php");
     

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            List<JsonData> datos2 = JsonConvert.DeserializeObject<List<JsonData>>(www.downloadHandler.text);
            miman.StartManager2(datos2);

        }
    }

   /* public void setearExcel(Text mitets)
    {
        tipoexcel = int.Parse(mitets.text);
    }*/

}


public class JsonData
{
    public string Miembro { get; set; }
    public string RG { get; set; }
    public string RR { get; set; }
    public string invitados { get; set; }
    public string uau { get; set; }
    public string UdeF { get; set; }
    public string GNC { get; set; }
    public string Puntos { get; set; }
    public string DiasEnBNI { get; set; }
    public string P { get; set; }
    public string A { get; set; }
    public string L { get; set; }
    public string M { get; set; }
    public string S { get; set; }
    public string Correo { get; set; }
    public string Mujer { get; set; }
}

public class JData
{
   public string IDAvatar { get; set; }
   public string Nombre { get; set; }
   public string Apellido { get; set; }
   public string Presente { get; set; }
   public string Faltas { get; set; }
   public string Tarde { get; set; }
   public string FaltasMedicas { get; set; }
   public string FaltasSustituidas { get; set; }
   public string RefDI { get; set; }
   public string RefDE { get; set; }
   public string RefRI { get; set; }
   public string RefRe { get; set; }
   public string Invitados { get; set; }
   public string UnoaUno { get; set; }
   public string GPNC { get; set; }
   public string UdeF { get; set; }
   
}