using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraType
{
    FPS,
    TPS
}

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CameraType _cameraType;
    
    [Header("1��Ī")]
    private float rotationX,rotationY;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float mouseSpeed = 5f; // ���콺 ���� 

    [Header("3��Ī")]
    public Transform targetTransform;
    private Transform cameraTransform;

    [Range(2.0f, 20.0f)]
    public float distance = 10f;    // �Ÿ�

    [Range(0.0f, 10.0f)]
    public float height = 2.0f;     // ����

    public float moveDamping = 15f;     // �ӵ� ���
    public float rotateDamping = 10f;   // ȸ�� ���

    public float targetOffset = 2f;
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            CameraType cameraType = _cameraType == CameraType.FPS ? CameraType.TPS : CameraType.FPS;
            SetCamera(cameraType); 
        }
    }
    void LateUpdate()
    {
        switch (_cameraType)
        {
            case CameraType.FPS:
                FPS();
                break;
            case CameraType.TPS:
                TPS(); 
                break;
        }
    }

    public void SetCamera(CameraType cameraType)
    {
        _cameraType = cameraType;
    }
    private void FPS()
    {
        float y = Input.GetAxis("Mouse Y");

        rotationY = Mathf.Clamp(rotationY + y * mouseSpeed, -45, 90);

        transform.rotation = Quaternion.Euler(-rotationY, targetTransform.eulerAngles.y, 0);
        transform.position = playerTransform.position;
    }
    private void TPS()
    {
        float x = Input.GetAxis("Mouse X");

        rotationX += x * mouseSpeed;
        transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0);
        
        Vector3 pos = targetTransform.position
                     + (-targetTransform.forward * distance)
                     + (targetTransform.up * height);

        // ���� ���� : ���� -> Ÿ���� ��ġ
        cameraTransform.position = Vector3.Slerp(cameraTransform.position, pos, moveDamping * Time.deltaTime);

        // ���� ���� : ���� ȸ�� -> Ÿ���� ȸ�� 
        cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, targetTransform.rotation, rotateDamping * Time.deltaTime);

        cameraTransform.LookAt(targetTransform.position + (targetTransform.up * targetOffset));
    }
}
