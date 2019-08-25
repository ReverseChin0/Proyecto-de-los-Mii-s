using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Avatar : MonoBehaviour
{
    [Header("Avatar Parameters")]
    public string Nombre;
    public Color MiColor;
    [Space(3f)]
    public int Puntuacion, Faltas, Presencias, Tarde, Medica, Sustituto, RefReci, Formaciones, Puntualidad;
    public float Invitados, RefGene, Uno_a_Uno;
    public double GNC;
    public bool mujer=true;
    
    Transform objective;
    bool arrived=true, directed=false, moving=false, primerRumbo=false;
    float startSpeed;

    Renderer mat;
    Rigidbody rig;
    Collider myColi;
    Animator Anim;

    Vector3 rumbo;
    Vector3 direction;
    float distancia=0, speed;
    const string glyphs = "abcdefghijklmnopqrstuvwxyz";

    void Start()
    {
        speed = 5;
        Puntuacion = Random.Range(0, 100);
        int nombrelength = Random.Range(3, 12);
        for (int i = 0; i < nombrelength; i++)
        {
            Nombre += glyphs[Random.Range(0, glyphs.Length)];
        }

        startSpeed = speed;
        mujer = (Random.Range(0,2) == 0);
        if (Puntuacion < 30)
        {
            MiColor = new Color(0, 0, 0);
        }
        else if (Puntuacion < 50)
        {
            MiColor = new Color(1f, 0, 0);
        }else if (Puntuacion < 70)
        {
            MiColor = new Color(1f, 1f, 0);
        }
        else
        {
            MiColor = new Color(0, 1f, 0);
        }
        mat = transform.GetChild(0).GetChild(1).GetComponent<Renderer>();
        mat.material.SetColor("_Color",MiColor);
        rig = GetComponent<Rigidbody>();
        myColi = GetComponent<Collider>();
        if(Anim==null)Anim = GetComponent<Animator>();

       
        Faltas = Random.Range(0,5);
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

            if (rumbo.sqrMagnitude <= 0.04f)
            {
                StopCoroutine(setDirection(0));
                arrived = true;
                Anim.SetBool("Moving", false);
                transform.position = new Vector3(objective.position.x, 0.01f, objective.position.z);
                setStatic(true);
                speed = startSpeed;
                transform.LookAt(transform.position+Vector3.back);
                primerRumbo = false;
            }
            else if(rumbo.sqrMagnitude < 0.8f)
            {
                speed = startSpeed * .15f;
            }
            else { speed = startSpeed; }
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
        if (!primerRumbo)
        {
            transform.LookAt(objective);
            primerRumbo = true;
            setStatic(false);
        }
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
        if (Anim==null) { Anim = GetComponent<Animator>(); }
        StartCoroutine(activaRun(!arrive));

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Miis"))
        {
            rig.AddForce(new Vector3(Random.Range(-1.1f, 1.1f), 0, Random.Range(-1.1f, 1.1f)), ForceMode.Impulse);
        }
    }

    public IEnumerator activaRun(bool moving)
    {
        float time = 0;
        if (moving) 
        {
            time=Random.Range(0f, 1.5f);
        }
        yield return new WaitForSeconds(time);
        if(!arrived)Anim.SetBool("Moving", moving);
    }

    public void setStatic(bool t)
    {
        myColi.isTrigger = t;
        rig.isKinematic = t;
    }
    /*public int CalculateAllScores()
    {
        Puntuacion = 0;
        //=======Absentismo=======
        if (Faltas == 2)
            Puntuacion += 5;
        else if (Faltas == 1)
            Puntuacion += 10;
        else if(Faltas<1)
            Puntuacion += 15;

        //=======Gracias por Negocio Cerrado======
        if (GNC >= 60000)
            Puntuacion += 15;
        else if (GNC >= 30000)
            Puntuacion += 10;
        else if (GNC >= 15000)
            Puntuacion += 5;

        //======Referencias por Semana======
        if (RefGene >= 1.20f)
            Puntuacion += 20;
        else if (RefGene >= 1.00f)
            Puntuacion += 15;
        else if (RefGene >= 0.75f)
            Puntuacion += 10;
        else if (RefGene >= 0.50f)
            Puntuacion += 5;

        //======Invitados por Semana======
        if (Invitados >= 0.500f)
            Puntuacion += 20;
        else if (Invitados >= 0.250f)
            Puntuacion += 15;
        else if (Invitados >= 0.167f)
            Puntuacion += 10;
        else if (Invitados >= 0.083f)
            Puntuacion += 5;

        //======Unos a Unos======
        if (Uno_a_Uno >= 0.75f)
            Puntuacion += 10;
        else if (Uno_a_Uno > 0)
            Puntuacion += 5;

        //======Puntualidad======
        if (Puntualidad == 0)
            Puntuacion += 5;

        //======Unidades de Formacion======
        if (Formaciones >= 3)
            Puntuacion += 15;
        else if (Formaciones == 2)
            Puntuacion += 10;
        else if (Puntuacion == 1)
            Puntuacion += 5;

        return Puntuacion;
    }*/
}
