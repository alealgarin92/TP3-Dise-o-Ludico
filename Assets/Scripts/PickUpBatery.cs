using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBatery : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject linternaPlayer;
    [SerializeField] private SoundController sonidoBateria;

    [SerializeField] private float pickUpRadius;
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private float carga;
    [SerializeField] private GameObject pressF;

    private bool isInRange = false; // Controla si el jugador esta en el rango de interaccion.

    private void Update()
    {
        CheckLanternProximity();
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            BateryPickUp();
        }
    }
      
    private void CheckLanternProximity()
    {
        Collider[] collisions = UnityEngine.Physics.OverlapSphere(transform.position, pickUpRadius, collisionLayer);

        if (collisions.Length > 0)
        {
            if (!isInRange)
            {
                isInRange = true; // Marca que el jugador esta en el rango.
                pressF.SetActive(true); // Muestra "Press F".
            }
        }
        else if (isInRange)
        {
            isInRange = false; // Marca que el jugador salio del rango.
            pressF.SetActive(false); // Oculta "Press F".
        }
    }

    private void BateryPickUp()
    {
        GameManager.instance.AddCharge(carga);
        sonidoBateria.PlaySound2(); // Reproduce el sonido.
        pressF.SetActive(false); // Oculta "Press F".
        Destroy(gameObject); // Destruye la linterna.
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }
}
