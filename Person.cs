using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;


namespace WpfApp1
{
    class Person
    {
        private static readonly string[] Zodiacs =
       {
            "Водолій",
            "Риби",
            "Овен",
            "Телець",
            "Близнюки",
            "Рак",
            "Лев",
            "Діва",
            "Терези",
            "Скорпіон",
            "Стрілець",
            "Козеріг"
        };
        private static readonly string[] ChineseZodiacs =
        {
            "Щур",
            "Віл",
            "Тигр",
            "Кролик",
            "Дракон",
            "Змія",
            "Кінь",
            "Коза",
            "Мавпа",
            "Півень",
            "Собака",
            "Свиня"
        };
        public string name { get; }
        public string surname { get; }
        public string email { get; }
        public DateTime? dateOfBirth { get; }
        const int adult_age = 18;


        public Person(string _name, string _surname, string _email, DateTime? _dateOfBirth)
        {
            name = _name;
            surname = _surname;
            email = _email;
            dateOfBirth = _dateOfBirth;

            return;
        }

        public Person(string _name, string _surname, DateTime? _dateOfBirth)
        {
            name = _name;
            surname = _surname;
            email = null;
            dateOfBirth = _dateOfBirth;
        }
        public Person(string _name, string _surname, string _email)
        {
            name = _name;
            surname = _surname;
            email = _email;
        }

        public string IsAdult
        {
            get
            {
                var b_rick = dateOfBirth?.Year;
                var b_mon = dateOfBirth?.Month;
                var b_day = dateOfBirth?.Day;
                var t_rick = (DateTime.Today).Year;
                var t_mon = (DateTime.Today).Month;
                var t_day = (DateTime.Today).Day;
                var k = (t_rick * 100 + t_mon) * 100 + t_day;
                var n = (b_rick * 100 + b_mon) * 100 + b_day;
                string mes = "";

                if ((k - n) / 10000 >= 18)
                {
                    mes = "Повнолітня";
                }
                else
                {
                    mes = "Неповнолітня";
                }
                return mes;
            }
        }
        public string SunSign
        {
            get
            {
                var day = dateOfBirth?.Day ?? DateTime.Today.DayOfYear;
                var month = dateOfBirth?.Month ?? DateTime.Today.Month;

                switch (month)
                {
                    case 1:
                    case 4:
                        return day >= 20 ? Zodiacs[month - 1] : month == 1 ? Zodiacs[Zodiacs.Length - 1] : Zodiacs[month - 2];
                    case 2:
                        return day >= 19 ? Zodiacs[month - 1] : Zodiacs[month - 2];
                    case 3:
                    case 5:
                    case 6:
                        return day >= 21 ? Zodiacs[month - 1] : Zodiacs[month - 2];
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        return day >= 23 ? Zodiacs[month - 1] : Zodiacs[month - 2];
                    default:
                        return day >= 22 ? Zodiacs[month - 1] : Zodiacs[month - 2];
                }
            }
        }



        public string ChineseSign
        {
            get
            {
                var year = dateOfBirth?.Year ?? DateTime.Today.Year;
                return ChineseZodiacs[(year - 5) % 12];
            }
        }

        public bool IsBirthday => dateOfBirth?.DayOfYear == DateTime.Today.DayOfYear;

        private static void CheckDate(DateTime date)
        {
            if (DateTime.Today < date
                || (DateTime.Today.Year - date.Year >= 135))
            {
                throw new DateError(date);
            }
        }
        private static void CheckEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new EmailError(email);
            }

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {

                    var idn = new IdnMapping();


                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return null;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                throw new EmailError(email);
            }
            catch (ArgumentException e)
            {
                throw new EmailError(email);
            }
            try
            {
                Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                throw new EmailError(email);
            }
        }
    }
}
