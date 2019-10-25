using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelsTest : MonoBehaviour
{
    public List<GameObject> Cabezas, Pelos, narices;
    public Transform cabeSpot, PeloSpot, narizSpot, Parent;
    int nCabe, nPelo, nNar, indiceCabe = 0,indicePelo = 0, indiceNariz = 0;
    GameObject currentC, currentP, currentN;
    void Start()
    {
        nCabe = Cabezas.Count;
        nPelo = Pelos.Count;
        nNar = narices.Count;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            indicePelo--;
            if (indicePelo < 0)
                indicePelo = nPelo-1;
            CambiarPelo();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            indicePelo++;
            if (indicePelo >= nPelo)
                indicePelo = 0;
            CambiarPelo();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            indiceCabe--;
            if (indiceCabe < 0)
                indiceCabe = nCabe-1;
            CambiarCabeza();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            indiceCabe++;
            if (indiceCabe >= nCabe)
                indiceCabe = 0;
            CambiarCabeza();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            indiceNariz--;
            if (indiceNariz < 0)
                indiceNariz = nNar-1;
            CambiarNariz();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            indiceNariz++;
            if (indiceNariz >= nNar)
                indiceNariz = 0;
            CambiarNariz();
        }
    }

    public void CambiarPelo()
    {
        Destroy(currentP);
        currentP = Instantiate(Pelos[indicePelo], PeloSpot.position, PeloSpot.rotation, Parent);
    }

    public void CambiarCabeza()
    {
        Destroy(currentC);
        currentC = Instantiate(Cabezas[indiceCabe], cabeSpot.position, cabeSpot.rotation, Parent);
    }

    public void CambiarNariz()
    {
        Destroy(currentN);
        currentN = Instantiate(narices[indiceNariz], narizSpot.position, narizSpot.rotation, Parent);
    }
}
