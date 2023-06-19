namespace PangRemake.DebugTools
{
    using UnityEngine;

    public class FPSLocker : MonoBehaviour
    {
        [SerializeField]
        private int _fps;

        [ContextMenu("Lock FPS")]
        private void LockFPS()
        {
            Application.targetFrameRate = _fps;
        }
    }
}