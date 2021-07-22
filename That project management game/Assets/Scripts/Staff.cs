using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Staff : MonoBehaviour
{
   
    // caracteristicas staff
    string nombre;
    string color;
    public string ritmo;
    public string costo;
    public int cobra;
    public float demora;
    public int canttareas=1;
    public float deltaacum;

    // textos
    public Text recursostext;
    public Text names;
    public Text budget;
    public Text tareas_txt;
    
    // elementos de juego
    public static List<Staff> empleados;
    public static int presupuesto;
    public static Staff ActStaff;
    public float relentizador = 1;
    public string[] tareas_random =
    {
        "-Build the thingamabob",
        "-Test the gizmo",
        "-Retool the thingumajig",
        "-Calibrate the doohickey",
        "-Sample some widgets",
        "-Restart the thingy",
        "-Calibrate the contraption",
        "-Realign the doodad",
        "-Mobile whatchamacalli",
        "-Do that other thing"
    };
    
    private void Awake()
    {
        if (ActStaff == null)
        {
            ActStaff = this;
        }
        else
        {
            Destroy(gameObject);
        }
        List<Staff> aux = new List<Staff>();
        empleados = aux;
        Staff staff1 = new Staff("Vicky", "#1C00FF", "Average", "Average");
        Staff staff2 = new Staff("Bob", "#C3A51C", "Fast", "Expensive");
        Staff staff3 = new Staff("Jane", "#FF0064", "Slow", "Low - Cost");
        Staff staff4 = new Staff("Marti", "#F8FF00", "Slow", "Average");
        Staff staff5 = new Staff("Jim","#1BE706","Average","Average");
        Staff staff6 = new Staff("Kathy","#420606","Fast", "Average");
        Staff staff7 = new Staff("John","#FF0000", "Average", "Low - Cost");
        Staff staff8 = new Staff("Rudy","#20FF00","Slow","Expensive");
        Staff staff9 = new Staff("Mark","#000000", "Average", "Expensive");
        Staff staff10 = new Staff("Ann", "#B3FF00", "Average", "Average");
        empleados.Add(staff1);
        empleados.Add(staff2);
        empleados.Add(staff3);
        empleados.Add(staff4);
        empleados.Add(staff5);
        empleados.Add(staff6);
        empleados.Add(staff7);
        empleados.Add(staff8);
        empleados.Add(staff9);
        empleados.Add(staff10);
        empleados.Shuff(10); 
        
    }
    
    
    public Staff(string nom, string col, string rit, string cos)
    {
        this.nombre = nom;
        this.color = col;
        this.ritmo = rit;
        this.costo = cos;
        if (cos.Equals("Expensive"))
        {
            cobra = 540;
        }
        else if (cos.Equals("Average"))
        {
            cobra = 360;
        }
        else
        {
            cobra = 150;
        }
        
    }

    public void variavelocidad()
    {
        System.Random random = new System.Random();
        float minimo;
        float maximo;
        if (ritmo.Equals("Fast"))
        {
            minimo = 3f; 
            maximo = 5.6f;
            
        }
        else if(ritmo.Equals("Average"))
        {
            minimo = 4.5f;
            maximo = 7f;
        }
        else
        {
            minimo = 6f;
            maximo = 11f;
        }
        demora = (float) (random.NextDouble() * (maximo - minimo) + minimo) * relentizador;
        
    }
    public Staff()
    {
        
    }

     void Start()
    {
 
        recursostext.text = empleados[0].mostrar() + "\n" +  empleados[1].mostrar() + "\n" +  empleados[2].mostrar() + "\n" + empleados[3].mostrar();
        names.text = empleados[0].getNombre() + "\n" + empleados[1].getNombre() + "\n" + empleados[2].getNombre() + "\n" + empleados[3].getNombre();
        presupuesto = Random.Range(720, 999)*1000;
        budget.text = "Your budget: $"+ (presupuesto / 1000) + "," + "000";
        tareas_random.Shuff(10);
        tareas_txt.text = tareas_random[0] + "\n" + tareas_random[1] + "\n" + tareas_random[2] + "\n" +
                          tareas_random[3] + "\n" + tareas_random[4];
    }

    public string mostrar()
    {
        if (ritmo.Equals("Average") && costo.Equals("Average"))
        {
            return (nombre + " is Average ");
        }
        else if (ritmo.Equals("Average"))
        {
            return (nombre + " is " + costo);
        }
        else if (costo.Equals("Average"))
        {
            return (nombre + " is " + ritmo);
        }
        return (nombre + " is " + ritmo + " and " + costo);    
    }
    

    public string getNombre()
    {
        return this.nombre;
    }
    // Start is called before the first frame update
    public static List<Staff> mandame_lista()
    {
        return empleados;
    }


}
