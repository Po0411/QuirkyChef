using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // �÷��̾� �̵� �ӵ�
    public float moveSpeed = 5f;
    // �޸��� �ӵ�
    public float sprintSpeed = 10f;
    // ���� �̵� �ӵ�
    private float currentSpeed;

    // ���콺 ����
    public float mouseSensitivity = 100f;

    // ī�޶�� ĳ���� ȸ���� �ʿ��� ��
    private float rotationX = 0f;

    // ĳ���� ��Ʈ�ѷ� ������Ʈ
    private CharacterController controller;

    void Start()
    {
        // ĳ���� ��Ʈ�ѷ� ������Ʈ ��������
        controller = GetComponent<CharacterController>();

        // ���콺 Ŀ���� ����� ������Ŵ
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // �⺻ �̵� �ӵ� ����
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        HandleMovement(); // �̵� ó��
        HandleMouseLook(); // ���콺�� ���� ���� ����
    }

    // WASD�� �̿��� �̵� ó�� �Լ�
    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical"); 

        // ����Ʈ Ű�� ���� �� �޸��� �ӵ��� ����
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed; // �޸��� �ӵ�
        }
        else
        {
            currentSpeed = moveSpeed; // �⺻ �ӵ�
        }

        // ���� ���� ����
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // �̵� �ӵ��� �ݿ��Ͽ� �̵� ó��
        controller.Move(move * currentSpeed * Time.deltaTime);
    }

    // ���콺 �Է��� �̿��� ���� ���� �Լ�
    void HandleMouseLook()
    {
        // ���콺 �Է°� ��������
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ī�޶��� ���� ȸ���� ���� rotationX �� ����
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // ���� ȸ�� ����

        // �÷��̾�� ī�޶� ȸ�� ����
        transform.Rotate(Vector3.up * mouseX); // �¿� ȸ��
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // ���� ȸ��
    }
}