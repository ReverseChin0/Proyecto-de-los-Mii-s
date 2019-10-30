using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class UpdateMail : MonoBehaviour
{
    public Text Nombre, newmail;
    string name, email;

    // Update is called once per frame
    public void updateMail()
    {
       name = Nombre.text;
       email = newmail.text;
       StartCoroutine(Service());
    }

    IEnumerator Service()
    {

        UnityWebRequest www;

        www = UnityWebRequest.Get("http://desarrolloweb.socresanet.com.mx/mii_plaza/UpdateMail.php?name="+ name +"&mail=" + email);

        Avatar[] misdudes=FindObjectsOfType<Avatar>();
        foreach(Avatar a in misdudes)
        {
            if (a.Nombre == name)
            {
                Debug.Log("encontre a " + a.Nombre);
                a.Correo = email;
            }
        }
        
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("todo al 100");
        }
    }
}
