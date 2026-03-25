using Godot;

public partial class Sign : Area2D
{
    [Export] internal string signText = "This is a sign.";
    [Export] internal Label signLabel;
    internal bool showText = false;
    // Called when the node enters the scene tree for the first time.

    public override void _Process(double delta)
    {
        signLabel.Visible = showText;
        if (showText == true && Input.IsActionJustPressed("Interact"))
        {
            GD.Print(signText);
        }
    }


    //When the player enters the sign's area, the text will show up. When they exit, it will disappear.
    private void OnBodyEntered(Node2D body)
    {
        GD.Print(body.Name);
        GD.Print("Tau");

        if (body.Name == "Player")
        {
            showText = true;
        }
    }

    private void OnBodyExited(Node2D body)
    {
        GD.Print(body.Name);
        GD.Print("Exit");
        if (body.Name == "Player")
        {
            GD.Print("Player Exit");
            showText = false;
        }
    }


}
