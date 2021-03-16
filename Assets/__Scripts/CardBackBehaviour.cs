using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackBehaviour : MonoBehaviour
{
    // Variables
    public float seconds = 3f;

    // OnMouseClick
    void OnMouseDown()
    {
        // Turn off object
        gameObject.SetActive(false);
    } // OnMouseClick - END

}
