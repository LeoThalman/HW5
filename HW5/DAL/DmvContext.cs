using HW5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    /// <summary>
    /// Class to link model file to database
    /// </summary>
    public class DmvContext :DbContext
    {
        public DmvContext() : base("name=DmvDBContext")
        {}

            public virtual DbSet<DMV> DMVs { get; set; }
    }
}