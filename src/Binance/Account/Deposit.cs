﻿using System;

namespace Binance.Account
{
    public sealed class Deposit : IChronological
    {
        #region Public Properties

        /// <summary>
        /// Get the asset.
        /// </summary>
        public string Asset { get; }

        /// <summary>
        /// Get the amount.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Get the insert time.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Get the status.
        /// </summary>
        public DepositStatus Status { get; }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="status">The status.</param>
        public Deposit(string asset, decimal amount, long timestamp, DepositStatus status)
        {
            Throw.IfNullOrWhiteSpace(asset, nameof(asset));

            if (amount <= 0)
                throw new ArgumentException($"{nameof(Deposit)} amount must be greater than 0.", nameof(amount));
            if (timestamp <= 0)
                throw new ArgumentException($"{nameof(Deposit)} timestamp must be greater than 0.", nameof(timestamp));

            Asset = asset;
            Amount = amount;
            Timestamp = timestamp;
            Status = status;
        }

        #endregion Constructors
    }
}
