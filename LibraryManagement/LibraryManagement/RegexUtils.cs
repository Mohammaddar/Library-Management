using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LibraryManagement
{
    //
    class RegexUtils
    {
        public static bool checkName(string name)
        {
            try
            {
                string nameRegex = @"^[a-z]{3,32}$";
                Regex regex = new Regex(nameRegex);
                if (regex.IsMatch(name))
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
        }

        public static bool checkMail(string email)
        {
            try
            {
                string emailRegex = @"^[a-zA-Z0-9_-]{1,32}@[a-zA-Z0-9]{1,8}\.[a-zA-Z]{1,3}$";
                Regex regex = new Regex(emailRegex);
                if (regex.IsMatch(email))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool checkPhoneNumber(string phone)
        {
            try
            {
                string phoneregex = @"^[0]{1}[9]{1}[0-9]{9}$";
                Regex regex = new Regex(phoneregex);
                if (regex.IsMatch(phone)) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool checkPassword(string password)
        {
            try
            {
                string passwordRegex = @"^(?=.*[A-Z])[a-zA-Z0-9]{8,32}$";
                Regex regex = new Regex(passwordRegex);
                if (regex.IsMatch(password)) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool checkCvv(string cvv)
        {
            try
            {
                string cvvRegex = @"^[0-9]{3,4}$";
                Regex regex = new Regex(cvvRegex);
                if (regex.IsMatch(cvv)) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool checkCardNumber(long cardnumber)
        {
            try
            {
                if (countDigit(cardnumber) == 16)
                {
                    List<int> numbers = new List<int>();
                    for (int i = 0; i < 16; i++)
                    {
                        numbers.Add((int)(cardnumber % 10));
                        cardnumber = cardnumber / 10;
                    }

                    for (int i = 0; i < 16; i++)
                    {
                        if (i % 2 != 0)
                        {
                            numbers[i] = numbers[i] * 2;
                            if (numbers[i] >= 10)
                            {
                                numbers[i] = numbers[i] % 10 + (numbers[i] / 10) % 10;
                            }
                        }
                    }

                    int sum = 0;
                    foreach (var number in numbers)
                    {
                        sum += number;
                    }

                    if (sum % 10 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        //true cart tarikh engheza dare false nadare
        public static bool checkExpiration(int year, int month)
        {
            try
            {
                int remainingDays = (int)(DateTime.Now - new DateTime(year, month, 01)).TotalDays;
                if (remainingDays < 120 && remainingDays >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static int countDigit(long n)
        {
            int count = 0;
            while (n != 0)
            {
                n = n / 10;
                ++count;
            }
            return count;
        }
    }
}
