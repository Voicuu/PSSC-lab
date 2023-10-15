using System;
using System.Collections.Generic;
using static Lab1.Comanda;
using static Lab1.Product;
using Lab1;
using static Lab1.Quantity;

public class Program
{
    public static void Main(string[] args)
    {
        List<Comanda> comenzi = new List<Comanda>();

        while (true)
        {
            Console.WriteLine("Meniu:");
            Console.WriteLine("1. Adauga persoana");
            Console.WriteLine("2. Afiseaza comenzi existente");
            Console.WriteLine("3. Inchide programul");
            Console.Write("Optiunea dvs. este: ");
            int optiune;
            if (!int.TryParse(Console.ReadLine(), out optiune))
            {
                Console.WriteLine("Optiune invalida. Va rugam sa alegeti o optiune valida.");
                continue;
            }

            switch (optiune)
            {
                case 1:
                    Contact contact = CitesteContact();
                    List<Product> produse = CitesteProduse();
                    Comanda comanda = CreareComanda(contact, produse);
                    comenzi.Add(comanda);
                    Console.WriteLine("Comanda adaugata cu succes.");
                    break;
                case 2:
                    AfiseazaComenzi(comenzi);
                    break;
                case 3:
                    Console.WriteLine("Programul se inchide...");
                    return;
                default:
                    Console.WriteLine("Optiune invalida. Va rugam sa alegeti o optiune valida.");
                    break;
            }
        }
    }

    public static Contact CitesteContact()
    {
        Console.Write("Nume: ");
        string nume = Console.ReadLine();
        Console.Write("Prenume: ");
        string prenume = Console.ReadLine();
        Console.Write("Numar de telefon: ");
        string nrTelefon = Console.ReadLine();
        Console.Write("Adresa: ");
        string adresa = Console.ReadLine();

        return new Contact
        {
            nume = nume,
            prenume = prenume,
            nrTelefon = nrTelefon,
            adresa = adresa
        };
    }

    public static List<Product> CitesteProduse()
    {
        List<Product> produse = new List<Product>();

        while (true)
        {
            Console.Write("Cod produs (sau 0 pentru a incheia adaugarea de produse): ");
            if (!int.TryParse(Console.ReadLine(), out int codProdus))
            {
                Console.WriteLine("Codul produsului introdus nu este valid. Va rugam sa introduceti un numar valid.");
                continue;
            }

            if (codProdus == 0)
            {
                break;
            }

            Console.Write("Cantitate (Unitati sau Kg): ");
            String cantitateInput = Console.ReadLine();
            if (string.IsNullOrEmpty(cantitateInput))
            {
                break;
            }

            produse.Add(new Product
            {
                CodProdus = codProdus,
                Cantitate = new Number(cantitateInput)
            });
        }

        return produse;
    }


    public static void AfiseazaComenzi(List<Comanda> comenzi)
    {
        Console.WriteLine("Comenzi existente:");
        foreach (Comanda comanda in comenzi)
        {
            Console.WriteLine($"Nume client: {comanda.Contact.nume} {comanda.Contact.prenume}");
            Console.WriteLine($"Nr. telefon: {comanda.Contact.nrTelefon}");
            Console.WriteLine($"Adresa: {comanda.Contact.adresa}");
            Console.WriteLine("Produse:");
            foreach (Product produs in comanda.Produse)
            {
                Console.WriteLine($"Cod produs: {produs.CodProdus}, cantitate: {produs.Cantitate}");
            }
            Console.WriteLine();
        }
    }

    public static Comanda CreareComanda(Contact contact, List<Product> produse)
    {
        return new Comanda
        {
            Contact = contact,
            Produse = produse
        };
    }
}
