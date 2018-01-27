using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMov : MonoBehaviour {
    int direccion;
    float tiempo;
    Vector3 PosOriginal;
	// Use this for initialization
	void Start () {
        direccion = 5;
        tiempo = 0;
        PosOriginal = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (direccion != 5)
        {
            tiempo += Time.deltaTime;
        }
        
        if (tiempo >= 20f)
        {
            direccion = 5;
            transform.position = PosOriginal;
            tiempo = 0;
        }
        if (direccion == 0)
        {
            transform.Translate(0,0.4f,0);
        }
        if (direccion == 1)
        {
            transform.Translate(-0.4f, 0, 0);
        }
        if (direccion == 2)
        {
            transform.Translate(0, -0.4f, 0);
        }
        if (direccion == 3)
        {
            transform.Translate(0.4f, 0, 0);
        }
    }

    public void LLenarDirec(int direc)
    {
        direccion = direc;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemigo"))
        {
            col.gameObject.GetComponent<Enemigo>().RestarVida();
            direccion = 5;
            transform.position = PosOriginal;
            tiempo = 0;
        }
    }
}
