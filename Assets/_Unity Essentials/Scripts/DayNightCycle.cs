using UnityEngine;

[ExecuteAlways]
public class DayNightCycle : MonoBehaviour
{
    [Tooltip("Length of one full day in real-time seconds")]
    public float dayLengthInSeconds = 120f;  // Default: 2 minutes per full day

    private void Update()
    {
        if (dayLengthInSeconds <= 0f) return;

        // Degrees to rotate per second (full rotation = 360°)
        float degreesPerSecond = 360f / dayLengthInSeconds;

        // Rotate around the X-axis (sunrise to sunset motion)
        transform.Rotate(Vector3.right, degreesPerSecond * Time.deltaTime, Space.World);
    }
}

