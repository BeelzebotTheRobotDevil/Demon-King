using Godot;

public partial class TheTextBox : CanvasLayer
{
    //Hides the Text Box
    [Export] internal MarginContainer textBoxContainer;
    [Export] internal Label textBoxLabel;
    [Export] internal float textSpeedRead;
    private string textBoxText = "This is a text box. This also have lot of things to say.";
    private string currentState = TextBoxState.Ready.ToString();
    //internal Tween tween;




    //private bool isTweening = true;





    enum TextBoxState
    {
        Ready,
        Displaying,
        Ended
    }

    public override void _Process(double delta)
    {

        switch (currentState)
        {
            case "Ready":
                if (Input.IsActionJustPressed("Interact"))
                {
                    AddText(textBoxText);
                }
                break;
            case "Displaying":
                //If this is pressed, it will skip the text animation and display the full text immediately.
                if (Input.IsActionJustPressed("Interact") || Input.IsActionJustPressed("ui_accept"))
                {
                    //textBoxLabel.VisibleCharacters = textBoxText.Length;
                    //isTweening = false;
                    Tween tween = GetTree().CreateTween();
                    tween.TweenProperty(textBoxLabel, "visible_characters", textBoxText.Length, 0.0);
                    ChangeState(TextBoxState.Ended);
                }
                break;
            case "Ended":
                if (Input.IsActionJustPressed("Interact") || Input.IsActionJustPressed("ui_accept"))
                {
                    HideTextBox();
                    ChangeState(TextBoxState.Ready);
                }
                break;
        }
    }

    public override void _Ready()
    {
        HideTextBox();
        AddText(textBoxText);
    }

    //Adds text to the Text Box
    private void AddText(string textBoxText)
    {
        textBoxLabel.Text = textBoxText;
        ChangeState(TextBoxState.Displaying);
        ShowTextBox();
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(textBoxLabel, "visible_characters", textBoxText.Length, textBoxText.Length * textSpeedRead).From(0.0);
        tween.Finished += OnTweenFinshed;


    }

    private void OnTweenFinshed()
    {
        ChangeState(TextBoxState.Ended);
    }

    private void HideTextBox()
    {
        textBoxLabel.Text = "";
        textBoxContainer.Visible = false;
    }
    private void ShowTextBox()
    {
        textBoxContainer.Visible = true;


    }
    //This changes the current state of the Text Box. It can be used to determine if the Text Box is ready to display new text, if it is currently displaying text, or if it has finished displaying text.
    private void ChangeState(TextBoxState newState)
    {
        currentState = newState.ToString();
        switch (currentState)
        {
            case "Ready":
                GD.Print("Chaning State to: " + TextBoxState.Ready.ToString());
                break;
            case "Displaying":
                GD.Print("Chaning State to: " + TextBoxState.Displaying.ToString());
                break;
            case "Ended":
                GD.Print("Chaning State to: " + TextBoxState.Ended.ToString());
                break;
        }
    }
}