using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO.Pipes;
using System.Net.Quic;
using System.Runtime.CompilerServices;

interface ISeguro
{
    public double Seguroparticular(double v);
}

public abstract class veiculo
{
    protected string Marca { get; set; }
    protected string Cor { get; set; }
    protected double Valor { get; set; }

    public abstract void Mostarinfo();
}

class carro : veiculo
{
    protected int NDP { get; set; } // numero de portas

    public carro(string marca, string cor, double valor, int ndp)
    {
        this.Marca = marca;
        this.Cor = cor;
        this.Valor = valor;
        this.NDP = ndp;
    }

    public override void Mostarinfo()
    {
        Console.WriteLine($"O Carro da marca {Marca} de cor {Cor} custa R${Valor},00 com {NDP} portas");
    }
}

class Sedan : carro, ISeguro
{
    private double Valorseguro { get; set; }
    double v;


    public Sedan(string marca, string cor, double valor, int ndp, double valorseguro) : base(marca, cor, valor, ndp)
    {
        this.Valorseguro = valorseguro;
    }

    public override void Mostarinfo()
    {
        Console.WriteLine($"O sedan da marca {Marca} possui {NDP} portas de cor {Cor} no valor de R${Valor},00 com o valor do seguro padrão custando {Valorseguro}");
        Console.WriteLine($"O seguro particular do sedan custa {v}");
    }

    public double Seguroparticular(double valor)
    {

        v = valor * 0.03;

        return v;
    }

}

class Picape : carro, ISeguro
{
    private double Valorseguro;
    double v;

    public Picape(double valorseguro, string cor, string marca, double valor, int ndp) : base(marca, cor, valor, ndp)
    {
        Valorseguro = valorseguro;
    }

    public override void Mostarinfo()
    {
        Console.WriteLine($"O picape da marca {Marca} possui {NDP} portas de cor {Cor} no valor de R${Valor},00 com o seguro custando {Valorseguro}");
        Console.WriteLine($"O seguro particular do picape custa {v}");
    }

    public double Seguroparticular(double valor)
    {

        v = valor * 0.08;

        return v;
    }

}

class Moto : veiculo
{
    protected int cilindradas { get; set; }
    public Moto(string marca, string cor, double valor, int cilin)
    {
        this.Marca = marca;
        this.Cor = cor;
        this.Valor = valor;
        this.cilindradas = cilin;
    }

    public override void Mostarinfo()
    {
        Console.WriteLine($"A moto da marca {Marca} de cor {Cor} custa um total de R${Valor},00 com {cilindradas}");
    }
}

class scooter : Moto, ISeguro
{
    private double Valorseguro;
    double v;

    public scooter(double valorseguro, string marca, string cor, double valor, int cilindradas) : base(marca, cor, valor, cilindradas)
    {
        Valorseguro = valorseguro;
    }

    public override void Mostarinfo()
    {
        Console.WriteLine($"A scooter da marca {Marca} de cor {Cor} custa um total de R${Valor},00 com {cilindradas} cilindradas");
        Console.WriteLine($"O seguro particular do scooter custa {v}");
    }

    public double Seguroparticular(double valor)
    {

        v = valor * 0.03;

        return v;
    }
}

class motocros : Moto, ISeguro
{
    private double Valorseguro;
    double v;

    public motocros(double valorseguro, string marca, string cor, double valor, int cilindradas) : base(marca, cor, valor, cilindradas)
    {
        Valorseguro = valorseguro;
    }

    public override void Mostarinfo()
    {
        Console.WriteLine($"Uma moto no modelo de motocross da marca {Marca} de cor {Cor} custa um total de R${Valor},00 com {cilindradas} cilindradas");
        Console.WriteLine($"O seguro particular de uma moto de motocross custa {v}");
    }

    public double Seguroparticular(double valor)
    {

        v = valor * 0.08;

        return v;
    }

}


class Program
{
    static void Main(string[] args)
    {
        Sedan sedan = new Sedan("chevrolet", "preto", 50000, 4, 2000);
        sedan.Seguroparticular(50000);
        sedan.Mostarinfo();
        Picape picape = new Picape(4000, "branca", "hyundai", 80000, 4);
        picape.Seguroparticular(80000);
        picape.Mostarinfo();
        scooter scooter = new scooter(1500, "yamaha", "azul", 23000, 2000);
        scooter.Seguroparticular(23000);
        scooter.Mostarinfo();
        motocros motocros = new motocros(1000, "yamaha", "vermelha", 33000, 2000);
        motocros.Seguroparticular(33000);
        motocros.Mostarinfo();

    }
}



