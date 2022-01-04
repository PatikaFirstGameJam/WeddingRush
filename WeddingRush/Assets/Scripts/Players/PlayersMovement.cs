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

    private void Awake()
    {
        DistanceFinder.closeDistance += IncreaseGirlZPosition;
        DistanceFinder.longDistance += DecreaseGirlZPosition;
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

    private void IncreaseGirlZPosition()
    {
        var girlLocal = girlSideMovementRoot.localPosition;
        var boyLocal = boySideMovementRoot.localPosition;
        transform.eulerAngles = new Vector3(1.5f, 0f, girlLocal.z);
        if (girlLocal.z < boyLocal.z + 1.14f)
        {
            girlLocal.z += 2f * Time.deltaTime;
        }

        girlSideMovementRoot.localPosition = girlLocal;
    }

    private void DecreaseGirlZPosition()
    {
        var girlLocal = girlSideMovementRoot.localPosition;
        var boyLocal = boySideMovementRoot.localPosition;
        transform.eulerAngles = new Vector3(girlLocal.x, 0f, girlLocal.z);
        if (girlLocal.z > boyLocal.z)
        {
            girlLocal.z -= 3f * Time.deltaTime;
        }

        girlSideMovementRoot.localPosition = girlLocal;
    }
}