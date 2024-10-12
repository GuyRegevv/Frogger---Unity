using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    private GameObject player;
    [SerializeField] private float intialYValue = 4f;
    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private PlayerController _playerController;
    private GameObject playerObject = null;

 
    public void SetPlayer(GameObject player)
    {
        playerObject = player;
        _playerController = playerObject.GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (playerObject != null)
        {
            var nextYpos = intialYValue - 2 + _playerController.UpwardProgress;
            if (nextYpos < 78)
            {
                Vector3 targetPosition = new Vector3(transform.position.x, nextYpos - 2 , transform.position.z);
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
        } 
    }
}