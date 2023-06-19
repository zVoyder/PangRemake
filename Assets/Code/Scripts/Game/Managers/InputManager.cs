namespace PangRemake.Managers
{
    using UnityEngine;

    public class InputManager : MonoBehaviour
    {
        public static Inputs s_Inputs;

        private void Awake()
        {
            if (s_Inputs == null)
            {
                s_Inputs = new Inputs();
            }
            s_Inputs.Enable();
        }
    }
}