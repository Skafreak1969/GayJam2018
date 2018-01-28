using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    float tiempo = 0;
    float tiempoMitosis = 5f;
    int estado;
    BalaMitosis[] balasMitDisp;
    BalaEnemigo[] balasEnDisp;
    GameObject[] intermedio;
    int balaActualMit;
    int balaActualEn;
    int direcBala;
    int direcBalaEn;
    int vida;
    float tiempoAtaque;
    int contador;
    float repeticion;

    // Use this for initialization
    void Start () {
        contador = 0;
        repeticion = 0;
        vida = 100;
        balaActualMit = Random.Range(0,30);
        estado = 0;
        direcBala = 8;
        direcBalaEn = 8;
        tiempoAtaque = 5f;
        intermedio = GameObject.FindGameObjectsWithTag("BalaMitosis");
        balasMitDisp = new BalaMitosis[intermedio.Length];
        for (int i = 0; i < intermedio.Length; i++)
        {
            balasMitDisp[i] = intermedio[i].GetComponent<BalaMitosis>();
        }
        intermedio = GameObject.FindGameObjectsWithTag("BalaEnemigo");
        balasEnDisp = new BalaEnemigo[intermedio.Length];
        for (int i = 0; i < intermedio.Length; i++)
        {
            balasEnDisp[i] = intermedio[i].GetComponent<BalaEnemigo>();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (estado > 1)
        {
            tiempoAtaque -= Time.deltaTime;
        }

        if (tiempoAtaque<=0&&(estado>1&&estado<=4))
        {
            for (int i =0; i<8; i++)
            {
                direcBalaEn = i;
                balasEnDisp[balaActualEn].LLenarDirec(direcBalaEn);
                
                if (direcBalaEn == 0)
                {
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (estado + 2), transform.position.z);
                }
                if (direcBalaEn == 1)
                {
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x - (estado + 2), transform.position.y, transform.position.z);
                }
                if (direcBalaEn == 2)
                {
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - (estado + 2), transform.position.z);
                }
                if (direcBalaEn == 3)
                {
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x + (estado + 2), transform.position.y, transform.position.z);
                }
                
                if (direcBalaEn == 4)
                {
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x - (estado + 2), transform.position.y + (estado + 2), transform.position.z);
                }
                if (direcBalaEn == 5)
                {
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x - (estado + 2), transform.position.y - (estado + 2), transform.position.z);
                }
                if (direcBalaEn == 6)
                {
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x + (estado + 2), transform.position.y - (estado + 2), transform.position.z);
                }
                if (direcBalaEn == 7)
                {
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x + (estado + 2), transform.position.y + (estado + 2), transform.position.z);
                }
                
                balaActualEn++;
                if (balaActualEn >= balasEnDisp.Length)
                {
                    balaActualEn = 0;
                }
                
            }
            tiempoAtaque = 5f;
        }

        if (tiempoAtaque <= 0 && (estado > 4 && estado <= 6))
        {
            repeticion -= Time.deltaTime;
            direcBalaEn = contador;
            if (repeticion <= 0) {
                if (contador == 0)
                {
                    balasEnDisp[balaActualEn].LLenarDirec(0);
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (estado + 2), transform.position.z);
                }
                if (contador == 2)
                {
                    balasEnDisp[balaActualEn].LLenarDirec(1);
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x - (estado + 2), transform.position.y, transform.position.z);
                }
                if (contador == 4)
                {
                    balasEnDisp[balaActualEn].LLenarDirec(2);
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - (estado + 2), transform.position.z);
                }
                if (contador == 6)
                {
                    balasEnDisp[balaActualEn].LLenarDirec(3);
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x + (estado + 2), transform.position.y, transform.position.z);
                }

                if (contador == 1)
                {
                    balasEnDisp[balaActualEn].LLenarDirec(4);
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x - (estado + 2), transform.position.y + (estado + 2), transform.position.z);
                }
                if (contador == 3)
                {
                    balasEnDisp[balaActualEn].LLenarDirec(5);
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x - (estado + 2), transform.position.y - (estado + 2), transform.position.z);
                }
                if (contador == 5)
                {
                    balasEnDisp[balaActualEn].LLenarDirec(6);
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x + (estado + 2), transform.position.y - (estado + 2), transform.position.z);
                }
                if (contador == 7)
                {
                    balasEnDisp[balaActualEn].LLenarDirec(7);
                    balasEnDisp[balaActualEn].gameObject.transform.position = new Vector3(transform.position.x + (estado + 2), transform.position.y + (estado + 2), transform.position.z);
                }

                balaActualEn++;
                if (balaActualEn >= balasEnDisp.Length)
                {
                    balaActualEn = 0;
                }
                contador++;
                if (contador > 7)
                {
                    contador = 0;
                    tiempoAtaque = 5f;
                }
                repeticion = 0.2f; 
            }
            
        }

        tiempo += Time.deltaTime;
        tiempoMitosis -= Time.deltaTime;

        if (tiempoMitosis<=0)
        {
            //balasDisp[balaActual].gameObject.transform.position = transform.position;
            direcBala = Random.Range(0, 8);
            balasMitDisp[balaActualMit].LLenarDirec(direcBala);
            if (direcBala==0)
            {
                balasMitDisp[balaActualMit].gameObject.transform.position = new Vector3(transform.position.x,transform.position.y+(estado+1),transform.position.z);
            }
            if (direcBala == 1)
            {
                balasMitDisp[balaActualMit].gameObject.transform.position = new Vector3(transform.position.x-(estado+1), transform.position.y , transform.position.z);
            }
            if (direcBala == 2)
            {
                balasMitDisp[balaActualMit].gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - (estado+1), transform.position.z);
            }
            if (direcBala == 3)
            {
                balasMitDisp[balaActualMit].gameObject.transform.position = new Vector3(transform.position.x+(estado+1), transform.position.y, transform.position.z);
            }
            if (direcBala == 4)
            {
                balasMitDisp[balaActualMit].gameObject.transform.position = new Vector3(transform.position.x - (estado + 1), transform.position.y + (estado + 1), transform.position.z);
            }
            if (direcBala == 5)
            {
                balasMitDisp[balaActualMit].gameObject.transform.position = new Vector3(transform.position.x - (estado + 1), transform.position.y - (estado + 1), transform.position.z);
            }
            if (direcBala == 6)
            {
                balasMitDisp[balaActualMit].gameObject.transform.position = new Vector3(transform.position.x + (estado + 1), transform.position.y - (estado + 1), transform.position.z);
            }
            if (direcBala == 7)
            {
                balasMitDisp[balaActualMit].gameObject.transform.position = new Vector3(transform.position.x + (estado + 1), transform.position.y + (estado + 1), transform.position.z);
            }
            balaActualMit++;
            if (balaActualMit >= balasMitDisp.Length)
            {
                balaActualMit = Random.Range(0, 30);
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
            Destroy(gameObject);
        }
	}

    public void RestarVida()
    {
        vida -= 10;
        //Debug.Log(vida);
    }
}
