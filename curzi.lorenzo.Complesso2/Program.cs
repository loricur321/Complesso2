using System;

namespace curzi.lorenzo.Complesso2
{
    class Program
    {
        class Complesso
        {
            public double reale;            //parte reale del numero
            public double immaginario;      //parte immaginaria del numero
            public double modulo;           //modulo del numero complesso
            public double fase;             //fase del numero complesso

            public Complesso(double a, double b)
            {
                reale = a;
                immaginario = b;
            }

            public Complesso (double a, double b, int c) //costruttore tramite modulo e fase
            {
                modulo = a;
                fase = b;
            }

            public void ParteReale(double a, double b)
            {
                reale = Math.Cos(a); //calcolo tramite la formula la parte reale e quella immaginaria
                immaginario = Math.Sin(b);
            }

            //public string ToBinomial(Complesso W3)
            //{

            //    string formaBinomiale = $"La forma binomiale del numero è: {W3.reale} + i{W3.immaginario}";

            //    return formaBinomiale;
            //}
            

            public void Addizione(Complesso W1, Complesso W2) //addizione tra i due numeri
            {
                reale = W1.reale + W2.reale;
                immaginario = W1.immaginario + W2.immaginario;
            }

            public void Sottrazione(Complesso W1, Complesso W2) //sottrazzione tra i due numeri
            {
                reale = W1.reale - W2.reale;
                immaginario = W1.immaginario - W2.immaginario;
            }

            public void Moltiplicazione(Complesso W1, Complesso W2) //moltiplicazione tra i due numeri
            {
                reale = (W1.reale * W2.immaginario) - (W1.immaginario * W2.immaginario);
                immaginario = (W1.immaginario * W2.reale) + (W2.immaginario * W1.reale);
            }

            public void Divisione(Complesso W1, Complesso W2) //divisione tra i due numeri
            {
                reale = ((W1.reale * W2.reale) + (W1.immaginario * W2.immaginario)) / (Math.Pow(W2.reale, 2) + Math.Pow(W2.immaginario, 2));
                immaginario = ((W1.immaginario * W2.reale) - (W1.reale * W2.immaginario)) / (Math.Pow(W2.reale, 2) + Math.Pow(W2.immaginario, 2));
            }
        }



        static void Main(string[] args)
        {
            //Si vuole realizzare un programma con l'interfaccia console che esegua le 4 operazioni arirmetiche sui numeri complessi.
            //Il funzionamento consiste nell'inserire i due operandi, scegliere l'operazione desiderata(attraverso un semplice menù a video) e infine dare il risultato.

            int n = SceltaOperazione(); //operazione da eseguire


            Console.WriteLine("Programma complesso di Lorenzo Curzi, 4H");

            Console.WriteLine("Inserire la parte reale del primo numero:");
            double reale1 = RichiestaNumero(); //parte reale del primo numero
            Console.WriteLine("in serire la parte immaginaria del primo numero:");
            double immaginaria1 = RichiestaNumero(); //parte immagianaria del primo numero

            Console.WriteLine("Inserire la parte reale del secondo numero:");
            double reale2 = RichiestaNumero(); //parte reale del secondo numero
            Console.WriteLine("in serire la parte immaginaria del secondo numero:");
            double immaginaria2 = RichiestaNumero(); //parte immagianria del secondo numero
 

            Complesso Z1 = new Complesso(reale1, immaginaria1);
            Complesso Z2 = new Complesso(reale2, immaginaria2);

            Complesso risultato = new Complesso(0, 0);

            //a seconda della scelta dell'utente chiamo la funzione richiesta
            if (n == 1)
            {
                risultato.Addizione(Z1, Z2);
            }
            else if (n == 2)
            {
                risultato.Sottrazione(Z1, Z2);
            }
            else if (n == 3)
            {
                risultato.Moltiplicazione(Z1, Z2);
            }
            else 
            {
                risultato.Divisione(Z1, Z2);
            }
            


            Console.WriteLine($"Il risultato è: {risultato.reale} + {risultato.immaginario}i"); //comunico il risultato dell'operazione

            //-------------------------------------------------------------------------------------------------------------------------------------------
            //Inserimento del numero tramite modulo e fase

            Console.WriteLine("Inserire il modulo del numero:");
            double modulo = RichiestaNumero();
            modulo = (modulo * Math.PI) / 180;
            Console.WriteLine("Inserire la fase del numero(in gradi):");
            double fase = RichiestaNumero();
            fase = (fase * Math.PI) / 180; //converto la fase in radianti

            Complesso Z3 = new Complesso(modulo, fase, 0); //invio modulo e fase al costruttore. Invio anche 0 per distinguire i due costruttori della classe ma non verrà usato come parametro

            Z3.ParteReale(Z3.modulo, Z3.fase);

            Console.WriteLine($"La forma binomiale del numero è: {Z3.reale} + {Z3.immaginario}i");

            Console.WriteLine($"La forma polare del numero è: modulo {Z3.modulo}, fase {Z3.fase}");

        }

        private static double RichiestaNumero()
        {
            double numero;
            bool a = false;
            do
            {
                string strNumero = Console.ReadLine();//richiedo il numero all'utente
                a = double.TryParse(strNumero, out numero);//e lo converto
            } while (a != true); //controllo che sia un numero(sia negativo che positivo) e non un qualsiasi altro carattere
            return numero;
        }

        private static int SceltaOperazione()
        {
            int n;

            while (true)//ciclo per chiedere l'operazione da eseguire
            {
                Console.WriteLine("Che operazione si desidera svolegere?");
                Console.WriteLine("1: addizione");
                Console.WriteLine("2: sottrazione");
                Console.WriteLine("3: moltiplicazione");
                Console.WriteLine("4: divisione");

                string strN = Console.ReadLine(); //richiedo il numero che rappresenta l'operazione da eseguire

                int.TryParse(strN, out n);

                if (n == 1 || n == 2 || n == 3 || n == 4 )
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Numero sbagliato! Assciurarsi di selezionare la operazione desiderata");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return n;
        }
    }
}
