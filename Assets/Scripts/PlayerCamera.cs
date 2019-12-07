using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField]
    public Cinemachine.CinemachineVirtualCamera myCamera;

    public Transform pts;

    private void Start()
    {
    }
    private void Update()
    {
        UpdateCameraPosition();
    }

    //Appeller ceci dans l'update déplcament du perso
    public void UpdateCameraPosition()
    {
        //m_PositionUnits = CinemachinePathBase.PositionUnits.Distance;

        myCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = transform.position.z-10.0f;

    }
}
