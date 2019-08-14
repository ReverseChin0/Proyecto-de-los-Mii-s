using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    public string Nombre;
    public Color MiColor;
    public int Edad;
    public float Peso, speed;
    public bool mujer=true;

    Transform objective;
    bool arrived=true, directed=false;

    Renderer mat;
    Rigidbody rig;
    Collider myColi;

    Vector3 rumbo;
    Vector3 direction;
    float distancia=0;
    const string glyphs = "abcdefghijklmnopqrstuvwxyz";

    void Start()
    {
        int nombrelength = Random.Range(3, 12);
        for (int i = 0; i < nombrelength; i++)
        {
            Nombre += glyphs[Random.Range(0, glyphs.Length)];
        }

        mujer = (Random.Range(0,2) == 0);
        MiColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        mat = transform.GetChild(1).GetComponent<Renderer>();
        mat.material.SetColor("_Color",MiColor);
        rig = GetComponent<Rigidbody>();
        myColi = GetComponent<Collider>();

        Edad = Random.Range(10, 100);
        Peso = Random.Range(50f, 100f);
    }

    void Update()
    {
        if (!arrived)
        {
            if (!directed)
            {
                directed = true;
                StartCoroutine(setDirection(0.25f));
            }

            if (rumbo.sqrMagnitude < 0.5f)
            {
                arrived = true;
                transform.position = new Vector3(objective.position.x, 0.01f, objective.position.z);
                myColi.isTrigger = true;
                rig.isKinematic = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!arrived)
        {
            rig.MovePosition(transform.position + direction * Time.deltaTime * speed);            
        }
    }

    IEnumerator setDirection(float time)
    {
        rumbo = objective.position - transform.position;
        rumbo.y = 0;
        distancia = rumbo.magnitude;
        direction = rumbo / distancia;

        yield return new WaitForSeconds(time);
        directed = false;
    }

    public void setObjective(Transform obj, bool arrive)
    {

        objective = obj;
        arrived = arrive;

        if (myColi != null)
        {
            myColi.isTrigger = false;
            rig.isKinematic = false;
        }
           
        if (!arrive)
        {
            rumbo = objective.position - transform.position;
            rumbo.y = 0;
            distancia = rumbo.magnitude;
            direction = rumbo / distancia;
        }
    }

    public void GotoObjective()
    {
        rig.isKinematic = false;
        arrived = false;
        myColi.isTrigger = false;

        rumbo = objective.position - transform.position;
        rumbo.y = 0;
        distancia = rumbo.magnitude;
        direction = rumbo / distancia;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Miis"))
        {
            rig.AddForce(new Vector3(Random.Range(-1.1f, 1.1f), 0, Random.Range(-1.1f, 1.1f)), ForceMode.Impulse);
        }
    }

 
}
