using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMov : MonoBehaviour {
    int direccion;
    float tiempo;
    Vector3 PosOriginal;
	// Use this for initialization
	void Start () {
        tiempo = 0;
        PosOriginal = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        tiempo += Time.deltaTime ;
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
}
