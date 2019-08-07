using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    public string Nombre;
    public Color MiColor;
    public int Edad;
    public float Peso, speed;

    Transform objective;
    bool arrived=true, directed=false;

    Renderer mat;
    Rigidbody rig;

    Vector3 direction;

    void Start()
    {
        MiColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        mat = transform.GetChild(1).GetComponent<Renderer>();
        speed = Random.Range(3f, 5f);
        mat.material.SetColor("_Color",MiColor);
        rig = GetComponent<Rigidbody>();

        Edad = Random.Range(10, 100);
        Peso = Random.Range(50f, 100f);

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!arrived)
        {
            rig.MovePosition(transform.position + direction * Time.deltaTime * speed);

            if (!directed) {
                directed = true;
                StartCoroutine(setDirection(0.3f));
            }

            float dist = Vector3.Distance(transform.position, objective.position);

            if (dist < 1.5f)
            {
                arrived = true;
            }
        }
    }

    IEnumerator setDirection(float time)
    {
        direction = objective.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        yield return new WaitForSeconds(time);
        directed = false;
    }

    public void setObjective(Transform obj, bool arrive)
    {
        objective = obj;
        arrived = arrive;
        if (!arrive)
        {
            direction = objective.position - transform.position;
            direction.y = 0;
            direction.Normalize();
        }
    }

    public void GotoObjective()
    {
        arrived = false;
        direction = objective.position - transform.position;
        direction.y = 0;
        direction.Normalize();
    }
}
