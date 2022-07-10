using System;
using System.Text;

namespace Labb1_Implementera
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] notes = new int[] { 100, 500, 200, 2000 };



            //Adapter Pattern 

            Array.Sort(notes);
            Array.Reverse(notes);

            string input = string.Empty;
            decimal amount = default;

            bool continueLoop = true;

            bool vendAllNotestype = false;

            int count2000 = 0, count500 = 0, count200 = 0, count100 = 0;

            do
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("Welcome to EduGradeBank ATM");
                Console.WriteLine("*******************************************" + Environment.NewLine);
                Console.WriteLine("Enter the amount to withdraw");

                input = Console.ReadLine();

                checkInputAmount();

                Console.WriteLine("Do you want to withdraw amount having all types of available notes? y/n");
                input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    vendAllNotestype = true;
                }
                if (amount > 0)
                {
                    if (vendAllNotestype && amount >= 2800)
                    {
                        count2000 += 1;
                        count500 += 1;
                        count200 += 1;
                        count100 += 1;

                        int sum = (2000 * count2000) + (500 * count500) + (200 * count200) + (100 * count100);
                        amount -= sum;
                    }
                    else if (vendAllNotestype && amount >= 800 && amount < 2000)
                    {
                        count500 += 1;
                        count200 += 1;
                        count100 += 1;

                        int sum = (500 * count500) + (200 * count200) + (100 * count100);
                        amount -= sum;
                    }
                    else if (vendAllNotestype && amount >= 300 && amount < 800)
                    {
                        count200 += 1;
                        count100 += 1;

                        int sum = (200 * count200) + (100 * count100);
                        amount -= sum;
                    }
                    else if (vendAllNotestype && amount >= 100 && amount < 300)
                    {
                        count100 += 1;

                        int sum = (100 * count100);
                        amount -= sum;
                    }

                    findNotes();

                }

                StringBuilder sb = new StringBuilder();
                sb.Append(Environment.NewLine);
                sb.Append("vending following currency notes");
                sb.Append(Environment.NewLine);

                printNotes(sb);

                Console.WriteLine(sb.ToString());

                Console.WriteLine("Do you wanrt to withdraw more? y/n");
                input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    amount = 0;
                    count2000 = 0; count500 = 0; count200 = 0; count100 = 0;
                    vendAllNotestype = false;
                    continueLoop = true;
                    Console.Clear();
                }
                else
                {
                    continueLoop = false;
                }


            } while (continueLoop);


            //FACTORY METHOD - These below are Subclasses whose instance can be created in the Main class. 

            void checkInputAmount()

            {
                // SINGLETON PATTERN. Default constructor to ensure only one instance of the class can be created.

                static void checkInputAmount()
                {

                }

                //convert the input in a decimal

                decimal.TryParse(input, out decimal amt);
                if (amt % 100 != 0)
                {
                    Console.WriteLine("Enter the amoiunt in multiples of 100");
                    input = Console.ReadLine();
                    checkInputAmount();
                }
                else
                {
                    amount = amt;
                }
            }

            void findNotes()
            {

                // SINGLETON PATTERN. Default constructor to ensure only one instance of the class can be created.

                static void findNotes()
                {

                }

                //loop through all items of array


                for (int i = 0; i < notes.Length; i++)
                {
                    //find the best note
                    if (notes[i] <= amount)
                    {
                        decimal quotient = Convert.ToDecimal(amount / notes[i]);
                        decimal fraction = quotient - Math.Truncate(quotient);

                        updateNoteCount(notes[i], ((int)quotient));
                        amount -= (notes[i] * ((int)quotient));

                        if (fraction > 0 && fraction < 1)
                        {
                            findNotes();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            void updateNoteCount(int v, int count)
            {
                switch (v)
                {
                    case 2000:
                        count2000 += count;
                        break;
                    case 500:
                        count500 += count;
                        break;
                    case 200:
                        count200 += count;
                        break;
                    case 100:
                        count100 += count;
                        break;
                }
            };

            void printNotes(StringBuilder sb)
            {

                decimal total = default;

                if (count2000 != 0)
                {
                    sb.Append($"2000 x {count2000} = {2000 * count2000}");
                    total += 2000 * count2000;
                    sb.Append(Environment.NewLine);
                }
                if (count500 != 0)
                {
                    sb.Append($"500 x {count500} = {500 * count500}");
                    total += 500 * count500;
                    sb.Append(Environment.NewLine);
                }
                if (count200 != 0)
                {
                    sb.Append($"200 x {count200} = {200 * count200}");
                    total += 200 * count200;
                    sb.Append(Environment.NewLine);


                }
                if (count100 != 0)
                {
                    sb.Append($"100 x {count100} = {100 * count100}");
                    total += 100 * count100;
                    sb.Append(Environment.NewLine);


                }
                sb.Append(Environment.NewLine);
                sb.Append("****************************" + Environment.NewLine);
                sb.Append($"Total withdrawal amount: {total}" + Environment.NewLine);
                sb.Append("****************************" + Environment.NewLine);
            }
        }
    }
}
