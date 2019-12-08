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
    public CinemachineDollyCart target;

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

        target.m_Position = (Vector3.Dot(playerPath, normalPath) / Mathf.Pow(normalPath.magnitude,2) + indexPath);
        myCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = target.m_Position - offsetDistanceCamera;
       // Debug.Log(Vector3.Dot(playerPath, normalPath) / Mathf.Pow(normalPath.magnitude, 2) + indexPath);

        if (myCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition >= indexPath + 1)
        {
            UpdateWaypoint();
        }else if(myCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition < indexPath && indexPath != 0)
        {
            indexPath--;
            waypointA = myPath.m_Waypoints[indexPath].position;
            waypointB = myPath.m_Waypoints[indexPath + 1].position;
        }
    }

    public void UpdateWaypoint()
    {
        indexPath++;
        waypointA = myPath.m_Waypoints[indexPath].position;
        waypointB = myPath.m_Waypoints[indexPath + 1].position;
    }
}
