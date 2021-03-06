﻿using System;

namespace Binance
{
    /// <summary>
    /// A abstract trade class.
    /// </summary>
    public abstract class Trade : IChronological
    {
        #region Public Properties

        /// <summary>
        /// Get the symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Get the trade ID.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Get the price.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Get the quantity.
        /// </summary>
        public decimal Quantity { get; }

        /// <summary>
        /// Get the trade timestamp.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Get flag indicating if the trade was the best price match.
        /// </summary>
        public bool IsBestPriceMatch { get; }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="id">The trade ID.</param>
        /// <param name="price">The price.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="isBestPriceMatch">Flag indicating if the trade was the best price match.</param>
        protected Trade(
            string symbol,
            long id,
            decimal price,
            decimal quantity,
            long timestamp,
            bool isBestPriceMatch)
        {
            Throw.IfNullOrWhiteSpace(symbol, nameof(symbol));

            if (id < 0)
                throw new ArgumentException($"{nameof(Trade)}: ID must not be less than 0.", nameof(id));
            if (price < 0)
                throw new ArgumentException($"{nameof(Trade)}: price must not be less than 0.", nameof(price));
            if (quantity <= 0)
                throw new ArgumentException($"{nameof(Trade)}: quantity must be greater than 0.", nameof(quantity));
            if (timestamp <= 0)
                throw new ArgumentException($"{nameof(Trade)}: timestamp must be greater than 0.", nameof(timestamp));

            Symbol = symbol;
            Id = id;
            Price = price;
            Quantity = quantity;
            Timestamp = timestamp;
            IsBestPriceMatch = isBestPriceMatch;
        }

        #endregion Constructors
    }
}
