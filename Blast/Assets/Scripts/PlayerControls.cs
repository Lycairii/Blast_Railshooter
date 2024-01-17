using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed = 17f;
    [SerializeField] float xMin = 10f;
    [SerializeField] float xMax = 10f;
    [SerializeField] float yMin = -5f;
    [SerializeField] float yMax = 10f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float movePitchFactor = -10f;
    [SerializeField] float positionYawFactor = -1f;
    [SerializeField] float moveRollFactor = -10f;
    float xRawInput;
    float yRawInput;

    [SerializeField] InputAction playerInput;
    [SerializeField] InputAction playerFiring;
    [SerializeField] GameObject[] lasersArray;


    [SerializeField] InputAction playerForceField;
    [SerializeField] GameObject[] shieldArray;



    private void OnEnable()
    {
        playerInput.Enable();
        playerFiring.Enable();
        playerForceField.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerFiring.Disable();
        playerForceField.Disable();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();


    }



    private void ProcessTranslation()
    {
        xRawInput = playerInput.ReadValue<Vector2>().x;
        yRawInput = playerInput.ReadValue<Vector2>().y;

        float xRefinedInput = xRawInput * speed * Time.deltaTime;
        float newXPos = Mathf.Clamp(transform.localPosition.x + xRefinedInput, xMin, xMax);

        float yRefinedInput = yRawInput * speed * Time.deltaTime;
        float newYPos = Mathf.Clamp(transform.localPosition.y + yRefinedInput, yMin, yMax);

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y + positionPitchFactor) + (yRawInput * movePitchFactor);
        float yaw = transform.localPosition.x + positionYawFactor;
        float roll = xRawInput * moveRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    private void ProcessFiring()
    {
        if (playerFiring.ReadValue<float>() > 0.5)
        {
            ActivateLasers();
        }

        else
        {
            DeactivateLasers();
        }
    }

    private void ActivateLasers()
    {
        foreach (GameObject laser in lasersArray)
        {
            var eM = laser.GetComponent<ParticleSystem>().emission;
            eM.enabled = true;
        }
    }

    private void DeactivateLasers()
    {
        foreach (GameObject laser in lasersArray)
        {
            var eM = laser.GetComponent<ParticleSystem>().emission;
            eM.enabled = false;
        }
    }

    private void ProcessForceField()
    {
        if (!Input.GetKey(KeyCode.Space))
        { 
            ActivateForceField();
        }
        else
        {
            DeactivateForceField();
        }

    }

    private void ActivateForceField()
    {

        foreach (GameObject ForceField in shieldArray)
        {
            var eM = ForceField.GetComponent<MeshRenderer>();
            eM.enabled = true;
        }


    }

    private void DeactivateForceField()
    {
        foreach (GameObject ForceField in shieldArray)
        {
            var eM = ForceField.GetComponent<MeshRenderer>();
            eM.enabled = false;

        }
    }
}




