using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    private static List<GameSet> GsList;
    private void Awake()
    {
        GsList = new List<GameSet>();
        // Level 0 (Toturial)
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 6f }, { "CUBE_ROOT_SCALE", 2f }, { "FORCE", 400f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "FRICTION", 0.1f }, { "BOUNCINESS", 0.3f }, { "SCALE_DECREASE_RATE", 0.9f } }));
        // Level 1
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 6f }, { "CUBE_ROOT_SCALE", 2f }, { "FORCE", 400f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "FRICTION", 0.1f }, { "BOUNCINESS", 0.3f }, { "SCALE_DECREASE_RATE", 0.9f } }));
        // Level 2
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 6f }, { "CUBE_ROOT_SCALE", 2f }, { "FORCE", 400f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "FRICTION", 0.1f }, { "BOUNCINESS", 0.3f }, { "SCALE_DECREASE_RATE", 0.9f } }));
        // Level 3
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 6f }, { "CUBE_ROOT_SCALE", 2f }, { "FORCE", 400f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "FRICTION", 0.1f }, { "BOUNCINESS", 0.3f }, { "SCALE_DECREASE_RATE", 0.9f } }));
        // Level 4
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 6f }, { "CUBE_ROOT_SCALE", 2f }, { "FORCE", 400f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "FRICTION", 0.1f }, { "BOUNCINESS", 0.3f }, { "SCALE_DECREASE_RATE", 0.9f } }));
    }

    public static GameSet Get(int LevelNum)
    {
        return GsList[LevelNum];
    }

    public class GameSet
    {
        public float TOWER_HEIGHT;
        public float SCALE_DECREASE_RATE;
        public float CUBE_ROOT_SCALE;
        public float FORCE;
        public float GRAVITY;
        public float MASS;
        public float FRICTION;
        public float BOUNCINESS;

        public GameSet(Dictionary<string, float> dict)
        {
            TOWER_HEIGHT = dict["TOWER_HEIGHT"];
            CUBE_ROOT_SCALE = dict["CUBE_ROOT_SCALE"];
            FORCE = dict["FORCE"];
            GRAVITY = dict["GRAVITY"];
            MASS = dict["MASS"];
            FRICTION = dict["FRICTION"];
            BOUNCINESS = dict["BOUNCINESS"];
            SCALE_DECREASE_RATE = dict["SCALE_DECREASE_RATE"];
        }
    }
}