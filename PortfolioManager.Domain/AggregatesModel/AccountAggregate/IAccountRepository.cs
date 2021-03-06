﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.Domain.SeedWork;

namespace PortfolioManager.Domain.AggregatesModel.AccountAggregate
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account Add(Account account);
        StockHolding AddStockHolding(StockHolding stockHolding);
        Task<Account> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Account account);
    }
}
