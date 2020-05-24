using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarItem : MonoBehaviour
{
    public Transform item;  //aqui será adicionado um objeto empty para marcar o local onde a arma deve ficar
    public bool equiped = false;


    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Arma" && equiped == false)  //se o player entrar dentro do colisor da arma e não estiver com nada equipado
        {
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true; //ativa o isKinematic do item
            col.gameObject.GetComponent<BoxCollider>().enabled = false; //desativa o colisor do item(BoxCollider neste caso)

            col.transform.position = item.position; //adiciona à arma a posição do gameObject empty que está onde a arma deve ficar
            col.transform.rotation = item.rotation; //da mesma maneira adiciona a rotação dele

            col.transform.SetParent(item);  //adiciona o item como filho do gameObject empty
            col.gameObject.tag = "Equipado";  //muda a tag pra Equipado
            equiped = true;

        }else if(col.gameObject.tag == "Arma" && equiped == true && Input.GetButton("E")) //se o player já tiver com uma arma equipada, e apertar E perto de outra
        {
 
            var itemEquip = gameObject;
            itemEquip = GameObject.FindWithTag("Equipado");

            var itemDesequip = Instantiate(itemEquip, transform.position, transform.rotation);
            itemDesequip.transform.Translate(1.9f, 0, 0);

            itemDesequip.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            itemDesequip.gameObject.GetComponent<BoxCollider>().enabled = false;
            itemDesequip.gameObject.tag = "Arma";
            Destroy(GameObject.FindWithTag("Equipado"));


            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;

            col.transform.position = item.position;
            col.transform.rotation = item.rotation;

            col.transform.SetParent(item);
            col.gameObject.tag = "Equipado";

        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && equiped == true)
        {
            var itemEquip = gameObject;
            itemEquip = GameObject.FindWithTag("Equipado");

            var itemDesequip = Instantiate(itemEquip, transform.position, transform.rotation);
            itemDesequip.transform.Translate(1.9f, 0, 0);


            itemDesequip.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            itemDesequip.gameObject.GetComponent<BoxCollider>().enabled = true;
            itemDesequip.gameObject.tag = "Arma";


            Destroy(GameObject.FindWithTag("Equipado"));
            equiped = false;
        }
    }
}
