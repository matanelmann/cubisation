using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    private static List<GameSet> GsList;
    private void Awake()
    {
        GsList = new List<GameSet>();
        // Level 0 (Tutorial)
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 2f }, { "CUBE_ROOT_SCALE", 2.5f }, { "FORCE", 600f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "SCALE_DECREASE_RATE", 0.85f }, { "MESSY", 0 } }));
        // Level 1
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 3f }, { "CUBE_ROOT_SCALE", 2f }, { "FORCE", 600f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "SCALE_DECREASE_RATE", 0.8f }, { "MESSY", 0 } }));
        // Level 2
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 4f }, { "CUBE_ROOT_SCALE", 2f }, { "FORCE", 600f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "SCALE_DECREASE_RATE", 0.8f }, { "MESSY", 0 } }));
        // Level 3
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 6f }, { "CUBE_ROOT_SCALE", 2f }, { "FORCE", 600f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "SCALE_DECREASE_RATE", 0.85f }, { "MESSY", 0 } }));
        // Level 4
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 8f }, { "CUBE_ROOT_SCALE", 1.5f }, { "FORCE", 600f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "SCALE_DECREASE_RATE", 1f }, { "MESSY", 0 } }));
        // Level 5
        GsList.Add(new GameSet(new Dictionary<string, float>() { { "TOWER_HEIGHT", 10f }, { "CUBE_ROOT_SCALE", 1.5f }, { "FORCE", 600f }, { "GRAVITY", 4f }, { "MASS", 3f }, { "SCALE_DECREASE_RATE", 1f }, { "MESSY", 1 } }));
    }

    public static GameSet Get(int LevelNum)
    {
        if (LevelNum == 0)
        {
            return GsList[0];
        }
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
        public float MESSY;


        public GameSet(Dictionary<string, float> dict)
        {
            TOWER_HEIGHT = dict["TOWER_HEIGHT"];
            CUBE_ROOT_SCALE = dict["CUBE_ROOT_SCALE"];
            FORCE = dict["FORCE"];
            GRAVITY = dict["GRAVITY"];
            MASS = dict["MASS"];
            SCALE_DECREASE_RATE = dict["SCALE_DECREASE_RATE"];
            MESSY = dict["MESSY"];
        }


    }
}
