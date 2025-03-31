using System;
using System.Collections.Generic;


public abstract class Animal
{
    public string Nome { get; set; }
    private int idade;
    public int Idade
    {
        get { return idade; }
        set
        {
            if (value < 0)
                throw new ArgumentException("A idade não pode ser negativa");
            idade = value;
        }
    }

    public Animal(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public abstract void EmitirSom();

    public virtual void Apresentar()
    {
        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
    }
}


public class Cachorro : Animal
{
    public Cachorro(string nome, int idade) : base(nome, idade) { }

    public override void EmitirSom()
    {
        Console.WriteLine("Au au!");
    }
}


public class Gato : Animal
{
    public Gato(string nome, int idade) : base(nome, idade) { }

    public override void EmitirSom()
    {
        Console.WriteLine("Miau!");
    }
}


public class Passaro : Animal
{
    public Passaro(string nome, int idade) : base(nome, idade) { }

    public override void EmitirSom()
    {
        Console.WriteLine("Piu piu!");
    }

    public void Voar()
    {
        Console.WriteLine($"{Nome} está voando!");
    }
}


public class Zoo
{
    private List<Animal> animais = new List<Animal>();

    public void AdicionarAnimal(Animal animal)
    {
        animais.Add(animal);
    }

    public void ExibirAnimais()
    {
        Console.WriteLine("\nAnimais no Zoo:");
        foreach (Animal animal in animais)
        {
            animal.Apresentar();
            animal.EmitirSom();
            Console.WriteLine();
        }
    }
}


public class Veterinario
{
    private string especialidade;
    public string Especialidade
    {
        get { return especialidade; }
        set
        {
            if (value != "Felinos" && value != "Caninos" && value != "Aves")
                throw new ArgumentException("Especialidade deve ser 'Felinos', 'Caninos' ou 'Aves'");
            especialidade = value;
        }
    }

    public Veterinario(string especialidade)
    {
        Especialidade = especialidade; 
    }

    public void Examinar(Animal animal)
    {
        Console.WriteLine($"\nVeterinário de {Especialidade} examinando {animal.Nome}:");
        animal.Apresentar();
        animal.EmitirSom();
    }
}


class Program
{
    static void Main()
    {
        try
        {
         
            var cachorro = new Cachorro("Totó", 5);
            var gato = new Gato("Frajola", 3);
            var passaro = new Passaro("Piuzinho", 2);

       
            var zoo = new Zoo();
            zoo.AdicionarAnimal(cachorro);
            zoo.AdicionarAnimal(gato);
            zoo.AdicionarAnimal(passaro);

           
            zoo.ExibirAnimais();

       
            passaro.Voar();

         
            var vetCaninos = new Veterinario("Caninos");
            var vetFelinos = new Veterinario("Felinos");
            var vetAves = new Veterinario("Aves");


            vetCaninos.Examinar(cachorro);
            vetFelinos.Examinar(gato);
            vetAves.Examinar(passaro);

       
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}