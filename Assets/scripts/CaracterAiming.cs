using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CaracterAiming : MonoBehaviour
{
    public GameObject AimCursore;
    public float turnSpeed = 15;
    public float aimDuration = 0.3f;
    public Rig aimLayer;


    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (aimLayer)
        {
            //if (Input.GetButton("Fire2"))
            //{
            //    aimLayer.weight += Time.deltaTime / aimDuration;
            //    AimCursore.SetActive(true);
            //}
            //else
            //{
            //    aimLayer.weight -= Time.deltaTime / aimDuration;
            //    AimCursore.SetActive(false);

            //}
            aimLayer.weight = 1.0f;
        }

        
    }
}
