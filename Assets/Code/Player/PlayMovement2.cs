using Godot;
using static Godot.GD;

public partial class PlayMovement2 : CharacterBody2D
{
    public const float Speed = 400.0f;
    public const float JumpVelocity = -525.5f;
    public int multJump = 1;
    public float graivty = 775f;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;



        // Add the gravity.
        if (!IsOnFloor() && !IsOnWall())
        {
            velocity += new Vector2(0, graivty) * (float)delta;
        }
        else if (IsOnWall())
        {
            velocity += new Vector2(0, graivty) * (float)delta;
        }



        // Handle Jump.
        if ((Input.IsActionJustPressed("ui_accept") || Input.IsActionJustPressed("up")) && IsOnFloor() && !IsOnWall())
        {
            velocity.Y = JumpVelocity;
        }
        //This allows for a double jump
        else if ((Input.IsActionJustPressed("ui_accept") || Input.IsActionJustPressed("up")) && !IsOnFloor() && !IsOnWall() && multJump == 1)
        {
            velocity.Y = JumpVelocity;
            multJump--;
        }
        //resets double jump when touching the floor
        else if (IsOnFloor())
        {
            multJump = 1;
        }




        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.

        Vector2 direction = Input.GetVector("left", "right", "up", "down");
        if (direction != Vector2.Zero && IsOnFloor())
        {
            velocity.X = direction.X * Speed;
            GetNode<AudioStreamPlayer2D>("WalkingSound").VolumeLinear = 1.5f;
        }
        //This makes it so that when you are in the air the walking sound is quieter
        else if (direction != Vector2.Zero && !IsOnFloor())
        {
            velocity.X = direction.X * Speed;
            GetNode<AudioStreamPlayer2D>("WalkingSound").VolumeLinear = 0;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            GetNode<AudioStreamPlayer2D>("WalkingSound").Play();
        }

        //This checks for collisions with the player and "kills" them
        for (int i = 0; i < GetSlideCollisionCount(); i++)
        {
            var collision = GetSlideCollision(i);
            if (((Node)collision.GetCollider()).Name == "Enemy")
            {
                GetNode("Player").Free();
            }
            if (((Node)collision.GetCollider()).Name == "Sign1")
            {
                Print("This is a sign");
            }
        }



        Velocity = velocity;
        MoveAndSlide();
    }



}
