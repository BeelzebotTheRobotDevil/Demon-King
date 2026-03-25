using Godot;


public partial class Enemy : CharacterBody2D
{
    public float EnemySpeed = 300.0f;
    public float graivty = 775f;


    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += new Vector2(0, graivty) * (float)delta;
        }

        if (IsOnWall())
        {
            EnemySpeed *= -1;
            velocity.X += EnemySpeed;
        }
        else
        {
            velocity.X = EnemySpeed;
        }



        Velocity = velocity;
        MoveAndSlide();
    }


}
