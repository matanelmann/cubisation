using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube
{
    public GameObject gameObj;
    public Transform cubeTransform;
    public Type type;
    public float length;
    public float scale;
    public Rigidbody2D rb;
    public bool MouseOver;
    private float initial_Y;
    private float initial_X;
    private CubesController cc;
    public Cube prevCube;
    private SoundManager sound;
    public bool allowCollision = true;

    // Constructor
    public Cube(Transform cubeTransform, Type type, Vector3 position, Vector3 scale, CubesController cc, SoundManager sound)
    {
        this.cc = cc;
        this.type = type;
        this.cubeTransform = cubeTransform;
        this.cubeTransform.position = position;
        this.cubeTransform.localScale = scale;
        this.gameObj = cubeTransform.gameObject;
        this.scale = scale.x;
        this.length = scale.x * 5.12f;
        this.initial_Y = cubeTransform.position.y;
        this.initial_X = cubeTransform.position.x;
        this.rb = cubeTransform.gameObject.GetComponent<Rigidbody2D>();
        this.MouseOver = false;
        this.sound = sound;
        if (type == Type.Blue)
        {
            cubeTransform.gameObject.GetComponent<BlueCubeHandler>().cube = this;
        }
        adjustCubeSettings();
        if (type == Type.Red)
        {
            this.prevCube = cc.GetMainRed();
        }
    }
    private void adjustCubeSettings()
    {
        rb.gravityScale = Level.GetSettings().GRAVITY;
        rb.mass = Level.GetSettings().MASS;
    }
    public enum Type
    {
        Blue,
        Red
    }

    // Relevant for Blue cubes only
    public void OnCollision(Collision2D col)
    {
        if (isMain() && allowCollision && GameHandler.GetInstance().isGameActive())
        {
            if (!Level.GetInstance().TowerEmpty() && col.transform == cc.GetMainRed().cubeTransform)
            {
                sound.Clack();
                cc.StartPhaseCompletionTimer();
            }
        }
    }

    public void Push(float force)
    {
        rb.AddForce(Vector2.right * Level.GetSettings().FORCE * force);
    }

    public bool outOfBounds()
    {
        // If the cube is out of screen bounds
        return (cubeTransform.position.x > GameConfig.RIGHT_EDGE + this.length || cubeTransform.position.x < GameConfig.LEFT_EDGE - this.length);
    }

    public bool isMain()
    {
        return (this == cc.GetMainBlue());
    }

    public bool OffTower()
    {
        return (gameObj == null || cubeTransform.position.y < initial_Y - length || (cc.RedCubes.Count == 1 &&  this == cc.RedCubes[0] && cubeTransform.position.x > initial_X + length)); // If the cube fell down from the tower
    }
}
