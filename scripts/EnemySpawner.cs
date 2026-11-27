using Godot;
using System;

public partial class EnemySpawner : Node
{
    private GoblinBuilder goblinBuilder = new GoblinBuilder();
    private DragonBuilder dragonBuilder = new DragonBuilder();
    private Timer timer = new Timer();
    private RandomNumberGenerator random = new RandomNumberGenerator();
    [Export]
    private PackedScene enemyScene = GD.Load<PackedScene>("res://scenes/Enemy.tscn");

    public override void _Ready()
    {
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
        EnemyBuilder builder = builders(RandomIndex);
        builder.buildHp();
        builder.buildDamage();
        builder.buildSpeed();
        builder.buildSprite();
        EnemyData enemyData = builder.getResult();
        
        Enemy enemy = (Enemy)enemyScene.Instantiate();
        enemy.setEnemyData(enemyData);
        enemy.applyData();
        AddChild(enemy);
    }
}
