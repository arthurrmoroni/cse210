using System;
using System.Collections.Generic;

// Responsabilidade: guardar o nome da pessoa e a lista de empregos, e exibir o currículo.
public class Resume
{
    public string _name = "";

    // Já inicializa a lista vazia para poder dar .Add() direto
    public List<Job> _jobs = new List<Job>();

    // Exibe o nome e depois cada emprego (reaproveitando o Display() do Job)
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}