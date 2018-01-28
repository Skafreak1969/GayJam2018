using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //[SerializeField] GameObject Bala;
    BalaMov[] nuevaBala;
    GameObject[] intermedio;
    private Animator player;
    int direccion;
    int balaActual;
    float speedX = 10;
    float tiempoDisparos;
    Vector3 moveVector;
    int vida;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<Animator>();
        vida = 10;
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
	
    public void RestarVida()
    {
        vida -= 1;
    }

	// Update is called once per frame
	void Update () {
        if (tiempoDisparos > 0)
        {
            tiempoDisparos -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W)&&moveVector==transform.position)
        {
            player.SetInteger("State", 1);
            direccion = 0;
            //transform.Translate(new Vector3(0, 0.2f, 0));
            moveVector.y += 2;
        }
        if (Input.GetKeyDown(KeyCode.A) && moveVector == transform.position)
        {
            player.SetInteger("State", 3);
            direccion = 1;
            //transform.Translate(new Vector3(-0.2f, 0, 0));
            moveVector.x -= 2;
        }
        if (Input.GetKeyDown(KeyCode.S) && moveVector == transform.position)
        {
            player.SetInteger("State", 2);
            direccion = 2;
            //transform.Translate(new Vector3(0, -0.2f, 0));
            moveVector.y -= 2;
        }
        if (Input.GetKeyDown(KeyCode.D) && moveVector == transform.position)
        {
            player.SetInteger("State", 4);
            direccion = 3;
            //transform.Translate(new Vector3(0.2f, 0, 0));
            moveVector.x += 2;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&tiempoDisparos<=0)
        {
            tiempoDisparos = 0.3f;
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
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
