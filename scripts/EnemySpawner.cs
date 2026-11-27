using Godot;
using System;
using System.Collections.Generic;

public partial class EnemySpawner : Node
{
    private GoblinBuilder goblinBuilder = new GoblinBuilder();
    private DragonBuilder dragonBuilder = new DragonBuilder();
    private List<EnemyBuilder> builders;
    private Timer timer = new Timer();
    private RandomNumberGenerator random = new RandomNumberGenerator();
    [Export]
    private PackedScene enemyScene = GD.Load<PackedScene>("res://scenes/Enemy.tscn");
    [Export]
    private float enemySize = 64;

    public override void _Ready()
    {
        builders = new List<EnemyBuilder> { goblinBuilder, dragonBuilder };
        random.Randomize();
        timer.WaitTime = 1.0f;
        timer.OneShot = false;
        timer.Autostart = true;
        AddChild(timer);
        timer.Start();
        timer.Timeout += onTimerTimeout;
    }
    private void onTimerTimeout()
    {
        SpawnRandomEnemy();

    }

    private void SpawnRandomEnemy()
    {
        GD.Print("Spawning random enemy!");
        int RandomIndex = random.RandiRange(0, builders.Count -1);
        EnemyBuilder builder = builders[RandomIndex];
        builder.buildHp();
        builder.buildDamage();
        builder.buildSpeed();
        builder.buildSprite();
        EnemyData enemyData = builder.getResult();
        
        Enemy enemy = (Enemy)enemyScene.Instantiate();
        enemy.setEnemyData(enemyData);
        enemy.applyData();
        Sprite2D sprite = enemy.GetNode<Sprite2D>("Sprite2D");
        sprite.Scale = Vector2.One * enemySize / Mathf.Max(sprite.Texture.GetWidth(), sprite.Texture.GetHeight());
        AddChild(enemy);

        // Берём границы фона поля и оставляем отступ для размера врага.
        Sprite2D field = GetParent().GetNode<Sprite2D>("Sprite2D");
        Vector2 start = field.ToGlobal(field.GetRect().Position);
        Vector2 end = field.ToGlobal(field.GetRect().End);
        enemy.targetPosition = (start + end) / 2;
        enemy.GlobalPosition = new Vector2(
            random.RandfRange(start.X + enemySize / 2, end.X - enemySize / 2),
            random.RandfRange(start.Y + enemySize / 2, end.Y - enemySize / 2));
    }
}
