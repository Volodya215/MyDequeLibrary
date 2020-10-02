using Nito.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDegueLibrary;

namespace TrackLab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо дек
            MyDeque<int> first = new MyDeque<int>(5);
            first.AddToBack(7);
            first.AddToBack(8);
            first.AddToFront(4);
            first.AddToFront(3);

            // Підписуємося на подію
            first.Notify += DisplayMessage;

            // Перевіряємо роботу foreach
            foreach (var item in first)
            {
                Console.Write(item.ToString() + "  ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 13));

            // Переглядаємо елементи
            Console.WriteLine(first.PeekBack());
            Console.WriteLine(first.PeekFront());
            Console.WriteLine(new string('-', 13));

            // Видаляємо елементи
            first.RemoveFromBack();
            first.RemoveFromFront();
            Console.WriteLine(new string('-', 13));

            // Переглядаємо зміни
            Console.WriteLine(first.PeekBack());
            Console.WriteLine(first.PeekFront());
            Console.WriteLine(new string('-', 13));

            // Конвертуємо дек в масив та перевіряємо результат
            var arr = first.ToArray();

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            // Перевіряємо розмір дека та перевіряємо чи він не пустий
            Console.WriteLine("Size = " + first.Size);
            Console.WriteLine(first.IsEmpty());
            Console.WriteLine(new string('-', 13));

            // Відписуємося від сповіщення
            first.Notify -= DisplayMessage;
            // Очищаємо дек
            first.Clear();
            Console.WriteLine(first.IsEmpty());



            try
            {
                var test = first.ToArray();

                foreach (var item in test)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.WriteLine(new string('-', 13));



            MyDeque<User> second = new MyDeque<User>();
            second.AddToBack(new User("Vova", "Dolid", "1111"));
            second.AddToBack(new User("Vasya", "Petichkin", "1111"));
            second.AddToFront(new User("Katya", "Sen", "1111"));
            second.AddToFront(new User("Jackie", "Chan", "1111"));

            //second.Notify += DisplayMessage;

            foreach (var item in second)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 13));
            second.RemoveFromBack();
            Console.WriteLine(second.PeekBack());

            Console.ReadKey();
        }

        private static void DisplayMessage(object sender, DequeEventArgs<int> e)
        {
            Console.WriteLine($"Deleted: {e.Result} from {sender.GetType()}");
        }
    }
}
