using Mozer.DataAccess.Messages.Abstraction;
using Mozer.DataAccess.Relation.Abstraction;
using Mozer.DataAccess.Users.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mozer.DataAccess.Common.Abstraction
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProfileRepository ProfileRepository { get; }
        IMessageRepository MessageRepository { get; }
        IMessageItemRepository MessageItemRepository { get; }
        IMessageActionRepository MessageActionRepository { get; }
        IRelationRepository RelationRepository { get; }

        #region methods
        void BeginTransaction();

        Task BeginTransactionAsync();

        void BeginTransaction(IsolationLevel isolationLevel);

        Task BeginTransactionAsync(IsolationLevel isolationLevel);

        void CommitTransaction();

        Task CommitTransactionAsync();

        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task SaveChangesAsync();

        void SaveChanges();

        #endregion
    }
}
