// <copyright file="Account.cs" company="Andrew Chimbanga">
// Copyright (c) Andrew Chimbanga. All rights reserved.
// </copyright>

namespace ATMApplication
{
    using System;

    /// <summary>
    /// Account class.
    /// </summary>
    internal class Account
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
        internal Account(string customerName, string accountNumber, string balance2, string bankName, string cardNumber, string pin)
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
        internal string Balance { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        internal string AccountNumber { get; private set; }

        /// <summary>
        /// Gets or sets the bannk name of the account.
        /// </summary>
        internal string BankName { get; private set; }

        /// <summary>
        /// Gets or sets the account holder.
        /// </summary>
        internal string AccountHolderName { get; private set; }

        /// <summary>
        /// Gets or sets the accounts pin number.
        /// </summary>
        internal string PIN { get; private set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        internal string CardNumber { get; private set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        internal string CustomerName { get; private set; }
    }
}
