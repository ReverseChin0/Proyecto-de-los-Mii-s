using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    GameObject fader,Canvas,Prefab;

    public Avatar miAvatar;
    public Animator mianim;
    void Start()
    {
        DontDestroyOnLoad(fader);
        DontDestroyOnLoad(Canvas);
        DontDestroyOnLoad(this);
    }

    void LoadToScene(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    
    public void CambiarA_(string nombre)
    {
        if (nombre == "Stats")
        {
            StartCoroutine(FadetoSpawn(nombre));
        }
        else
        {
            StartCoroutine(Fadeto(nombre));
        }
       
    }

    public IEnumerator FadetoSpawn(string escena)
    {
        mianim.SetBool("Fade", true);
        yield return new WaitForSeconds(0.8f);
        LoadToScene(escena);
        yield return new WaitForSeconds(0.5f);
        mianim.SetBool("Fade", false);
        InstanciarAvatar();
    }

    public IEnumerator Fadeto(string escena)
    {
        mianim.SetBool("Fade", true);
        yield return new WaitForSeconds(0.8f);
        LoadToScene(escena);
        yield return new WaitForSeconds(0.5f);
        mianim.SetBool("Fade", false);
    }

    public void InstanciarAvatar()
    {
        Instantiate(Prefab, new Vector3(-1.5f,5,-6.5f), Quaternion.identity);
    }
}
