using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;

public class GetJSON : MonoBehaviour
{
    public Manager miman;

    void Start()
    {
        StartCoroutine(Service());
    }

    IEnumerator Service()
    {
        /*List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));*/

        //UnityWebRequest www = UnityWebRequest.Get("http://desarrolloweb.socresanet.com.mx/mii_plaza/GetContent.php");
        UnityWebRequest www = UnityWebRequest.Get("http://desarrolloweb.socresanet.com.mx/mii_plaza/GetNewContent.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //Debug.Log(www.downloadHandler);
            List<JsonData> datos = JsonConvert.DeserializeObject<List<JsonData>>(www.downloadHandler.text);
            //miman.StartManager(datos);
            miman.StartManager2(datos);
        }
    }
}

public class JsonData
{
    /*
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
    public string UdeF { get; set; }*/
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

}