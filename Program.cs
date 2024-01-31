using System.Diagnostics;

namespace ContoCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Scrivere un algoritmo che prenda in input un valore di x nomi (decida il candidato la dimensione dell'array).
             * Dopo aver caricato l'array, specificare un nome da ricercare e stampare se il nome è presente o meno nell'array
             * caricato precedentemente.
             * */

            int dimension = int.Parse(Console.ReadLine());
            string[] names = new string[dimension];

            for (int j = 0; j < dimension; j++)
            {
                string insertedName = Console.ReadLine();
                names[j] = insertedName;
            }

            string searchedName = "pinco";

            bool found = false;
            int i = 0;
            while (!found && i < names.Length)
            {
                if (names[i].ToLower() == searchedName)
                {
                    found = true;
                }
                i++;
            }

            if (found)
            {
                Console.WriteLine("Trovato");
            }
            else
            {
                Console.WriteLine("Non trovato");
            }
            return;



            if (names.Contains(searchedName))
            {
                Console.WriteLine("Trovato");
            } else
            {
                Console.WriteLine("Non trovato");
            }
            return;



            Console.WriteLine("Apri il conto");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Deposito iniziale (almeno 1000€): ");
            double initialDeposit = double.Parse(Console.ReadLine());
            ContoCorrente userAccount = new ContoCorrente(name, initialDeposit);

            Console.Clear();
            Console.WriteLine("Conto creato! Inizia ad operare");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("1 - Deposita");
                Console.WriteLine("2 - Prelieva");
                Console.WriteLine("3 - Saldo");
                Console.WriteLine("4 - Esci");

                string choice = Console.ReadLine();
                Console.Clear();

                double amount;
                switch (choice)
                {
                    case "1":
                        Console.Write("Quantità: ");
                        amount = double.Parse(Console.ReadLine());
                        userAccount.Deposit(amount);
                        break;

                    case "2":
                        Console.Write("Quantità: ");
                        amount = double.Parse(Console.ReadLine());
                        userAccount.Withdraw(amount);
                        break;

                    case "3":
                        userAccount.ShowStatus();
                        break;
                    case "4":
                        return;

                    default:
                        Console.WriteLine("L'opzione inserita non esiste!");
                        break;
                }
                Console.WriteLine();
            }
        }
    }

    public class ContoCorrente
    {
        double _balance = 0;
        string _name;
        
        public double Balance
        {
            get { return _balance; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ContoCorrente(string name, double initialDeposit)
        {
            Name = name;
            if (initialDeposit > 1000)
            {
                Deposit(initialDeposit);
            } else
            {
                // lanciare errore
            }
        }

        public void Deposit(double amount)
        {
            if (amount > 0 && amount < 10000)
            {
                _balance += amount;
                return;
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount < 500)
            {
                _balance -= amount;
                return;
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Il saldo è: {Balance}");
        }
    }
}
