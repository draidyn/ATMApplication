// <copyright file="Account.cs" company="Andrew Chimbanga">
// Copyright (c) Andrew Chimbanga. All rights reserved.
// </copyright>

namespace ATMApplication
{
    using System;

    /// <summary>
    /// Account class.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="customerName">Customers name.</param>
        /// <param name="accountNumber">Account number.</param>
        /// <param name="balance2">Account balance.</param>
        /// <param name="bankName">Banks name.</param>
        /// <param name="cardNumber">Card Number.</param>
        /// <param name="pin">Card Pin.</param>
        public Account(string customerName, string accountNumber, string balance2, string bankName, string cardNumber, string pin)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance2;
            this.CustomerName = customerName;
            this.BankName = bankName;
            this.CardNumber = cardNumber;
            this.PIN = pin;
        }

        /// <summary>
        /// Gets or sets the accounts balance.
        /// </summary>
        public string Balance { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the bannk name of the account.
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the account holder.
        /// </summary>
        public string AccountHolderName { get; set; }

        /// <summary>
        /// Gets or sets the accounts pin number.
        /// </summary>
        public string PIN { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }
    }
}
