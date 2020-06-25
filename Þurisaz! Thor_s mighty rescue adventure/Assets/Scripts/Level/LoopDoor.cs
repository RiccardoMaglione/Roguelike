using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopDoor : MonoBehaviour
{
    public Renderer GraphicsDoor1;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor2;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor3;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor4;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor5;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor6;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor7;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor8;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor9;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor10;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor11;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor12;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor13;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor14;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor15;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor16;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor17;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Renderer GraphicsDoor18;                              //Instanzio la variabile renderer riferita alla graphics door corrispondente
    public Material[] MaterialChange = new Material[48];        //Instanzio un array di 48 elementi, cioè i materiali per creare il loop della porta
    int i = 0;                                                  //Instanzio la i uguale a 0
    Scene CurrentScene;
    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        StartCoroutine(Door());                                 //Faccio partire una coroutine
    }

    IEnumerator Door()              //if scena altrimenti non funziona
    {
        while (true)                                            //Mentre è vero
        {
            for (int i = 0; i < 48; i++)                        //Per un ciclo di 48 volte
            {
                if (CurrentScene.name == "FirstLevel")              //Se la scena corrente è First Level
                {
                    yield return new WaitForSeconds((float)0.1);    //Aspetto 0.1
                    GraphicsDoor1.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor2.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor3.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor4.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor5.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor6.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor7.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor8.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor9.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor10.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor11.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor12.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor13.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor14.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor15.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor16.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor17.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                    GraphicsDoor18.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                }
                //if (CurrentScene.name == "FirstLevelV2" )           //Se la scena corrente è FirstLevelV2
                //{
                //    yield return new WaitForSeconds((float)0.1);    //Aspetto 0.1
                //    GraphicsDoor1.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor2.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor3.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor4.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor5.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor6.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor7.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor8.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor9.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor10.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    //GraphicsDoor11.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //}
                //if (CurrentScene.name == "ThirdLevel")           //Se la scena corrente è FirstLevelV2
                //{
                //    yield return new WaitForSeconds((float)0.1);    //Aspetto 0.1
                //    GraphicsDoor1.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor2.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor3.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor4.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor5.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor6.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor7.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor8.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor9.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor10.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor11.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor12.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor13.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor14.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor15.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor16.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor17.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //    GraphicsDoor18.material = MaterialChange[i];     //Setto il nuovo materiale alla posizione i
                //}
                if (i>=48)                                      //Se i è maggiore o uguale a 48
                {
                    i = 0;                                      //Setto la i uguale a 0
                }
            }
        }
    }
}