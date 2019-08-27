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

        UnityWebRequest www = UnityWebRequest.Get("http://desarrolloweb.socresanet.com.mx/mii_plaza/GetContent.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //Debug.Log(www.downloadHandler);
            List<JsonData> datos = JsonConvert.DeserializeObject<List<JsonData>>(www.downloadHandler.text);
            miman.StartManager(datos);
        }
    }
}

public class JsonData
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