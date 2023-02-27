using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using BaiTap3;

namespace BaiTap3
{
    class Account
    {
        private string accountID;
        private int balance;
        private string firstName;
        private string lastName;
        public string AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public Account(string id, int tk, string ten, string ho)
        {
            this.accountID = id;
            this.balance = tk;
            this.FirstName = ten;
            this.lastName = ho;
        }

        public Account()
        {
            accountID = "";
            balance = 0;
            firstName = "";
            lastName = "";
        }
        public void FillInfo()
        {
            Console.Write("Nhap Account ID: ");
            accountID = Console.ReadLine();
            Console.Write("Nhap Balance: ");
            balance = Int32.Parse(Console.ReadLine());
            Console.Write("Nhap First name: ");
            firstName = Console.ReadLine();
            Console.Write("Nhap Last name: ");
            lastName = Console.ReadLine();
        }
        public void Query()
        {
            Console.WriteLine("Account ID: " +accountID + "Balance: " +balance + "First name: " +firstName + "Last name: " +lastName);
        }

    }
    public class IDcomparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Account xx = (Account)x;
            Account yy = (Account)y;
            return xx.AccountID.CompareTo(yy.AccountID);
        }
    }
    class NameComparer : IComparer
    {
        public int Compare(object a, object b)
        {
            Account a1 = (Account)a;
            Account a2 = (Account)b;
            return a1.FirstName.CompareTo(a2.FirstName);
        }

    }
    class AccountList
    {
        private ArrayList accountlist = new ArrayList();
        public void AddAccount()
        {
            Account a = new Account();
            a.FillInfo();
            accountlist.Add(a);

        }
        public void addaccount()
        {
            Account a = new Account();
            accountlist.Clear();
            Console.Write("Nhap ten file muon them account(D://tenfile.txt): ");
            string filename = Console.ReadLine();
            FileStream output = new FileStream(filename, FileMode.Append);
            StreamWriter writer = new StreamWriter(output);
            Console.Write(" Nhap so luong account muon them: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap acc thu { 0}: ", i + 1);
            a.FillInfo();
            accountlist.Add(a);
        }
            foreach (Account acc in accountlist)
            {
                writer.WriteLine("{0},{1},{2},{3}", acc.AccountID, acc.Balance, acc.FirstName, acc.LastName);

            }
    writer.Flush();
            writer.Close();
            output.Close();

        }

public void listAccount()
{
    foreach (Account acc in accountlist)
        acc.Query();
}
public void SaveFile()
{
    Console.Write("Nhap vao ten file de luu danh sach(D://tenfile.txt): ");
    string filename = Console.ReadLine();
    try
    {
        FileStream output = new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
        StreamWriter writer = new StreamWriter(output);
        foreach (Account acc in accountlist)
        {
            writer.WriteLine("{ 0},{ 1},{ 2},{ 3}", acc.AccountID, acc.Balance, acc.FirstName, acc.LastName);

                }
                writer.Close();
output.Close();
            }
            catch (IOException ex)
{
    Console.WriteLine(ex.Message);
}
        }
        public void LoadFile()
{
    Console.Write("Nhap ten file can doc danh sach(D://tenfile.txt): ");
    string filename = Console.ReadLine();
    accountlist.Clear();
    try
    {
        FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(input);
        string str;
        while ((str = reader.ReadLine()) != null)
        {
            string[] list = str.Split(',');
            Account acc = new Account(list[0], int.Parse(list[1]), list[2], list[3]);
            accountlist.Add(acc);
        }
        reader.Close();
        input.Close();
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
public void delete()
{
    Console.Write("Nhap ten file chua Account can xoa(D://tenfile.txt): ");
    string filename = Console.ReadLine();
    accountlist.Clear();
    int d = 0;
    try
    {
        FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(input);
        string str;
        Console.Write("Nhap id cua acc can xoa: ");
        string id = Console.ReadLine();
        string[] list;
        while ((str = reader.ReadLine()) != null)
        {
            list = str.Split(',');
            Account acc = new Account(list[0], int.Parse(list[1]), list[2], list[3]);
            accountlist.Add(acc);
            if (list[0] == id)
            {
                accountlist.Remove(acc);
                d++;
            }
        }
        reader.Close();
        input.Close();
    }
    catch (IOException ex)
    {
        Console.Write(ex.Message);
    }
    if (d == 0)
    {
        Console.WriteLine("Ko ton tai account");
        return;
    }
    else
    {
        FileStream output = new FileStream(filename, FileMode.Create, FileAccess.Write);
        StreamWriter writer = new StreamWriter(output);
        foreach (Account ac in accountlist)
        {
            writer.WriteLine("{ 0},{ 1},{ 2},{ 3}", ac.AccountID, ac.Balance, ac.FirstName, ac.LastName);
                }
                writer.Close();
output.Close();
Console.WriteLine("Da xoa account thanh cong ");
            }

        }
        public void SapXepID()
{
    accountlist.Sort(new IDcomparer());
}
public void SapXepTen()
{
    accountlist.Sort(new NameComparer());
}
    }

    class Program
{
    static void Main(string[] args)
    {

        AccountList accountlist = new AccountList();
        int d = 0;
        int c;
        do
        {
            Console.Write("\n————————–\n0.Thoat\n1.Them account\n2.Load account in ra man hinh\n3.Remove account\n4.Sap xep – theo ID\n5.Sap xep – theo Ten\n————————\nBan chon: ");
            c = int.Parse(Console.ReadLine());
            switch (c)
            {
                case 1:
                    {

                        if (d == 0)
                        {
                            Console.Write("Nhap so luong account muon them: ");
                            int n = int.Parse(Console.ReadLine());
                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine("Nhap acc thu {0}: ", i + 1);
                                accountlist.AddAccount();
                            }

                        accountlist.SaveFile();
                        accountlist.listAccount();
                        Console.WriteLine("Luu acc thanh cong ");
                        d++;
                    }
                            else
                    {
                        accountlist.addaccount();
                        Console.WriteLine(" Luu acc thanh cong ");

                    }
                    break;
            }
                    case 2:
                        {
                accountlist.LoadFile();
                Console.WriteLine("Danh sach account trong file");
                accountlist.listAccount();
                break;
            }
                    case 3:
                        {
                accountlist.delete();

                break;
            }
                    case 4:
                        {
                accountlist.SapXepID();
                Console.WriteLine("Danh sach account trong file sau khi sap xep");
                accountlist.listAccount();
                break;
            }
                    case 5:
                        {
                accountlist.SapXepTen();
                Console.WriteLine("Danh sach account trong file sau khi sap xep");
                accountlist.listAccount();
                break;
            }
            default:
                        Console.WriteLine("Nhap sai nhap lai");
            break;

        }
            } while (c != 0);

        }
    }
}