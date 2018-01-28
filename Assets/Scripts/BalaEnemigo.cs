using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour {
    int direccion;
    float tiempo;
    Vector3 PosOriginal;
    // Use this for initialization
    void Start()
    {
        direccion = 8;
        tiempo = 0;
        PosOriginal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (direccion != 8)
        {
            tiempo += Time.deltaTime;
        }

        if (tiempo >= 20f)
        {
            direccion = 8;
            transform.position = PosOriginal;
            tiempo = 0;
        }
        if (direccion == 0)
        {
            transform.Translate(0, 0.1f, 0);
        }
        if (direccion == 1)
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (direccion == 2)
        {
            transform.Translate(0, -0.1f, 0);
        }
        if (direccion == 3)
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (direccion == 4)
        {
            transform.Translate(-0.1f, 0.1f, 0);
        }
        if (direccion == 5)
        {
            transform.Translate(-0.1f, -0.1f, 0);
        }
        if (direccion == 6)
        {
            transform.Translate(0.1f, -0.1f, 0);
        }
        if (direccion == 7)
        {
            transform.Translate(0.1f, 0.1f, 0);
        }
    }

    public void LLenarDirec(int direc)
    {
        direccion = direc;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().RestarVida();
            direccion = 8;
            transform.position = PosOriginal;
            tiempo = 0;
        }
        if (col.gameObject.CompareTag("DeathTriggers"))
        {
            //col.gameObject.GetComponent<Enemigo>().RestarVida();
            direccion = 8;
            transform.position = PosOriginal;
            tiempo = 0;
        }
    }
}
