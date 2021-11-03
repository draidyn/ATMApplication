// <copyright file="Program.cs" company="Andrew Chimbanga">
// Copyright (c) Andrew Chimbanga. All rights reserved.
// </copyright>

namespace ATMApplication
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// Main driver of the ATM program. Represents the software running on the physical ATM.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main driver of the program.
        /// </summary>
        /// <param name="args">Arguments passed by the terminal.</param>
        public static void Main(string[] args)
        {
            Package packet = GeneratePackageOfAccounts(); // generates the wallet with a list of debit cards.

            List<DebitCard> listOfUsersCards = packet.Wallet;
            List<Account> listOfAccounts = packet.Accounts;

            DebitCard usersSelectedDebitCard = SelectCard(listOfUsersCards);
            Account customerAccount = VerifyPIN(listOfAccounts, usersSelectedDebitCard);

            if (customerAccount != null)
            { // if true.
                bool looper = true; // if true, while loop continues.
                string transactionType; // initialization for the type of transaction selected by user.
                while (looper)
                {
                    // 8-11 Select transaction type
                    transactionType = GetTransactionType();

                    switch (transactionType)
                    {
                        case "1": // deposit
                            customerAccount = Deposit(customerAccount); // send to deposit method for processing

                            Console.WriteLine("\nProcessing cash...\n");
                            Thread.Sleep(5000);
                            ReceiptPrompt(customerAccount);
                            looper = CheckContinue(); // check if user wants another transaction
                            break;

                        case "2": // withdraw
                            customerAccount = Withdraw(customerAccount); // send to withdraw method for processing

                            ReceiptPrompt(customerAccount);
                            Console.WriteLine("\nDispensing cash...\n");
                            Thread.Sleep(5000);
                            Console.WriteLine("Cash Dispensed");
                            Thread.Sleep(1000);

                            looper = CheckContinue();
                            break;

                        case "3": // check account balance
                            Console.WriteLine(customerAccount.Balance);
                            looper = CheckContinue();
                            break;

                        case "4": // user wants to exit.
                            looper = false;
                            break;
                    }

                    listOfAccounts = UpdateAccounts(customerAccount, listOfAccounts);
                }

                Console.WriteLine("\nEJECTING CARD...\n");
                Thread.Sleep(3000);

                // receipt and card back
                Console.WriteLine("CARD EJECTED");
            }
            else
            {
                Console.WriteLine("Wrong PIN entered. Ending session\n*CARD EJECTED*");
            }
        }

        /// <summary>
        /// Updates the customers account in the accounts list with new balance.
        /// </summary>
        /// <param name="customerAccount">customer account containing all the information about updated account.</param>
        /// <param name="listOfAccounts">List of customers accounts.</param>
        /// <returns>Updated list.</returns>
        private static List<Account> UpdateAccounts(Account customerAccount, List<Account> listOfAccounts)
        {
            foreach (Account account in listOfAccounts)
            {
                // check whether the accounts are equal. Could be better implemented by initializing an
                // equals method to compare accounts in account class.
                if (customerAccount.BankName.Equals(customerAccount.BankName) &&
                        customerAccount.AccountNumber.Equals(customerAccount.AccountNumber)
                        && customerAccount.AccountHolderName.Equals(customerAccount.AccountHolderName))
                {
                    customerAccount.Balance = customerAccount.Balance;
                }
            }

            return listOfAccounts;
        }

        /// <summary>
        /// Prompts user for withdrawal ammount. Checks if response is less than available balance. Subtracts response from current balance
        /// and returns the current updated balance.
        /// </summary>
        /// <param name="customerAccount">Customer account to process.</param>
        /// <returns>New updated balance.</returns>
        private static Account Withdraw(Account customerAccount)
        {
            Console.WriteLine("Withdrawal amount : $");
            double response = double.Parse(Console.ReadLine());
            double curr_balance = double.Parse(customerAccount.Balance);

            // if withdraw amount is larger than available funds, reject.
            if (response > curr_balance)
            {
                Console.WriteLine("Cannot complete withraw: Insufficient funds");
            }
            else
            {
                string updated_balance = string.Format("%.2f", curr_balance - response);
                customerAccount.Balance = updated_balance;
            }

            return customerAccount;
        }

        /// <summary>
        /// Checks whether the user wants to continue making transactions.
        /// </summary>
        /// <returns>Users response.</returns>
        private static bool CheckContinue()
        {
            Console.WriteLine("Would you like to make another transaction?\n1 : YES\n2 : NO");
            string response = Console.ReadLine();
            if (response.Equals("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void ReceiptPrompt(Account cust_account)
        {
            Console.WriteLine("Would you like a receipt?\n1 : YES\n2 : NO");
            string response = Console.ReadLine();

            if (response.Equals("1"))
            {
                Console.WriteLine("\nprinting receipt...\n");
                Thread.Sleep(5000);
                string acc_num = cust_account.AccountNumber;
                Console.WriteLine("Account number : *****");
                Console.WriteLine(cust_account.AccountNumber.Substring(acc_num.Length - 4, acc_num.Length - 1));
                Console.WriteLine("Current balance : $" + cust_account.Balance);
                Thread.Sleep(1000);
            }
}

        /// <summary>
        /// Carries out the deposit by updating customers account with the new balance.
        /// </summary>
        /// <param name="customerAccount">Account to be updated.</param>
        /// <returns>Customers account.</returns>
        private static Account Deposit(Account customerAccount)
        {
            Console.Write("Deposit amount : $");
            double response = double.Parse(Console.ReadLine());
            double curr_balance = double.Parse(customerAccount.Balance);
            customerAccount.Balance = string.Format("%.2f", curr_balance + response);

            return customerAccount;
        }

        /// <summary>
        /// Prompts the user for a transaction type.
        /// </summary>
        /// <returns>Returns users response.</returns>
        private static string GetTransactionType()
        {
            Console.WriteLine("Please select transaction type");
            Console.WriteLine("1 : Deposit\n2 : Withdrawal\n3 : Check balance\n4 : Exit");
            return Console.ReadLine();
        }

        /// <summary>
        /// Verifies the pin number user enters with the cards pin number.
        /// </summary>
        /// <param name="accounts">List of all the accounts.</param>
        /// <param name="card">The users selected card.</param>
        /// <returns>Whether the entered pin matches the cards pin.</returns>
        private static Account VerifyPIN(List<Account> accounts, DebitCard card)
        {
            Console.Write("Enter PIN Number: ");
            string response = Console.ReadLine();

            foreach (Account cust_account in accounts)
            {
                if (cust_account.BankName.Equals(card.BankName) &&
                        cust_account.AccountNumber.Equals(card.AccountNumber))
                {
                    if (cust_account.PIN.Equals(response))
                    {
                        return cust_account;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Prompts the ser for a card selection out of their wallet.
        /// </summary>
        /// <param name="wallet">List of the users debit cards.</param>
        /// <returns>Selected Debit card.</returns>
        private static DebitCard SelectCard(List<DebitCard> wallet)
        {
            Console.WriteLine("Select card to insert into the ATM?");
            for (int x = 0; x < wallet.Count; x++)
            {
                Console.WriteLine(x + 1 + " : " + wallet[x].BankName);
            }

            Console.WriteLine(); // for spacing.

            string response = Console.ReadLine(); // response has to be a valid, available integer.

            // parse the response as an integer and return the card at the index location selected.
            return wallet[int.Parse(response) - 1];
        }

        /// <summary>
        /// Generates the wallet with the given card information, and the accounts associated with the debit cards.
        /// </summary>
        /// <returns>Package containing debit cards and accounts.</returns>
        private static Package GeneratePackageOfAccounts()
        {
            List<DebitCard> wallet = new ();
            List<Account> accounts = new ();

            StreamReader br = new ("Accounts.txt");
            string line;

            br.ReadLine(); // ignores the header row of the text file.

            // create debitCard objects for every line in the text file.
            while ((line = br.ReadLine()) != null)
            {
                string[] info = line.Split("-");
                string bank_name = info[0];
                string cust_name = info[1];
                string card_num = info[2];
                string account_num = info[3];
                string pin = info[4];
                string balance = info[5];

                // create an account with the given information.
                Account account = new (cust_name, account_num, balance, bank_name, card_num, pin);
                accounts.Add(account);

                // create debit card with given information.
                DebitCard card = new (bank_name, cust_name, card_num, account_num);
                wallet.Add(card); // add debit card to wallet.
            }

            // To get around the one return variable constraint, package is a custom class that allows for the
            // return of both the accounts and the debit cards.
            Package packet = new (wallet, accounts);

            br.Close();
            return packet;
        }
    }
}
