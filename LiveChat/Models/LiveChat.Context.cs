﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiveChat.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class LiveChatEntities : DbContext
    {
        public LiveChatEntities()
            : base("name=LiveChatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<LC_Msg> LC_Msg { get; set; }
        public DbSet<LC_User> LC_User { get; set; }
    
        public virtual ObjectResult<LC_User> sp_LC_FindUser(string userID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LC_User>("sp_LC_FindUser", userIDParameter);
        }
    
        public virtual ObjectResult<string> sp_LC_GenID()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_LC_GenID");
        }
    
        public virtual ObjectResult<string> sp_LC_GenUserID()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_LC_GenUserID");
        }
    
        public virtual ObjectResult<LC_Msg> sp_LC_SearchActiveMsg()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LC_Msg>("sp_LC_SearchActiveMsg");
        }
    
        public virtual ObjectResult<LC_Msg> sp_LC_SearchMsg(string msgID)
        {
            var msgIDParameter = msgID != null ?
                new ObjectParameter("MsgID", msgID) :
                new ObjectParameter("MsgID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LC_Msg>("sp_LC_SearchMsg", msgIDParameter);
        }
    
        public virtual ObjectResult<LC_User> sp_LC_UserValid_CallCentre(string userName, string passWord)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passWordParameter = passWord != null ?
                new ObjectParameter("PassWord", passWord) :
                new ObjectParameter("PassWord", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LC_User>("sp_LC_UserValid_CallCentre", userNameParameter, passWordParameter);
        }
    
        public virtual ObjectResult<LC_User> sp_LC_UserValidate(string userName, string passWord)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passWordParameter = passWord != null ?
                new ObjectParameter("PassWord", passWord) :
                new ObjectParameter("PassWord", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LC_User>("sp_LC_UserValidate", userNameParameter, passWordParameter);
        }
    }
}
