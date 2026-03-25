using Godot;
using System;

public partial class HealthBar : ProgressBar
{
   /** private Timer _timer;
    private ProgressBar _damageBar;

    private double _health;

    public double Health
    {
        get => _health;
        set
        {
            double previousHealth = _health;

            _health = Mathf.Min(MaxValue, value);
            Value = _health;

            if (_health <= 0)
            {
                QueueFree();
            }

            if (_health < previousHealth)
            {
                _timer.Start();
            }
            else
            {
                _damageBar.Value = _health;
            }
        }
    }

    public override void _Ready()
    {
        _timer = GetNode<Timer>("Timer");
        _damageBar = GetNode<ProgressBar>("%DamageBar");

        _timer.Timeout += OnTimerTimeout;
    }

    public void InitHealth(double health)
    {
        Health = health;

        MaxValue = health;
        Value = health;

        _damageBar.MaxValue = health;
        _damageBar.Value = health;
    }

    private void OnTimerTimeout()
    {
        _damageBar.Value = Health;
    }**/
}
