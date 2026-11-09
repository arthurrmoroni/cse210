using System;

// Responsabilidade: guardar e exibir as informações de um emprego.
public class Job
{
    // Atributos (variáveis-membro): começam com _ por convenção em C#
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear;
    public int _endYear;

    // Exibe no formato: "Job Title (Company) StartYear-EndYear"
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}