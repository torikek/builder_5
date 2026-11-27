using Godot;

// враг с характеристиками и движением к заданной цели
public partial class Enemy : CharacterBody2D
{
    // характеристики врага доступны в инспекторе godot
    [Export]
    public EnemyData Data { get; set; }
    // точка назначения в глобальных координатах
    public Vector2 targetPosition;

    // перемещает врага к цели на каждом физическом кадре
    public override void _PhysicsProcess(double delta)
    {
        // движение начинается только после назначения характеристик
        if (Data != null)
        {
            // учитываем время кадра для постоянной скорости движения
            GlobalPosition = GlobalPosition.MoveToward(targetPosition, Data.speed * (float)delta);
        }
    }

    // назначает врагу набор характеристик
    public void setEnemyData(EnemyData enemyData)
    {
        Data = enemyData;
    }

    // применяет внешний вид из назначенных характеристик
    public void applyData()
    {
        Data.applyTo(this);
    }
}
