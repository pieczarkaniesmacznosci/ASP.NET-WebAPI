using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UD_WebAPI_Course.Data
{
    using System.Data.Entity;

    using UD_WebAPI_Course.Models;

    public class QuotesDbContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
    }
}