using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear objetos de héroes y enemigos
        Ninja ninja = new Ninja("Ninja");
        Samurai samurai = new Samurai("Samurai");
        Wizard wizard = new Wizard("Wizard");

        Zombie zombie1 = new Zombie("Zombie 1");
        Zombie zombie2 = new Zombie("Zombie 2");
        Spider spider = new Spider("Spider");

        List<Character> allies = new List<Character> { ninja, samurai, wizard };
        List<Character> enemies = new List<Character> { zombie1, zombie2, spider };

        Console.WriteLine("¡Comienza la batalla!");

        bool gameOver = false;

        // Implementa un sistema de turnos
        int turn = 0;
        while (!gameOver)
        {
            Character currentCharacter = allies[turn % allies.Count];
            Console.WriteLine($"{currentCharacter.Name}, es tu turno.");

            // Muestra las opciones de ataque
            Console.WriteLine("Elige un ataque:");
            Console.WriteLine("1. Ataque básico");
            Console.WriteLine("2. Ataque especial");

            // Lee la entrada del usuario
            string input = Console.ReadLine();
            if (input == "1")
            {
                currentCharacter.BasicAttack(enemies);
            }
            else if (input == "2")
            {
                currentCharacter.SpecialAttack(enemies);
            }
            else
            {
                Console.WriteLine("Entrada no válida. Elige un ataque válido.");
            }

            // Verifica si el juego ha terminado
            gameOver = CheckGameOver(allies, enemies);

            turn++;
        }

        // Anuncia el resultado del juego
        if (allies.TrueForAll(c => c.Health <= 0))
        {
            Console.WriteLine("¡Los enemigos ganaron!");
        }
        else
        {
            Console.WriteLine("¡Los héroes ganaron!");
        }
    }

    // Verifica si el juego ha terminado
    static bool CheckGameOver(List<Character> allies, List<Character> enemies)
    {
        return allies.TrueForAll(c => c.Health <= 0) || enemies.TrueForAll(c => c.Health <= 0);
    }
}

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int SpecialPower { get; set; }

    public Character(string name, int health, int attackPower, int specialPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        SpecialPower = specialPower;
    }

    public void BasicAttack(List<Character> targets)
    {
        foreach (Character target in targets)
        {
            int damage = AttackPower;
            target.Health -= damage;
            Console.WriteLine($"{Name} atacó a {target.Name} por {damage} de daño.");
        }
    }

    public void SpecialAttack(List<Character> targets)
    {
        foreach (Character target in targets)
        {
            int damage = SpecialPower;
            target.Health -= damage;
            Console.WriteLine($"{Name} realizó un ataque especial a {target.Name} por {damage} de daño.");
        }
    }
}

class Ninja : Character
{
    public Ninja(string name) : base(name, 100, 30, 50) { }
}

class Samurai : Character
{
    public Samurai(string name) : base(name, 120, 40, 40) { }
}

class Wizard : Character
{
    public Wizard(string name) : base(name, 80, 50, 60) { }
}

class Enemy : Character
{
    public Enemy(string name, int health, int attackPower) : base(name, health, attackPower, 0) { }
}

class Zombie : Enemy
{
    public Zombie(string name) : base(name, 80, 25) { }
}

class Spider : Enemy
{
    public Spider(string name) : base(name, 60, 20) { }
}

