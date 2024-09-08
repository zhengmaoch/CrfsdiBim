﻿using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;

namespace CrfsdiBim.Data;

public class SQLiteConfiguration : DbConfiguration
{
    public SQLiteConfiguration()
    {
        SetDefaultConnectionFactory(new SQLiteConnectionFactory());
        SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
        SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);

        var providerServices = (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices));
        SetProviderServices("System.Data.SQLite", providerServices);
        SetProviderServices("System.Data.SQLite.EF6", providerServices);
    }
}