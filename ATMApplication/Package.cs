﻿// <copyright file="Package.cs" company="Andrew Chimbanga">
// Copyright (c) Andrew Chimbanga. All rights reserved.
// </copyright>

namespace ATMApplication
{
    using System.Collections.Generic;

    /// <summary>
    /// Container class that enables the return of a package class that contains the cards in the "wallet"
    /// and the accounts associated with that customers debit cards.
    /// </summary>
    internal class Package
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Package"/> class.
        /// Default constructor of the package class.
        /// </summary>
        /// <param name="wallet">Wallet that represents a list of all the debit cards.</param>
        /// <param name="accounts">All the users accounts.</param>
        internal Package(List<Card> wallet, List<Account> accounts)
        {
            this.Wallet = wallet;
            this.Accounts = accounts;
        }

        /// <summary>
        /// Gets or sets the list of debit cards in the wallet.
        /// </summary>
        /// <returns>The list of debit cards in the wallet.</returns>
        internal List<Card> Wallet { get; set; }

        /// <summary>
        /// Gets or sets the list of accounts.
        /// </summary>
        internal List<Account> Accounts { get; set; }
    }
}
