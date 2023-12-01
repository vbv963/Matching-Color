using UnityEngine;

public class CubeSelector : MonoBehaviour
{
    private ObjectDetector objectDetector;

    private void Awake()
    {
        objectDetector = GetComponent<ObjectDetector>();

        // ���̾ "Touchable"�� ������Ʈ�� ���� �����ϵ��� ObjectDetector�� layerMask ����
        // ObjectDetector Ŭ������ rayCastEvent.Invoke(hit.transform);�� ȣ�� �� �� SelectCube ȣ��
        objectDetector.raycastEvent.AddListener(SelectCube);
    }

    public void  SelectCube(Transform hit)
    {
        // ���õ� ������Ʈ�� CubeController.ChangeColor()�� ȣ���� ť�� ���� ����
        hit.GetComponent<CubeController>().ChangeColor();
    }
}
