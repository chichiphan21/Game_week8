
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    [Header("Popup")]
    public Canvas GameMenu;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Tránh mở popup nhiều lần
        if (hasTriggered)
            return;

        // Kiểm tra đối tượng có phải Player không
        if (!other.CompareTag("Player"))
            return;

        // Lấy script điều khiển máy bay
        AirplaneController airplane =
            other.GetComponentInParent<AirplaneController>();

        if (airplane == null)
            return;

        // Máy bay phải cất cánh trước
        if (!airplane.HasTakenOff)
            return;

        // Đã cất cánh và va chạm Wall
        hasTriggered = true;

        // Hiển thị Popup
        GameMenu.enabled = true;

        Debug.Log("Airplane reached Enter Wall!");
    }
}
