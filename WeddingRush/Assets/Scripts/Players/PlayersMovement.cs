using System;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    [SerializeField] private GameObject girlPlayer;
    [SerializeField] private GameObject boyPlayer;

    [SerializeField] private Transform boySideMovementRoot;
    [SerializeField] private Transform girlSideMovementRoot;

    [SerializeField] private Transform boyLeftLimit;
    [SerializeField] private Transform boyRightLimit;

    [SerializeField] private Transform girlLeftLimit;
    [SerializeField] private Transform girlRightLimit;

    private float speed => SettingsManager.GameSettings.playersSpeed;
    private float sideMovementSensitivity => SettingsManager.GameSettings.playersSideMovementSensitivity;


    private Vector2 inputDrag;

    private Vector2 previousMousePosition;

    private float boyLeftLimitX => boyLeftLimit.localPosition.x;
    private float boyRightLimitX => boyRightLimit.localPosition.x;

    private float girlLeftLimitX => girlLeftLimit.localPosition.x;
    private float girlRightLimitX => girlRightLimit.localPosition.x;

    private float forGirlZ;

    private void Awake()
    {
        DistanceFinder.closeDistance += ChangeGirlZPosition;
    }

    private void OnDestroy()
    {
        DistanceFinder.closeDistance -= ChangeGirlZPosition;
    }

    void Update()
    {
        ForwardMovement();
        HandleInput();
        SideMovement();
    }

    private void ForwardMovement()
    {
        BoyForwardMovement();
        GirlForwardMovement();
    }

    private void BoyForwardMovement()
    {
        boyPlayer.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void GirlForwardMovement()
    {
        girlPlayer.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void SideMovement()
    {
        BoySideMovement();
        GirlSideMovement();
    }

    private void BoySideMovement()
    {
        var localPosBoy = boySideMovementRoot.localPosition;
        localPosBoy += Vector3.right * inputDrag.x * sideMovementSensitivity;
        localPosBoy.x = Mathf.Clamp(localPosBoy.x, boyLeftLimitX, boyRightLimitX);
        boySideMovementRoot.localPosition = localPosBoy;
    }

    private void GirlSideMovement()
    {
        var localPosGirl = girlSideMovementRoot.localPosition;
        localPosGirl -= Vector3.right * inputDrag.x * sideMovementSensitivity;
        localPosGirl.x = Mathf.Clamp(localPosGirl.x, girlLeftLimitX, girlRightLimitX);
        girlSideMovementRoot.localPosition = localPosGirl;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            var deltaMouse = (Vector2) Input.mousePosition - previousMousePosition;
            inputDrag = deltaMouse;
            previousMousePosition = Input.mousePosition;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }

    private void ChangeGirlZPosition(float distanceX)
    {
        if (distanceX <= 0)
        {
            forGirlZ = -1.14f;
        }
        else
        {
            forGirlZ = 1.14f;
        }

        var difference = forGirlZ - distanceX;
        var girlLocal = girlSideMovementRoot.localPosition;
        var boyLocal = boySideMovementRoot.localPosition;
        var forLeftComeIncrease = boyLocal.z + difference;
        var forRightComeIncrease = boyLocal.z - difference;

        if (girlLocal.z < forGirlZ &&
            girlLocal.z < forLeftComeIncrease) // if she is at left side and wants to go right first come
        {
            girlLocal.z += 2f * Time.deltaTime;
        }
        else if (girlLocal.z > forGirlZ &&
                 girlLocal.z < forRightComeIncrease) // if she is at right side and wants to go left first come
        {
            girlLocal.z += 2f * Time.deltaTime;
        }
        else if
            (girlLocal.z >= boyLocal.z &&
             forGirlZ >= distanceX) //forLeftDecrease if she is goin right to left but if she is at ways center
        {
            girlLocal.z -= 2f * Time.deltaTime;
        }
        else if
            (girlLocal.z >= boyLocal.z &&
             forGirlZ <= distanceX) //forRightDecrease if she is goin left to right but if she is at ways center
        {
            girlLocal.z -= 2f * Time.deltaTime;
        }

        girlSideMovementRoot.localPosition = girlLocal;
    }
}