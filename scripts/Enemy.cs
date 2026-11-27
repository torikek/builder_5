using Godot;

public partial class Enemy : CharacterBody2D
{
    [Export]
    public EnemyData Data { get; set; }
    public Vector2 targetPosition;

    public override void _PhysicsProcess(double delta)
    {
        if (Data != null)
        {
            GlobalPosition = GlobalPosition.MoveToward(targetPosition, Data.speed * (float)delta);
        }
    }

    public void setEnemyData(EnemyData enemyData)
    {
        Data = enemyData;
    }

    public void applyData()
    {
        Data.applyTo(this);
    }
}
