using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Havan.Desafio.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Havan.Desafio.DataAccess
{
    interface IDataEngine
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Remove<T>(Func<T, bool> predicate) where T : class;

    }

    public class DataEngine : IDisposable, IDataEngine
    {
        public DbContextOptions<HavanContext> ContextOptions {get; private set;} 
        public ITenantProvider TenantProvider {get; private set;}
        public HavanContext Context { get; private set; }
        public IDbContextTransaction Transaction {get; private set;}
        public IDbConnection Connection {get; private set;}

        private string connectionString = String.Empty;

        public DataEngine(DbContextOptions<HavanContext> options)
        {
            this.ContextOptions = options;
            this.Context = new HavanContext(options);
            this.Connection = this.Context.Database.GetDbConnection();  
            this.Connection.Open();  
        }
        
        public DataEngine(DbContextOptions<HavanContext> options, bool EnabledTransactionScope)
        {
            this.ContextOptions = options;
            this.Context = new HavanContext(options);
            this.Connection = this.Context.Database.GetDbConnection();  
            this.Connection.Open();
            
            if (EnabledTransactionScope)
                this.Transaction = this.Context.Database.BeginTransaction();
    
            

        }

        public DataEngine(DbContextOptions<HavanContext> options, bool EnabledTransactionScope, ITenantProvider tenantProvider)
        {
            
            this.TenantProvider = tenantProvider;
            this.ContextOptions = options;
            this.Context = new HavanContext(options, tenantProvider);
            this.Connection = this.Context.Database.GetDbConnection();  
            this.Connection.Open();
            
            if (EnabledTransactionScope)
                this.Transaction = this.Context.Database.BeginTransaction();
    
            

        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                Context.Entry(entity).State = EntityState.Added;
                Context.Add(entity);
                Context.SaveChanges();
            }
            catch (Exception err)
            {
                String errorMessage = err.Message;

                if (err.InnerException != null)
                    errorMessage += "\n InnerException: " + err.InnerException.Message;

                throw new Exception(errorMessage);
            }

        }

        public void Add<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                Context.AddRange(entities);
                Context.SaveChanges();
            }
            catch (Exception err)
            {
                String errorMessage = err.Message;

                if (err.InnerException != null)
                    errorMessage += "\n InnerException: " + err.InnerException.Message;

                throw new Exception(errorMessage);
            }

        }

        public void Update<T>(T entity) where T : class
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.Update(entity);
                Context.SaveChanges();

            }
            catch (Exception err)
            {
                String errorMessage = err.Message;

                if (err.InnerException != null)
                    errorMessage += "\n InnerException: " + err.InnerException.Message;

                throw new Exception(errorMessage);
            }
        }

        public void Update<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                Context.UpdateRange(entities);
                Context.SaveChanges();

            }
            catch (Exception err)
            {
                String errorMessage = err.Message;

                if (err.InnerException != null)
                    errorMessage += "\n InnerException: " + err.InnerException.Message;

                throw new Exception(errorMessage);
            }
        }

        public void Remove<T>(T entity) where T : class
        {
            try
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.Remove(entity);
                Context.SaveChanges();

            }
            catch (Exception err)
            {
                String errorMessage = err.Message;

                if (err.InnerException != null)
                    errorMessage += "\n InnerException: " + err.InnerException.Message;

                throw new Exception(errorMessage);
            }

        }

        public void Remove<T>(IEnumerable<T> entities) where T : class
        {
            try
            {
                Context.RemoveRange(entities);
                Context.SaveChanges();

            }
            catch (Exception err)
            {
                String errorMessage = err.Message;

                if (err.InnerException != null)
                    errorMessage += "\n InnerException: " + err.InnerException.Message;

                throw new Exception(errorMessage);
            }

        }


        public void Remove<T>(Func<T, bool> predicate) where T : class
        {
            try
            {
                var results = Context.Set<T>().Where(predicate);

                if (results != null)
                {
                    Context.RemoveRange(results);
                    Context.SaveChanges();
                }

            }
            catch (Exception err)
            {
                String errorMessage = err.Message;

                if (err.InnerException != null)
                    errorMessage += "\n InnerException: " + err.InnerException.Message;

                throw new Exception(errorMessage);
            }
        }
        
        public void Dispose()
        {
            
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }

            if (Connection.State == ConnectionState.Open)
                Connection.Close();


            Context.Dispose();
            Context = null;
            
            Connection = null;
            
        }

    }
}