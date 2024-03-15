public class Pet
{
    private object lockObject = new object();
    private string name { get; set; }
    private int healthPoints { get; set; }
    private int hungerLvl { get; set; }
    private int fatigueLvl { get; set; }
    private bool isAlive = true;

    public Pet(string name)
    {
        this.name = name;
        this.healthPoints = 10;
        this.hungerLvl = 0;
        this.fatigueLvl = 0;

        Thread hungerThread = new Thread(IncreaseHunger);
        hungerThread.Start();
    }

    public void Feed()
    {
        lock (lockObject)
        {
            if (isAlive)
            {
                if (hungerLvl >= 3) 
                {
                    hungerLvl = Math.Max(-2, hungerLvl - 1);
                    Console.WriteLine("Питомец покормлен.");
                }
                else if (hungerLvl < 3 && healthPoints > 0)
                {
                    healthPoints--;
                    Console.WriteLine("Питомец переел.");
                }
                else
                {
                    Console.WriteLine("Питомец не голоден и больше не может кушать.");
                }

                if (hungerLvl == -1)
                {
                    Console.WriteLine("Хватит кормить питомца иначе он заболеет.");
                }
                if (hungerLvl == -2)
                {
                    isAlive = false;
                    Console.WriteLine("Питомец заболел.");
                }
            }
            else
            {
                Console.WriteLine("Питомец болен.");
            }
        }
    }

    private void IncreaseHunger()
    {
        while (isAlive)
        {
            Thread.Sleep(3000);
            lock (lockObject)
            {
                hungerLvl++;
                Console.WriteLine("Уровень голода увеличен до: " + hungerLvl);

                if (hungerLvl >= 10 && healthPoints > 0) 
                {
                    healthPoints--;
                    Console.WriteLine("Уровень здоровья уменьшен до: " + healthPoints);
                }

                if (hungerLvl >= 10 && healthPoints > 0)
                {
                    healthPoints--;
                    Console.WriteLine("Уровень здоровья дополнительно уменьшен до: " + healthPoints);
                }

                if (healthPoints == 0) 
                {
                    isAlive = false; 
                    Console.WriteLine("Питомец заболел!");
                }
            }
        }
    }

    public void Play()
    {
        lock (lockObject)
        {
            if (isAlive)
            {
                fatigueLvl = Math.Min(10, fatigueLvl + 5);

                if (fatigueLvl >= 10)
                {
                    healthPoints--;
                    hungerLvl++;
                    Console.WriteLine("Питомец переутомился от игры.");
                }
                else
                {
                    Console.WriteLine("Питомец играет.");
                }
            }
            else
            {
                Console.WriteLine("Питомец болен. Игра окончена");
            }
        }
    }

    public void Sleep()
    {
        lock (lockObject)
        {
            if (isAlive)
            {
                fatigueLvl = 0;
                healthPoints = Math.Min(10, healthPoints + 1);
                hungerLvl++;
                Console.WriteLine("Питомец спит.");
            }
            else
            {
                Console.WriteLine("Питомец заболел.");
            }
        }
    }
}