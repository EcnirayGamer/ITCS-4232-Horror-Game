using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject lightSource;
    public float maxEnergy;

    private bool flashlightEnable;
    private float currentEnergy;

    private int batteries;
    private GameObject batteryPickedUp;

    private void Start()
    {
        currentEnergy = maxEnergy;
        maxEnergy = 50 * batteries;
    }

    private void FixedUpdate()
    {
        maxEnergy = 50 * batteries;

        //turn on the flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlightEnable = !flashlightEnable;
            Debug.Log(flashlightEnable);
        }

        if (flashlightEnable)
        {
            flashlight.SetActive(true);
            currentEnergy -= 0.5f * Time.deltaTime;

            if (currentEnergy <= 0)
            {
                lightSource.SetActive(false);
            }
            if (currentEnergy > 0)
            {
                lightSource.SetActive(true);
            }
        }
        else
        {
            flashlight.SetActive(false);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.tag);
        if (hit.gameObject.tag == "Battery")
        {
            batteryPickedUp = hit.gameObject;
            batteries += 1;
            Destroy(batteryPickedUp);
        }
    }
}