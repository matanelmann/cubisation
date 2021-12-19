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
    private CubesController cc;

    // Constructor
    public Cube(Transform cubeTransform, Type type, Vector3 position, Vector3 scale, CubesController cc)
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
        this.rb = cubeTransform.gameObject.GetComponent<Rigidbody2D>();
        this.MouseOver = false;
        if (type == Type.Blue)
        {
            cubeTransform.gameObject.GetComponent<BlueCubeHandler>().cube = this;
        }
        adjustCubeSettings();
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
        if (isMain() && GameHandler.GetInstance().isGameActive())
        {
            if (!Level.GetInstance().TowerEmpty() && col.transform == cc.GetMainRed().cubeTransform)
            {
                // SoundManager.playClack();
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
        return (gameObj == null || cubeTransform.position.y < initial_Y - length) ; // If the cube fell down from the tower
    }
}
