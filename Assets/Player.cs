using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //[SerializeField] GameObject Bala;
    BalaMov[] nuevaBala;
    GameObject[] intermedio;
    int direccion;
    int balaActual;
    float speedX = 10;
    float tiempoDisparos;
    float tiempoSaltos;
    bool movio = false;
    Vector3 moveVector;

	// Use this for initialization
	void Start () {
        tiempoDisparos = 0;
        direccion = 2;
        intermedio = GameObject.FindGameObjectsWithTag("Bala");
        nuevaBala = new BalaMov[intermedio.Length];
        for (int i=0; i < intermedio.Length; i++)
        {
            nuevaBala[i] = intermedio[i].GetComponent<BalaMov>();
        }
        balaActual = 0;
        moveVector = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (tiempoDisparos > 0)
        {
            tiempoDisparos -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W)&&moveVector==transform.position)
        {
            direccion = 0;
            //transform.Translate(new Vector3(0, 0.2f, 0));
            moveVector.y += 2;
        }
        if (Input.GetKeyDown(KeyCode.A) && moveVector == transform.position)
        {
            direccion = 1;
            //transform.Translate(new Vector3(-0.2f, 0, 0));
            moveVector.x -= 2;
        }
        if (Input.GetKeyDown(KeyCode.S) && moveVector == transform.position)
        {
            direccion = 2;
            //transform.Translate(new Vector3(0, -0.2f, 0));
            moveVector.y -= 2;
        }
        if (Input.GetKeyDown(KeyCode.D) && moveVector == transform.position)
        {
            direccion = 3;
            //transform.Translate(new Vector3(0.2f, 0, 0));
            moveVector.x += 2;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&tiempoDisparos<=0)
        {
            tiempoDisparos = 0.5f;
            //nuevaBala=Instantiate(Bala, this.transform.position, Quaternion.identity);
            nuevaBala[balaActual].gameObject.transform.position = transform.position;
            nuevaBala[balaActual].LLenarDirec(direccion);
            balaActual++;
            if (balaActual > 14)
            {
                balaActual = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveVector.x, moveVector.y, transform.position.z), Time.deltaTime * speedX);
    }
}
