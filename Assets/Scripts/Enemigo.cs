using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    float tiempo = 0;
    float tiempoMitosis = 5f;
    int estado;
    BalaMitosis[] balasDisp;
    GameObject[] intermedio;
    int balaActual;
    int direcBala;
    int vida;

    // Use this for initialization
    void Start () {
        vida = 100;
        balaActual = Random.Range(0,30);
        estado = 0;
        direcBala = 8;
        intermedio = GameObject.FindGameObjectsWithTag("BalaMitosis");
        balasDisp = new BalaMitosis[intermedio.Length];
        for (int i = 0; i < intermedio.Length; i++)
        {
            balasDisp[i] = intermedio[i].GetComponent<BalaMitosis>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        tiempo += Time.deltaTime;
        tiempoMitosis -= Time.deltaTime;
        if (tiempoMitosis<=0)
        {
            //balasDisp[balaActual].gameObject.transform.position = transform.position;
            direcBala = Random.Range(0, 8);
            balasDisp[balaActual].LLenarDirec(direcBala);
            if (direcBala==0)
            {
                balasDisp[balaActual].gameObject.transform.position = new Vector3(transform.position.x,transform.position.y+(estado+1),transform.position.z);
            }
            if (direcBala == 1)
            {
                balasDisp[balaActual].gameObject.transform.position = new Vector3(transform.position.x-(estado+1), transform.position.y , transform.position.z);
            }
            if (direcBala == 2)
            {
                balasDisp[balaActual].gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - (estado+1), transform.position.z);
            }
            if (direcBala == 3)
            {
                balasDisp[balaActual].gameObject.transform.position = new Vector3(transform.position.x+(estado+1), transform.position.y, transform.position.z);
            }
            if (direcBala == 4)
            {
                balasDisp[balaActual].gameObject.transform.position = new Vector3(transform.position.x + (estado - 1), transform.position.y + (estado + 1), transform.position.z);
            }
            if (direcBala == 5)
            {
                balasDisp[balaActual].gameObject.transform.position = new Vector3(transform.position.x + (estado - 1), transform.position.y + (estado - 1), transform.position.z);
            }
            if (direcBala == 6)
            {
                balasDisp[balaActual].gameObject.transform.position = new Vector3(transform.position.x + (estado + 1), transform.position.y + (estado - 1), transform.position.z);
            }
            if (direcBala == 7)
            {
                balasDisp[balaActual].gameObject.transform.position = new Vector3(transform.position.x + (estado + 1), transform.position.y + (estado + 1), transform.position.z);
            }
            balaActual++;
            if (balaActual >= balasDisp.Length)
            {
                balaActual = Random.Range(0, 30);
            }
            tiempoMitosis = 5f;
        }
        if (tiempo >= 6&& estado<6)
        {
            estado++;
            vida += 50;
            transform.localScale = new Vector3(transform.localScale.x+10, transform.localScale.y + 10, 1);
            tiempo = 0;
        }

        if (vida <= 0)
        {
            Destroy(this);
        }
	}

    public void RestarVida()
    {
        vida -= 10;
        Debug.Log(vida);
    }
}
