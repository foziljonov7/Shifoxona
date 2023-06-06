using System.Text.RegularExpressions;
public class Print
{
    Queue queeMethod = new Queue("", "");
    public void CheckOut(string str)
    {
        if (int.TryParse(str, out int tanlanganSon))
        {
            if (tanlanganSon == 1)
            {
            repeatFio:
                Console.WriteLine("Navbatga qo'shishni tanladingiz.");
                Console.WriteLine();
                Console.Write("Ismni kiriting: ");
                var fio = Console.ReadLine();
                bool ckFio = CheckFio(fio);
                if (ckFio)
                {
                repeatPhoneNumber:
                    Console.Write("Telefon raqamni kiriting: +998 ");
                    var phoneNumber = Console.ReadLine();
                    var checkPhoneNumber = IsValidPhone(phoneNumber);
                    if (checkPhoneNumber)
                    {
                        queeMethod.AddQueue((fio), "+998 " + phoneNumber);
                        Console.WriteLine($"{fio} navbatga qo'shildi .");

                        QueeList();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Telefon raqam +998 XX XXX XX XX formatda bo'lishi shart!");
                        Console.WriteLine();
                        goto repeatPhoneNumber;

                    }

                }
                else
                {
                    goto repeatFio;
                }
            }
            else if (tanlanganSon == 2)
            {
                Console.WriteLine();
                if (queeMethod.IfExitQueue())
                {
                    queeMethod.ListQueue();
                    QueeList();
                }
                else
                {
                    Console.WriteLine("Navbatda hech kim yo'q! ");
                    QueeList();
                }
            }
            else if (tanlanganSon == 3)
            {
                Console.WriteLine();
                if (queeMethod.IfExitQueue())
                {
                    queeMethod.NextQueue();
                    QueeList();
                }
                else
                {
                    Console.WriteLine("Navbatda hech kim yo'q! ");
                    QueeList();
                }
            }
            else if (tanlanganSon == 4)
            {
                Console.WriteLine();
                if (queeMethod.IfExitQueue())
                {
                    queeMethod.AcceptQueue();
                    QueeList();
                }
                else
                {
                    Console.WriteLine("Navbatda hech kim yo'q! ");
                    QueeList();
                }
            }
            else if (tanlanganSon == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Dastur yopildi !");
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Noto'g'ri tanlov! Qayta urining.");
            Console.WriteLine();
            QueeList();
        }
    }

    public bool IsValidPhone(string Phone)
    {
        if (string.IsNullOrEmpty(Phone))
            return false;
        var r = new Regex(@"^\(?[0-9]{2}\)?[' ']?[0-9]{3}[' ']?[0-9]{2}[' ']?[0-9]{2}$");
        return r.IsMatch(Phone);
    }
    public bool CheckFio(string fio)
    {
        if (fio.Length > 4 && fio.Length < 21)
        {
            return true;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Ism 5~20 belgidan iborat bo'lishi kerak");
            Console.WriteLine();
            return false;
        }
    }
    public void QueeList()
    {
        Console.WriteLine();
        Console.WriteLine("------------- NAVBAT -------------");
        Console.WriteLine("Kerakli menuni tanlang!");
        Console.WriteLine("1. Navbatga qo'shish");
        Console.WriteLine("2. Navbatni ko'rish");
        Console.WriteLine("3. Keyingi odamni ko'rish");
        Console.WriteLine("4. Keyingi odamni qabul qilish");
        Console.WriteLine("0. Chiqib ketish");
        Console.WriteLine("----------------------------------");
        Console.Write("Tanlang: ");
        var read = Console.ReadLine();
        CheckOut(read);
    }
}