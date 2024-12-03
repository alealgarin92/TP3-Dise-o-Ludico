using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float currentHealth;
    [SerializeField] private float currentBatery;


    //Quiero un evento que me indique cuando el jugador pierde vida


    public float GetCurrentBatery()
    {
        return currentBatery;
    }

    public void SetCurrentBatery(float cantidad)
    {
        currentBatery = cantidad;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(float cantidad)
    {
        currentHealth = cantidad;
    }

    //Metodos de linterna
    public void BateryLoss(float cantidad)
    {
        currentBatery -= cantidad * Time.deltaTime; ;
    }

    public void AddCharge(float cantidad)
    {
        currentBatery += cantidad;
    }

    //Metodos de vida
    public void IncreaseHealth(float amount)
    {
        currentHealth += amount;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
    }
    private void Awake()
    {
        //Si el game manager ya existe?? Entonces no tengo razon de ser, me destruyo.
        if (instance != null)
        {
            Destroy(gameObject); //Destruye el script, el monobehaviour pero no el gameobject
            return;
        }

        instance = this;

        //Decirle a Unity, que NO quiero que este objeto se destruya al cambiar de escena!!
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        currentBatery = 100;
        currentHealth = 100;
    }
}
