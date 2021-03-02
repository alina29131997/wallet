using System;
using System.Collections.Generic;

namespace Wallet
{
    enum Banknote
    {
        One = 1,
        Two = 2,
        Five = 5,
        Ten = 10,
        Twenty = 20,
        Fifty = 50,
        Hundred = 100,
        Twohundred = 200,
        Fivehundred = 500
    }

    class Banknotes
    {

        private double amount;
        private Banknote banknote;
        protected int Banknote
        {
            get { return (int)banknote; }
            set { banknote = (Banknote)value; }
        }

        public Banknotes(Banknote banknote, double amount)  // конструктор
        {
            this.banknote = banknote;
            this.amount = amount;
        }

        public override string ToString() // возвращает информацию от обьекте 
        {
            return $" Banknote: {this.banknote}, amount: {this.amount}, total: {this.GetTotal()}";
        }

        public void Show()
        {
            Console.WriteLine(this.ToString());
        }

        public double GetTotal()
        {
            return this.Banknote * this.amount;
        }
    }

    class Exchanger : Banknotes
    {
        private double currency;

        public Exchanger(double currency, Banknote banknote, double amount) : base(banknote, amount)
        {
            this.currency = currency;
        }
        public double Convert()
        {
            return base.GetTotal() * this.currency;
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Array values = Enum.GetValues(typeof(Banknote)); //создаю массив типов купюр 
            Random random = new Random(); // обьект рандома чтобы потом сгенерировать случайные числа 
            Banknote randomBanknote = (Banknote)values.GetValue(random.Next(values.Length));

            Banknotes tmp = new Banknotes(randomBanknote, random.Next(1,1000));
            Console.WriteLine(tmp);
            Exchanger exchanger = new Exchanger(33.76, Banknote.One, 1);
            Console.WriteLine(exchanger.Convert());
            
        }
    }
}
