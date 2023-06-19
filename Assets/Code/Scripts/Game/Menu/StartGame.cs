namespace PangRemake.Menu
{
    using UnityEngine;
    using VUDK.Generic.ShortActions;
    using PangRemake.Managers;
    using VUDK.Generic.Utility;

    [RequireComponent(typeof(SwitchScene))]
    public class StartGame : MonoBehaviour
    {
        private SwitchScene _sceneChanger;

        private void Awake()
        {
            TryGetComponent(out _sceneChanger);
        }

        private void OnEnable()
        {
            InputManager.s_Inputs.Menu.StartGame.started += SwitchScene;
        }

        private void OnDisable()
        {
            InputManager.s_Inputs.Menu.StartGame.started -= SwitchScene;
        }

        /// <summary>
        /// Switches scene via <see cref="VUDK.Generic.Utility.SwitchScene"/>.
        /// </summary>
        private void SwitchScene(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            _sceneChanger.ChangeScene(1);
        }
    }
}
