using System.Linq.Expressions;
using Assert = Xunit.Assert; // Alias para Xunit.Assert
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Orders.Application.CostDetails.Queries.GetCostDetailById;
using Orders.Application.Exceptions;
using Orders.Domain.Models;
using Orders.Domain.ValueObjects;
using Xunit;
using Orders.Application.Data;

namespace Orders.Tests.Application.CostDetailsTest.QueriesTest.GetCostDetailByIdTest
{
    public class GetCostDetailByIdHandlerTests
    {
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly GetCostDetailByIdHandler _handler;

        public GetCostDetailByIdHandlerTests()
        {
            _mockDbContext = new Mock<IApplicationDbContext>();
            _handler = new GetCostDetailByIdHandler(_mockDbContext.Object);
        }

        private Mock<DbSet<T>> CreateMockDbSet<T>(IQueryable<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IAsyncEnumerable<T>>()
                .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                .Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));

            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<T>(data.Provider));

            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }

        [Fact]
        public async Task Handle_ShouldThrowCostDetailNotFoundException_WhenCostDetailDoesNotExist()
        {
            // Arrange
            var query = new GetCostDetailByIdQuery(Guid.NewGuid());
            var data = new List<CostDetail>().AsQueryable();
            var mockSet = CreateMockDbSet(data);

            _mockDbContext.Setup(db => db.CostDetails).Returns(mockSet.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }

    // Helper classes for async LINQ operations
    internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal TestAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Execute<TResult>(expression);
        }
    }

    internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);
    }

    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return ValueTask.CompletedTask;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(_inner.MoveNext());
        }

        public T Current => _inner.Current;
    }
}