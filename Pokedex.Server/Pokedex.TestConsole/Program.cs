// See https://aka.ms/new-console-template for more information
using Pokedex.Model.Utils;

Console.WriteLine("Hello, World!");



LanguageManager.Instance.Load("./Resources/Translation.json");



Thread.Sleep(3000);


Console.WriteLine(LanguageManager.Instance.koKR("bulbasaur"));

Console.WriteLine();
Thread.Sleep(3000);


Console.WriteLine(LanguageManager.Instance.enUS("bulbasaur"));
Console.WriteLine();


Thread.Sleep(5000);


Console.WriteLine(LanguageManager.Instance.jaJP("bulbasaur"));