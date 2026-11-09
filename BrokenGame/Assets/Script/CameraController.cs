using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPoint = Vector3.zero;

    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetPoint.x = player.transform.position.x;
        targetPoint.y = player.transform.position.y;
        

        if (targetPoint.y < 0) // makes it so camera can't go below certain y level
        {
            targetPoint.y = 0;
        }

        transform.position = targetPoint;
    }
}
