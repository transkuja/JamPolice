using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField]
    public CinemachineVirtualCamera myCamera;


    [SerializeField]
    public CinemachineSmoothPath myPath;

    [SerializeField]
    public CinemachineDollyCart LookAtCamera;

    [SerializeField]
    float offsetDistanceCamera;

    [SerializeField]
    float offsetDistanceLookAt;

    public Vector3 waypointA;
    public Vector3 waypointB;

    public int indexPath;

    private void Start()
    {
        indexPath = 0;
        waypointA = myPath.m_Waypoints[indexPath].position;
        waypointB = myPath.m_Waypoints[indexPath+1].position;
    }

    private void Update()
    {
        UpdateCameraPosition();
    }


    public void UpdateCameraPosition()
    {
        Vector3 normalPath = waypointB - waypointA;
        Vector3 playerPath = transform.position - waypointA;

        myCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = (Vector3.Dot(playerPath, normalPath)/ Mathf.Pow(normalPath.magnitude,2) + indexPath) - offsetDistanceCamera;

        if (myCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition >= indexPath + 1)
        {
            UpdateWaypoint();
        }
    }

    public void UpdateWaypoint()
    {
        indexPath++;
        waypointA = myPath.m_Waypoints[indexPath].position;
        waypointB = myPath.m_Waypoints[indexPath + 1].position;
    }
}
