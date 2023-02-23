//A race condition occurs in a multithreaded program when two or more threads try to access and modify the same shared resource simultaneously. This can lead to unpredictable and incorrect behavior, as the order in which the threads execute their operations can be different each time the program runs. To avoid race conditions, we can use synchronization techniques such as locks, semaphores, and monitors.

//Here's an example of a race condition in C# code:

using System;
namespace Abc
{


    class BankAccount
    {
        private int balance;

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            balance -= amount;
        }

        public int GetBalance()
        {
            return balance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    account.Deposit(10);
                }
            });
            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    account.Withdraw(10);
                }
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Final balance: " + account.GetBalance());
        }
    }
}


//explaination:

//In this example, we have a BankAccount class with three methods: Deposit, Withdraw, and GetBalance.The Deposit and Withdraw methods modify the balance field, which is a shared resource.We also have two threads that call these methods in a loop, each performing 10,000 operations.

//If we run this program multiple times, we may get different final balances, which indicates a race condition.This is because the Deposit and Withdraw methods are not synchronized, so both threads can access and modify the balance field simultaneously, leading to unexpected behavior.

//To avoid this race condition, we can use the lock keyword to synchronize access to the balance field:


//To avoid this race condition


//using System;
//namespace Abcde
//{
//    class BankAccount
//    {
//        private int balance;
//        private object balanceLock = new object();

//        public void Deposit(int amount)
//        {
//            lock (balanceLock)
//            {
//                balance += amount;
//            }
//        }

//        public void Withdraw(int amount)
//        {
//            lock (balanceLock)
//            {
//                balance -= amount;
//            }
//        }

//        public int GetBalance()
//        {
//            lock (balanceLock)
//            {
//                return balance;
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            BankAccount account = new BankAccount();
//            Thread thread1 = new Thread(() => {
//                for (int i = 0; i < 10000; i++)
//                {
//                    account.Deposit(10);
//                }
//            });
//            Thread thread2 = new Thread(() => {
//                for (int i = 0; i < 10000; i++)
//                {
//                    account.Withdraw(10);
//                }
//            });

//            thread1.Start();
//            thread2.Start();

//            thread1.Join();
//            thread2.Join();

//            Console.WriteLine("Final balance: " + account.GetBalance());
//        }
//    }
//}




//final explaination avoidance of race condition:
//In this modified code, we use an object called balanceLock to synchronize access to the balance field. The lock statement ensures that only one thread can enter a block of code at a time, preventing multiple threads from modifying the balance field simultaneously.

//With this synchronization technique in place, we can be sure that the balance field is accessed and modified correctly, and we no longer have a race condition.