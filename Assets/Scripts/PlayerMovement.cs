using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 플레이어 이동 속도
    public float moveSpeed = 5f;
    // 달리기 속도
    public float sprintSpeed = 10f;
    // 현재 이동 속도
    private float currentSpeed;

    // 마우스 감도
    public float mouseSensitivity = 100f;

    // 카메라와 캐릭터 회전에 필요한 값
    private float rotationX = 0f;

    // 캐릭터 컨트롤러 컴포넌트
    private CharacterController controller;

    void Start()
    {
        // 캐릭터 컨트롤러 컴포넌트 가져오기
        controller = GetComponent<CharacterController>();

        // 마우스 커서를 숨기고 고정시킴
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 기본 이동 속도 설정
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        HandleMovement(); // 이동 처리
        HandleMouseLook(); // 마우스를 통한 시점 조작
    }

    // WASD를 이용한 이동 처리 함수
    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical"); 

        // 쉬프트 키를 누를 때 달리기 속도로 변경
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed; // 달리기 속도
        }
        else
        {
            currentSpeed = moveSpeed; // 기본 속도
        }

        // 방향 벡터 생성
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // 이동 속도를 반영하여 이동 처리
        controller.Move(move * currentSpeed * Time.deltaTime);
    }

    // 마우스 입력을 이용한 시점 조작 함수
    void HandleMouseLook()
    {
        // 마우스 입력값 가져오기
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 카메라의 상하 회전을 위해 rotationX 값 변경
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // 상하 회전 제한

        // 플레이어와 카메라 회전 적용
        transform.Rotate(Vector3.up * mouseX); // 좌우 회전
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // 상하 회전
    }
}