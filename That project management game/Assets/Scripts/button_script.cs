using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.SceneManagement;

public class button_script : MonoBehaviour
{
    public Timeline lineadetiempo;
    public Text botontext; //= "start";
    public float maxtime = 5.58f;
    public float actTime = 1f;
    public float prueba = 5.7f;
    public static button_script Actbutton;
    
    public void  ExitGame(){
        Application.Quit();
    }
    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void Awake()
    {
        if (Actbutton == null)
        {
            Actbutton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //lineadetiempo.setMaxTime(maxtime, actTime);
        Time.timeScale = 0;
    }
    public void avanzar()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            botontext.text = "Resume";
        }
        else
        {
            Time.timeScale = 1;
            lineadetiempo.setMaxTime(maxtime, actTime);
            botontext.text = "Pause";
        }
        
    }


    
    // Update is called once per frame
    void Update()
    {
        if (actTime < maxtime)
        {
            float puntodif = Time.deltaTime/prueba;
            actTime += puntodif;
            lineadetiempo.setTime(actTime);
        }
        else
        {
            Time.timeScale = maxtime;
        }
    }


}
