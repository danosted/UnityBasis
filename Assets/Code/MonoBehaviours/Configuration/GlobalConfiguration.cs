namespace Assets.Code.MonoBehaviours.Configuration
{
    using Obstacles;
    using System.Collections.Generic;
    using UnityEngine;
    using UserInterface;

    public class GlobalConfiguration : MonoBehaviour
    {
        [Header("Moving Objects")]
        public MoveableObject prefab_moveable_object;
        [Header("UI")]
        public CanvasManager ui_game_canvas_manager;
        public CanvasManager ui_game_over_canvas_manager;
        [Header("Game Params")]
        public bool param_game_over;
    }
}
