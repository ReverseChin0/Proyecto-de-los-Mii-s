﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    GameObject fader,Canvas,Prefab,btnCheckCharacter;

    public Avatar miAvatar;
    public Animator mianim;
    void Start()
    {
        //DontDestroyOnLoad(fader);
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
        if(miAvatar != null)
            DontDestroyOnLoad(miAvatar);
        mianim.SetBool("Fade", true);
        yield return new WaitForSeconds(0.8f);
        LoadToScene(escena);
        yield return new WaitForSeconds(0.5f);
        mianim.SetBool("Fade", false);
        InstanciarAvatar();
        yield return new WaitForSeconds(0.5f);
        SceneManager.MoveGameObjectToScene(miAvatar.gameObject, SceneManager.GetActiveScene());
        Destroy(Canvas);
        Destroy(gameObject);
    }

    public IEnumerator Fadeto(string escena)
    {
        Destroy(miAvatar);
        mianim.SetBool("Fade", true);
        yield return new WaitForSeconds(0.8f);
        LoadToScene(escena);
        yield return new WaitForSeconds(0.5f);
        mianim.SetBool("Fade", false);
        yield return new WaitForSeconds(0.5f);
        Destroy(Canvas);
        Destroy(gameObject);
    }

    public void InstanciarAvatar()
    {
        miAvatar.gameObject.GetComponent<onMouseHover>().setHover(false);
        miAvatar.setStatic(false);
        Transform pos = miAvatar.gameObject.transform;
        pos.position = new Vector3(-2.5f, 5, -6.5f);
        pos.LookAt(pos.position + Vector3.back);
    }

}
