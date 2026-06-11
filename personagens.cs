using System;
using System.ComponentModel;
using System.Globalization;
using System.Collections.Generic;
// foi criado um interface pois um subclasse não herda de mais de uma classe
//onde foi firmado um contrato,todo metodo existente dentro de interface DEVE ser ulilizado pela subclasse por causa do contrato firmado
interface Iarmadura
{
    void DA();// Descrição da armadura
}


// super classe personagem criada
class personagem
{
    protected string Nome { get; set; }// uso do protected pois haverão subclasses que herdarão esse atributo
    public List<personagem> perso { get; set; }

    public virtual void atacar()
    {
        Console.WriteLine("O personagem ataca");
    }
}

//sub classe guerreiro criada 
class guerreiro : personagem, Iarmadura
{
    private string TDA { get; set; }// tipo de arma

    // metodo da subclasse construtor criado
    public guerreiro(string TDA, String Nome)
    {
        this.TDA = TDA;
        this.Nome = Nome;
    }

    public override void atacar()
    {
        Console.WriteLine($"O guerreiro {Nome} usa seu/sua {TDA} para ataca");
    }

    public void DA()
    {
        Console.WriteLine("O guerreiro usa armadeura mais pesada por causa do combate corpo a corpo");
    }
}

class mago : personagem, Iarmadura
{

    private string TDM { get; set; }// tipo de magia

    // metodo da subclasse construtor criado
    public mago(string Nome, string tdm)
    {
        this.Nome = Nome;
        this.TDM = tdm;
    }
    public override void atacar()
    {
        Console.WriteLine($"O {Nome} ataca com magia de {TDM}");
    }

    public void DA()
    {
        Console.WriteLine("O mago quase não usa aramadura por padrão");
    }

}

class arqueiro : personagem, Iarmadura
{
    private string TDA { get; set; }//tipo de arco

    // metodo da subclasse construtor criado
    public arqueiro(string nome, string tda)
    {
        this.Nome = nome;
        this.TDA = tda;
    }
    public override void atacar()
    {
        Console.WriteLine($"O {Nome} usa seu {TDA} para atira fleshas de longas distancias com precisão");
    }

    public void DA()
    {
        Console.WriteLine("O arqueiro usa armadura mais leve para melhor mobilidade");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<personagem> p = new List<personagem>();


        personagem g = new personagem();
        g.atacar();
        p.Add(g);
        guerreiro x = new guerreiro("lança", "meng wu");
        x.atacar();
        x.DA();
        p.Add(x);
        mago mage = new mago("gray fullbuster", "magia de gelo");
        mage.atacar();
        mage.DA();
        p.Add(mage);
        arqueiro arco = new arqueiro("misumi makoto", "arco curto");
        arco.atacar();
        arco.DA();
        p.Add(arco);


        //foreach onde eu uso a variavel m para poder percorrer a lista de p do tipo personagens
        foreach (personagem m in p)
        {
            Console.WriteLine(m.ToString());
            m.atacar();
        }

    }
}

