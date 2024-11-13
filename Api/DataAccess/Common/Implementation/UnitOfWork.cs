using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Mozer.DataAccess.Common.Abstraction;
using Mozer.DataAccess.Messages.Abstraction;
using Mozer.DataAccess.Messages.Implementation;
using Mozer.DataAccess.Relation.Abstraction;
using Mozer.DataAccess.Relation.Implementation;
using Mozer.DataAccess.Users.Abstraction;
using Mozer.DataAccess.Users.Implementation;
using Mozer.ServiceContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Common.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(MozerContext context)
        {
            _context = context;
        }

        protected readonly MozerContext _context;

        protected IDbContextTransaction _transaction;

        #region fields

        #region identities


        protected IUserRepository _userRepository;
        protected IProfileRepository _profileRepository;
        protected IMessageRepository _messageRepository;
        protected IMessageItemRepository _messageItemRepository;
        protected IMessageActionRepository _messageActionRepository;
        protected IRelationRepository _relationRepository;


        #endregion

        #endregion

        #region repo


        #region identities

        public virtual IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public virtual IProfileRepository ProfileRepository => _profileRepository ??= new ProfileRepository(_context);

        public virtual IMessageRepository MessageRepository => _messageRepository ??= new MessageRepository(_context);
        public virtual IMessageItemRepository MessageItemRepository => _messageItemRepository ??= new MessageItemRepository(_context);
        public virtual IMessageActionRepository MessageActionRepository => _messageActionRepository ??= new MessageActionRepository(_context);
        public virtual IRelationRepository RelationRepository => _relationRepository ??= new RelationRepository(_context);

        #endregion

        #endregion

        #region methods

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }
        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
        }
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _transaction = _context.Database.BeginTransaction(isolationLevel);
        }

        public async Task BeginTransactionAsync(IsolationLevel isolationLevel)
        {
            _transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
          await _context.SaveChangesAsync();
        }


        #endregion
    }
}
