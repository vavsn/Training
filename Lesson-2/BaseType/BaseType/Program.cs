using System;
using System.Collections.Generic;

namespace BaseType
{
    public class Program
    {
        [Flags]
        public enum Месяцы
        { 
            Январь = 1,
            Февраль = 2,
            Март = 3,
            Апрель = 4,
            Май = 5,
            Июнь = 6,
            Июль = 7,
            Август = 8,
            Сентябрь = 9,
            Октябрь = 10,
            Ноябрь = 11,
            Декабрь = 12
        }

        [Flags]
        public enum WorkSchedule
        {
            // Для читаемости разряды можно разделять знаком подчёркивания.
            // Они никак не влияют на значение.
            Понедельник = 0b_0000001,
            Вторник     = 0b_0000010,
            Среда       = 0b_0000100,
            Четверг     = 0b_0001000,
            Пятница     = 0b_0010000,
            Суббота     = 0b_0100000,
            Воскресенье = 0b_1000000,
        }

        static void Main(string[] args)
        {
            // запросим данные у пользователя и обработаем их в соответствии с заданием
            WotkWithUser();

            // покажем информацию о чеке
            Check();

            // покажем расписание рабочих дней для фирмы Альфа
            Schedule("Альфа", "0011001");

            // покажем расписание рабочих дней для фирмы Омега
            Schedule("Омега", "1111001");
        }

        // поработаем с пользователем
        private static void WotkWithUser()
        {
            // string[] зимниеМесяцы = { "Январь", "Февраль", "Декабрь"};
            List<int> зимниеМесяцы = new List<int>(3) { 1, 2, 12 };

            // переменная для хранения минимальной температуры
            double minTemp;
            // переменная для хранения максимальной температуры
            double maxTemp;
            // пользователь вводит минимальную температуру
            Console.Write("Введите минимальную температуру: ");
            string Temp = Console.ReadLine();
            minTemp = Double.Parse(Temp);

            // пользователь вводит максимальную температуру
            Console.Write("Введите максимальную температуру: ");
            Temp = Console.ReadLine();
            maxTemp = Double.Parse(Temp);

            // вычислим среднюю температуру
            Double average = (minTemp + maxTemp) / 2;
            Console.WriteLine("Средняя температура = " + string.Format("{0:N2}", average));

            // попросим пользователя ввести номер месяца
            Console.Write("Введите порядковый номер месяца (1 - 12): ");
            Temp = Console.ReadLine();
            int Month = Int32.Parse(Temp);
            Console.WriteLine("Месяц = " + (Месяцы)Month);

            // какое число введено пользователем - четное или не четное?
            string число = string.Empty;
            if ((Int32.Parse(Temp) & 1) != 0)
                число = "не";
            Console.WriteLine($"Вы ввели {число}четное число");


            if ((зимниеМесяцы.Contains(Month)) & (average > 0))
                Console.WriteLine("Дождливая зима");
        }

            // определем рабочее расписание на неделю для фирмы
            // аргумент Расписание - строка из 7 чимволов. "1" указываем рабочие дни недели, "0" указываем не рабочие дни недели. Начинается неделя с понедельника
            // аргумент Фирма - название фирмы
            private static void Schedule(string Фирма, string Расписание)
        {
            Console.WriteLine();
            Console.WriteLine($"Покажем рабочее расписание фирмы {Фирма}");
            Console.WriteLine();

            char[] дни = Расписание.ToCharArray();
            // приведём к единому виду
            WorkSchedule локРасписание = 0b_0000000;
            // сформатируем расписание
            for (int i=0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        if (дни[i] == '1')
                            локРасписание = локРасписание | WorkSchedule.Понедельник;
                        break;
                    case 1:
                        if (дни[i] == '1')
                            локРасписание = локРасписание | WorkSchedule.Вторник;
                        break;
                    case 2:
                        if (дни[i] == '1')
                            локРасписание = локРасписание | WorkSchedule.Среда;
                        break;
                    case 3:
                        if (дни[i] == '1')
                            локРасписание = локРасписание | WorkSchedule.Четверг;
                        break;
                    case 4:
                        if (дни[i] == '1')
                            локРасписание = локРасписание | WorkSchedule.Пятница;
                        break;
                    case 5:
                        if (дни[i] == '1')
                            локРасписание = локРасписание | WorkSchedule.Суббота;
                        break;
                    case 6:
                        if (дни[i] == '1')
                            локРасписание = локРасписание | WorkSchedule.Воскресенье;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Расписание рабочих дней фирмы \"{Фирма}\": " + локРасписание.ToString()); /**/

        }

        // выводим информацию по чеку
        private static void Check()
        {
            string Магазин = "Игрушки";
            int количествоПокупок = 5;
            double суммаПокупок = 9549.12;

            Console.WriteLine();
            Console.WriteLine("Покажем чек из магазина");
            Console.WriteLine();

            Console.WriteLine("{0,-28}{1,10}", "Магазин: ", Магазин);
            Console.WriteLine("{0,-28}{1,10:d}", "Дата покупок: ", DateTime.Now);
            Console.WriteLine("{0,-28}{1,10}", "Количество покупок:", количествоПокупок);
            Console.WriteLine("{0,-28}{1,10}", "Общая сумма покупок, руб.: ", суммаПокупок);

        }
    }
}
