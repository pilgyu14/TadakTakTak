using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
#if UNITY_EDITOR
    public Color gizmoColor = Color.yellow;
    public float radius = 0.1f;

    private void OnDrawGizmos()
    {
        // ���� ����
        Gizmos.color = gizmoColor;

        // ��ü ����� ����
        Gizmos.DrawSphere(transform.position, radius);
    }
#endif
}
