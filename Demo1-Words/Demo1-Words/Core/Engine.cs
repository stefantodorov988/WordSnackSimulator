﻿namespace Demo1_Words.Core
{
    using System;
    using Factory;
    using Model;
    public class Engine
    {//generic strategy
        private IGamePoint gamePoint;
        private IGamePointFactory gamePointFactory;
        public Engine()
        {
            gamePointFactory = new GamePointFactory();
            CustomIO.ConfigureSettings();
        }
        public void Start()
        {
            Console.WriteLine(MenuMessages.mainMenu);
            string input = Console.ReadLine();
            gamePoint = gamePointFactory.CreateGamePoint(input);
            gamePoint.Run();
        }
    }
}
