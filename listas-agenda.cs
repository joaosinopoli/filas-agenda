using System;
using System.Collections.Generic;

class Data
{
    public int Dia { get; private set; }
    public int Mes { get; private set; }
    public int Ano { get; private set; }
    
    public Data(int dia, int mes, int ano)
    {
        setData(dia, mes, ano);
    }

    public void setData(int dia, int mes, int ano)
    {
        Dia = dia;
        Mes = mes;
        Ano = ano;
    }

    public override string ToString()
    {
        return $"{Dia:D2}/{Mes:D2}/{Ano:D4}";
    }
}

class Telefone
{
    public string Tipo { get; private set; }
    public string Numero { get; private set; }
    public bool Principal { get; private set; }

    public Telefone(string tipo, string numero, bool principal)
    {
        Tipo = tipo;
        Numero = numero;
        Principal = principal;
    }
}

class Contato
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public Data DtNasc { get; set; }
    private List<Telefone> telefones;

    public Contato(string nome, string email, Data dtNasc)
    {
        Nome = nome;
        Email = email;
        DtNasc = dtNasc;
        telefones = new List<Telefone>();
    }
public int getIdate()
    {
        return DtNasc.Ano * 10000 + DtNasc.Mes * 100 + DtNasc.Dia;
    }

    public void adicionarTelefone(Telefone t)
    {
        telefones.Add(t);
    }

    public string getTelefonePrincipal()
    {
        Telefone tel = telefones.Find(t => t.Principal);
        return tel != null ? tel.Numero : "Nenhum definido";
    }

    public override string ToString()
    {
        string dados = $"Nome: {Nome}\nEmail: {Email}\nNascimento: {DtNasc}\nTelefone principal: {getTelefonePrincipal()}\n";
        foreach (var t in telefones)
        {
            dados += "   " + t + "\n";
        }
        return dados;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Contato)) return false;
        Contato c = (Contato)obj;
        return this.Email == c.Email;
    }

    public override int GetHashCode()
    {
        return Email.GetHashCode();
    }
}

class Contatos
{
    private List<Contato> agenda;

    public Contatos()
    {
        agenda = new List<Contato>();
    }

    public IReadOnlyList<Contato> Agenda => agenda.AsReadOnly();

    public bool adicionar(Contato c)
    {
        if (agenda.Contains(c)) return false;
        agenda.Add(c);
        return true;
    }

    public Contato pesquisar(Contato c)
    {
        return agenda.Find(x => x.Equals(c));
    }

    public bool alterar(Contato c)
    {
        int idx = agenda.FindIndex(x => x.Equals(c));
        if (idx >= 0)
        {
            agenda[idx] = c;
            return true;
        }
        return false;
    }

    public bool remover(Contato c)
    {
        return agenda.Remove(c);
    }
}

class Program
{
    static void Main()
    {
        Contatos agenda = new Contatos();
        int opcao;

        do
        {
            Console.WriteLine("\nMENU:");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Pesquisar contato");
            Console.WriteLine("3. Alterar contato");
            Console.WriteLine("4. Remover contato");
            Console.WriteLine("5. Listar contatos");
            Console.Write("Opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Data de nascimento (dd mm aaaa): ");
                    string[] partes = Console.ReadLine().Split();
                    Data d = new Data(int.Parse(partes[0]), int.Parse(partes[1]), int.Parse(partes[2]));
                    Contato novo = new Contato(nome, email, d);

                    Console.Write("Quantos telefones deseja adicionar? ");
                    int qtd = int.Parse(Console.ReadLine());
                    for (int i = 0; i < qtd; i++)
                    {
                        Console.Write("Tipo: ");
                        string tipo = Console.ReadLine();
                        Console.Write("Número: ");
                        string numero = Console.ReadLine();
                        Console.Write("É principal? (s/n): ");
                        bool principal = Console.ReadLine().ToLower() == "s";
                        novo.adicionarTelefone(new Telefone(tipo, numero, principal));
                    }

                    if (agenda.adicionar(novo))
                        Console.WriteLine("Contato adicionado!");
                    else
                        Console.WriteLine("Já existe contato com esse email.");
                    break;

                case 2:
                    Console.Write("Email do contato a pesquisar: ");
                    string pesqEmail = Console.ReadLine();
                    Contato busca = agenda.pesquisar(new Contato("", pesqEmail, new Data(1, 1, 1900)));
                    if (busca != null)
                        Console.WriteLine(busca);
                    else
                        Console.WriteLine("Contato não encontrado.");
                    break;

                case 3:
                    Console.Write("Email do contato a alterar: ");
                    string altEmail = Console.ReadLine();
                    Contato atual = agenda.pesquisar(new Contato("", altEmail, new Data(1, 1, 1900)));
                    if (atual != null)
                    {
                        Console.Write("Novo nome: ");
                        string novoNome = Console.ReadLine();
                        Console.Write("Nova data de nascimento (dd mm aaaa): ");
                        string[] dtn = Console.ReadLine().Split();
                        Data nd = new Data(int.Parse(dtn[0]), int.Parse(dtn[1]), int.Parse(dtn[2]));
                        Contato atualizado = new Contato(novoNome, altEmail, nd);

                        Console.Write("Quantos telefones deseja adicionar? ");
                        qtd = int.Parse(Console.ReadLine());
                        for (int i = 0; i < qtd; i++)
                        {
                            Console.Write("Tipo: ");
                            string tipo = Console.ReadLine();
                            Console.Write("Número: ");
                            string numero = Console.ReadLine();
                            Console.Write("É principal? (s/n): ");
                            bool principal = Console.ReadLine().ToLower() == "s";
                            atualizado.adicionarTelefone(new Telefone(tipo, numero, principal));
                        }

                        if (agenda.alterar(atualizado))
                            Console.WriteLine("Contato atualizado!");
                        else
                            Console.WriteLine("Erro ao atualizar.");
                    }
                    else
                        Console.WriteLine("Contato não encontrado.");
                    break;

                case 4:
                    Console.Write("Email do contato a remover: ");
                    string remEmail = Console.ReadLine();
                    if (agenda.remover(new Contato("", remEmail, new Data(1, 1, 1900))))
                        Console.WriteLine("Contato removido.");
                    else
                        Console.WriteLine("Contato não encontrado.");
                    break;

                case 5:
                    Console.WriteLine("=== Lista de contatos ===");
                    foreach (var c in agenda.Agenda)
                        Console.WriteLine(c);
                    break;
            }

        } while (opcao != 0);
    }
}