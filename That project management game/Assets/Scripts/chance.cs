using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class chance : MonoBehaviour
{
     public Text message;
     public GameObject chancebut;
     public static chance ActChance;
 
     private void Awake()
     {
         message.text = String.Join(" ", PhotonNetwork.CurrentRoom.PlayerCount);
         if (ActChance == null)
         {
             ActChance = this;
         }
         else
         {
             Destroy(gameObject);
         }
     }
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        message.text = String.Join(" ", PhotonNetwork.CurrentRoom.PlayerCount);
    }
    
    public void Oprimido()
    {
        button_script.Actbutton.avanzar();
        chancebut.SetActive(false);
        int randomIndex = Random.Range(0, 8);
        message.color= Color.black;
        if (randomIndex == 0)
        {
            int tasknum = Random.Range(0, 5);
            message.text = "You get some help from another Division. Task " + (tasknum+1) +" is complete and under budget";
            Task.ActTask.tareas[tasknum].value = Task.ActTask.tareas[tasknum].maxValue;
        }
        else if (randomIndex == 1)
        {
            int staffnum = Random.Range(0, 4);
            message.text = Staff.empleados[staffnum].getNombre() + " took a training class and now works faster!";
            if (Staff.empleados[staffnum].ritmo.Equals("Slow"))
            {
                Staff.empleados[staffnum].ritmo = "Average";
            }
            else if (Staff.empleados[staffnum].ritmo.Equals("Average"))
            {
                Staff.empleados[staffnum].ritmo = "Fast";
            }
        }
        else if (randomIndex == 2)
        {
            message.text = "Boss had a psychedelic vision. No wait, what did he say? Oh yeah... a vision statement.Time slows down.";
            button_script.Actbutton.prueba = 5.7f * 1.5f;
            foreach (var s in Staff.empleados)
            {
                s.relentizador = 1.5f;
            }
        }
        else if (randomIndex == 3)
        {
            int tasknum= Random.Range(0,5);
            message.text = "Breakthrough!, task " + (tasknum+1) + " has advanced";
            Task.ActTask.tareas[tasknum].value = Task.ActTask.tareas[tasknum].value + ((Task.ActTask.tareas[tasknum].maxValue-Task.ActTask.tareas[tasknum].minValue)*0.5f) ;
        }
        else if (randomIndex == 4)
        {
            int staffnum = Random.Range(0, 4);
            message.text =Staff.empleados[staffnum].getNombre() + " is not feeling well and now works slower.";
            if (Staff.empleados[staffnum].ritmo.Equals("Fast"))
            {
                Staff.empleados[staffnum].ritmo = "Average";
            }
            else if (Staff.empleados[staffnum].ritmo.Equals("Average"))
            {
                Staff.empleados[staffnum].ritmo = "Slow";
            }
        }
        else if (randomIndex == 5)
        {
            int tasknum = Random.Range(0, 5);
            message.text = "You have encountered a setback, task " + (tasknum+1) + " has fallen back.";
            Task.ActTask.tareas[tasknum].value = Task.ActTask.tareas[tasknum].value - ((Task.ActTask.tareas[tasknum].maxValue-Task.ActTask.tareas[tasknum].minValue)*0.3f) ;
        }
        else if (randomIndex == 6)
        {
            int staffnum = Random.Range(0, 4);
            message.text=  Staff.empleados[staffnum].getNombre() +" took a training class and now works cheaper!";
            if (Staff.empleados[staffnum].costo.Equals("Expensive"))
            {
                Staff.empleados[staffnum].costo = "Average";
            }
            else if (Staff.empleados[staffnum].costo.Equals("Average"))
            {
                Staff.empleados[staffnum].costo = "Low - Cost";
            }
        }
        else if (randomIndex == 7)
        {
            int staffnum = Random.Range(0, 4);
            message.text=  Staff.empleados[staffnum].getNombre() +" took a training class and now works more expensive!";
            if (Staff.empleados[staffnum].costo.Equals("Low - Cost"))
            {
                Staff.empleados[staffnum].costo = "Average";
            }
            else if (Staff.empleados[staffnum].costo.Equals("Average"))
            {
                Staff.empleados[staffnum].costo = "Expensive";
            }
        }
    }
}
