using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMitosis : MonoBehaviour {

    int direccion;
    float tiempoMov;
    Vector3 PosOriginal;
    [SerializeField]GameObject EnemigoPre;
    // Use this for initialization
    void Start()
    {
        direccion = 8;
        tiempoMov = Random.Range(4,8);
        PosOriginal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (direccion!=8) {
            tiempoMov -= Time.deltaTime;
        }
       
        if (tiempoMov <= 0)
        {
            direccion = 8;
            Instantiate(EnemigoPre, transform.position, Quaternion.identity);
            transform.position = PosOriginal;
            tiempoMov = Random.Range(4, 8); ;
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
        
        if (col.gameObject.CompareTag("Enemigo"))
        {
            direccion = 8;
            transform.position = PosOriginal;
            tiempoMov = Random.Range(4, 8); ;
        }
        if (col.gameObject.CompareTag("DeathTriggers"))
        {
            //Debug.Log("Ouch");
            direccion = 8;
            transform.position = PosOriginal;
            tiempoMov = Random.Range(4, 8); ;
        }

    }
}
