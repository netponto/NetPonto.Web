using System;
using System.Linq;
using System.Web;
using NHibernate;

namespace NetPonto.Web.HttpModules
{
    public class TransactionPerRequest : IHttpModule
    {
        private const string _ScopeKey = "NetPonto.TransactionScope";
     
        public static ISession SetSessionAndStartTransaction(ISession session)
        {
            var tx = session.BeginTransaction();
            HttpContext.Current.Items[_ScopeKey] = tx;
            return session;
        }

        private void application_EndRequest(object sender, EventArgs e)
        {
            if(!HttpContext.Current.Items.Contains(_ScopeKey))
                return;

            var transaction = (ITransaction) HttpContext.Current.Items[_ScopeKey];

            if(transaction == null || !transaction.IsActive) 
                return;

            if ((HttpContext.Current.AllErrors ?? new Exception[]{}).Any())
            {
                transaction.Rollback();
                return;
            }
            transaction.Commit();
                    
        }

        public void Init(HttpApplication context)
        {
           context.EndRequest += application_EndRequest;
        }

        public void Dispose()
        {
            
        }
    }
}