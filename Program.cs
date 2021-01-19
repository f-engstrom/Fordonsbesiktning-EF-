using System;
using System.Linq;
using System.Threading;
using Fordonsbesiktning_EF_.Data;
using Fordonsbesiktning_EF_.Models;
using static System.Console;

namespace Fordonsbesiktning_EF_
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Menu();

        }

        static void Menu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Clear();


                WriteLine("1. Ny Reservation");
                WriteLine("2. Lista Reservationer");
                WriteLine("3. Utför besiktning");
                WriteLine("4. Lista besiktningar");
                WriteLine("5. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);


                switch (keyPressed.Key)
                {

                    case ConsoleKey.D1:

                        Clear();
                        CreateReservation();

                        break;

                    case ConsoleKey.D2:

                        Clear();
                        ListReservations();

                        break;

                    case ConsoleKey.D3:

                        Clear();
                        PerformInspection();

                        break;

                    case ConsoleKey.D4:

                        Clear();
                        ListInspections();

                        break;

                    case ConsoleKey.D5:

                        shouldNotExit = false;

                        break;




                }

            }
        }

        private static void ListInspections()
        {

            using FordonsBesiktningContext context = new FordonsBesiktningContext();

            var Inspections = context.Inspections;

            WriteLine("Fordon        Utfört datum        Resultat");
            WriteLine(" ".PadLeft(50, '-'));

            string resultat;

            foreach (var inspection in Inspections)
            {
                if (inspection.Passed)
                {
                    resultat = "Godkänd";
                }
                else
                {
                    resultat = "Ej godkänd";
                }

                WriteLine($"{inspection.RegistrationNumber}        {inspection.PerformedAt}         {resultat}");

            }

            ReadKey();


        }

        private static void PerformInspection()
        {



            bool reservationExists = false;

            WriteLine("Registreringsnummer: ");
            string registrationNumber = ReadLine();

            using FordonsBesiktningContext context = new FordonsBesiktningContext();


            var correctReservation = context.Reservations.Where(r => r.RegistrationNumber == registrationNumber);


            foreach (var reservation in correctReservation)
            {


                if (reservation.RegistrationNumber == registrationNumber)
                {
                    reservationExists = true;

                }


            }

            if (reservationExists)
            {
                bool incorrectKey = true;

                Console.WriteLine("Fordonet godkänt? (J)a eller (N)ej");

                ConsoleKeyInfo inputKey;
                do
                {

                    inputKey = ReadKey(true);

                    incorrectKey = !(inputKey.Key == ConsoleKey.J || inputKey.Key == ConsoleKey.N);



                } while (incorrectKey);

                Inspection inspection = new Inspection(registrationNumber);
              

                if (inputKey.Key == ConsoleKey.J)
                {
                    inspection.Pass();
                    

                    context.Inspections.Add(inspection);

                    WriteLine("Inspektion godkänd");
                    Thread.Sleep(1000);
                    context.SaveChanges();

                }

                if (inputKey.Key == ConsoleKey.N)
                {
                    inspection.Fail();


                    context.Inspections.Add(inspection);

                    WriteLine("Inspektion Ej godkänd");
                    Thread.Sleep(1000);
                    context.SaveChanges();
                }


            }
            else
            {
                Console.WriteLine("Reservation saknas");
                Thread.Sleep(1000);

            }



        }

        private static void ListReservations()
        {

            using FordonsBesiktningContext context = new FordonsBesiktningContext();

            var reservations = context.Reservations;


            WriteLine("Id        Fordon        Datum");
            WriteLine(" ".PadLeft(50, '-'));

            foreach (var reservation in reservations)
            {

                WriteLine($"{reservation.Id}        {reservation.RegistrationNumber}         {reservation.Date}");

            }

            ReadKey();

        }

        private static void CreateReservation()
        {


            bool incorrectKey = true;
            bool doNotExitLoop = true;

            do
            {

                SetCursorPosition(5, 7);
                WriteLine("Registreringsnummer: ");
                SetCursorPosition(5, 9);
                WriteLine("Datum (yyy-MM-dd hh:mm): ");
                SetCursorPosition("Registreringsnummer: ".Length + 4, 7);
                string registrationNumber = ReadLine();
                SetCursorPosition("Datum (yyy-MM-dd hh:mm): ".Length + 4, 9);
                DateTime dateTimeReservation = DateTime.Parse(ReadLine());

                Console.WriteLine("Är detta korrekt? (J)a eller (N)ej");

                ConsoleKeyInfo inputKey;
                do
                {

                    inputKey = ReadKey(true);

                    incorrectKey = !(inputKey.Key == ConsoleKey.J || inputKey.Key == ConsoleKey.N);



                } while (incorrectKey);


                if (inputKey.Key == ConsoleKey.J)
                {
                    using FordonsBesiktningContext context = new FordonsBesiktningContext();


                    Reservation reservation = new Reservation(registrationNumber,dateTimeReservation);



                    context.Reservations.Add(reservation);
                    context.SaveChanges();

                    doNotExitLoop = false;
                    Clear();
                    WriteLine("Reservation utförd");
                    Thread.Sleep(1000);
                }

                Clear();


            } while (doNotExitLoop);


        }
    }
}
