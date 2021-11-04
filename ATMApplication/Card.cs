// <copyright file="DebitCard.cs" company="Andrew Chimbanga">
// Copyright (c) Andrew Chimbanga. All rights reserved.
// </copyright>

namespace ATMApplication
{
    using System;

    /// <summary>
    /// Default Debit card constructor.
    /// </summary>
    internal class Card
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebitCard"/> class.
        /// Default constuctor for the Debit card.
        /// </summary>
        /// <param name="bankName">Banks name.</param>
        /// <param name="customerName">Customers name.</param>
        /// <param name="cardNumber">Card number.</param>
        /// <param name="accountNumber">account number.</param>
        internal Card(string bankName, string customerName, string cardNumber, string accountNumber)
        {
            this.BankName = bankName;
            this.CardNumber = cardNumber;
            this.CustomerName = customerName;
            this.AccountNumber = accountNumber;
        }

        /// <summary>
        /// Gets or sets the customers name.
        /// </summary>
        internal string CustomerName { get; private set; }

        /// <summary>
        /// Gets or sets the bank name.
        /// </summary>
        internal string BankName { get; private set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        internal string CardNumber { get; private set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        internal string AccountNumber { get; private set; }
    }
}
