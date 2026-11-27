using Godot;
using System;
using System.Collections.Generic;

// создаёт случайных врагов через равные промежутки времени
public partial class EnemySpawner : Node2D
{
    // повторно используем строителей для двух типов врагов
    private GoblinBuilder goblinBuilder;
    private DragonBuilder dragonBuilder;
    // список строителей для случайного выбора типа врага
    private List<EnemyBuilder> builders;
    // таймер определяет частоту появления врагов
    private Timer timer = new Timer();
    // генератор выбирает тип врага и его начальную позицию
    private RandomNumberGenerator random = new RandomNumberGenerator();
    // сцена врага доступна для замены в инспекторе
    [Export]
    private PackedScene enemyScene = GD.Load<PackedScene>("res://scenes/Enemy.tscn");
    // размер большей стороны спрайта в пикселях
    [Export]
    private float enemySize = 64;
    // интервал появления врагов в секундах
    [Export(PropertyHint.Range, "0.01,60,0.01,or_greater")]
    private float spawnInterval = 1.0f;

    // подготавливает строителей и запускает периодическое создание врагов
    public override void _Ready()
    {
        goblinBuilder = GetNode<GoblinBuilder>("GoblinBuilder");
        dragonBuilder = GetNode<DragonBuilder>("DragonBuilder");
        builders = new List<EnemyBuilder> { goblinBuilder, dragonBuilder };
        // инициализируем генератор случайных чисел
        random.Randomize();
        // настраиваем повторяющийся таймер
        timer.WaitTime = spawnInterval;
        timer.OneShot = false;
        timer.Autostart = true;
        // добавляем таймер в дерево сцены для обработки времени
        AddChild(timer);
        timer.Start();
        // связываем сигнал таймера с обработчиком появления врага
        timer.Timeout += onTimerTimeout;
    }
    // создаёт очередного врага по сигналу таймера
    private void onTimerTimeout()
    {
        SpawnRandomEnemy();

    }

    // собирает случайного врага и размещает его в пределах поля
    private void SpawnRandomEnemy()
    {
        GD.Print("Spawning random enemy!");
        // выбираем строителя одного из доступных типов врагов
        int RandomIndex = random.RandiRange(0, builders.Count -1);
        EnemyBuilder builder = builders[RandomIndex];
        EnemyData enemyData = construct(builder);
        spawn_enemy(enemyData);
    }

    // последовательно выполняет шаги строительства и возвращает характеристики
    private EnemyData construct(EnemyBuilder builder)
    {
        // последовательно заполняем все характеристики выбранного типа
        builder.buildHp();
        builder.buildDamage();
        builder.buildSpeed();
        builder.buildSprite();
        return builder.getResult();
    }

    // создаёт врага с готовыми характеристиками и размещает его на поле
    private void spawn_enemy(EnemyData enemyData)
    {
        // создаём экземпляр сцены и применяем подготовленные характеристики
        Enemy enemy = (Enemy)enemyScene.Instantiate();
        enemy.setEnemyData(enemyData);
        enemy.applyData();
        Sprite2D sprite = enemy.GetNode<Sprite2D>("Sprite2D");
        // приводим большую сторону текстуры к нужному размеру с сохранением пропорций
        sprite.Scale = Vector2.One * enemySize / Mathf.Max(sprite.Texture.GetWidth(), sprite.Texture.GetHeight());
        AddChild(enemy);

        // получаем границы фона поля в глобальных координатах
        Sprite2D field = GetParent().GetNode<Sprite2D>("Sprite2D");
        Vector2 start = field.ToGlobal(field.GetRect().Position);
        Vector2 end = field.ToGlobal(field.GetRect().End);
        // направляем врага к центру поля
        enemy.targetPosition = (start + end) / 2;
        // выбираем случайную позицию с отступом в половину размера врага от краёв
        enemy.GlobalPosition = new Vector2(
            random.RandfRange(start.X + enemySize / 2, end.X - enemySize / 2),
            random.RandfRange(start.Y + enemySize / 2, end.Y - enemySize / 2));
    }
}
