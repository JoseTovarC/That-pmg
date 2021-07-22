using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public Slider sltime;
    public Vector3 direccion;
    public static Timeline instancetime;
    public Text gana_pierde;
    public Text warning;
    public Text spend_total;
    public GameObject chancebut; 
    public int aux = 0;
    public void setTime(float tiempo)
    {
        sltime.value = tiempo;
        Task.ActTask.estoyavanzando();
        
        if (tiempo >= 3 && tiempo <4 && !chancebut.activeSelf && aux==0)
        {
            chancebut.SetActive(true);
            aux = 1;
        }
        else if(tiempo>=4)
        {
            chancebut.SetActive(false);
           
        }

        if (tiempo >= sltime.maxValue || Task.ActTask.termina_todo())
        {
            condicion_victoria();
        }

    }

    public void condicion_victoria()
    {
        if (Task.ActTask.termina_todo() && Staff.presupuesto >= Task.ActTask.gasto_total())
        {
            gana_pierde.text = "Winner !";
            gana_pierde.color = Color.green;
            gana_pierde.fontStyle = FontStyle.Bold;
            foreach (var fondos_tarea in Task.ActTask.fondos)
            {
                fondos_tarea.color = Color.green;
                
            }
            
        }
        else if (!Task.ActTask.termina_todo())
        {
            gana_pierde.text = "Out of Time !";
            gana_pierde.color = Color.red;
            gana_pierde.fontStyle = FontStyle.Bold;
        }
        else
        {
            gana_pierde.text = "Over Budget !";
            gana_pierde.color = Color.red;
            gana_pierde.fontStyle = FontStyle.Bold;
        }

        Time.timeScale = 0;
    }
    
    private void Awake()
    {
        if (instancetime == null)
        {
            instancetime = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void setMaxTime(float aux,float puntoPartida)
    {
        sltime.value = puntoPartida;
        sltime.maxValue = aux;
        
    }
        // Start is called before the first frame update
    void Start()
    {
        chancebut.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
     direccion = sltime.fillRect.position;  
    }
}
