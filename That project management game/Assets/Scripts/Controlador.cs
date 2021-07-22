using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public Dropdown staff_0;
    public Dropdown staff_1;
    public Dropdown staff_2;
    public Dropdown staff_3;
    public Dropdown staff_4;
    public List<string> names = new List<string>();
    public Text text_task_1;
    public Text text_task_2;
    public Text text_task_3;
    public Text text_task_4;
    public Text text_task_5;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
        Staff empleados_act = new Staff();
        names.Add(Staff.empleados[0].getNombre());
        names.Add(Staff.empleados[1].getNombre());
        names.Add(Staff.empleados[2].getNombre());
        names.Add(Staff.empleados[3].getNombre());
        staff_0.AddOptions(names);
        staff_1.AddOptions(names);
        staff_2.AddOptions(names);
        staff_3.AddOptions(names);
        staff_4.AddOptions(names);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void staff0_IndexChanged(int index)
    {
        text_task_1.text = names[index];
        Task.ActTask.assingstaff[0] = Staff.empleados[index];
    }
    public void staff1_IndexChanged(int index)
    {
        text_task_2.text = names[index];
        Task.ActTask.assingstaff[1] = Staff.empleados[index];
    }
    public void staff2_IndexChanged(int index)
    {
        text_task_3.text = names[index];
        Task.ActTask.assingstaff[2] = Staff.empleados[index];
    }
    public void staff3_IndexChanged(int index)
    {
        text_task_4.text = names[index];
        Task.ActTask.assingstaff[3] = Staff.empleados[index];
    }
    public void staff4_IndexChanged(int index)
    {
        text_task_5.text = names[index];
        Task.ActTask.assingstaff[4] = Staff.empleados[index];
    }
    
}
