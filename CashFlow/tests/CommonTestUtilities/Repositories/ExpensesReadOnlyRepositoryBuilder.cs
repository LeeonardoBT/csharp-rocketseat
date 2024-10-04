﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Moq;

namespace CommonTestUtilities.Repositories;
public class ExpensesReadOnlyRepositoryBuilder
{
    private readonly Mock<IExpenseReadOnlyRepository> _repository;

	public ExpensesReadOnlyRepositoryBuilder()
	{
		_repository = new Mock<IExpenseReadOnlyRepository>();
	}

	public ExpensesReadOnlyRepositoryBuilder GetAll(User user, List<Expense> expenses)
	{
		_repository.Setup(repository => repository.GetAll(user)).ReturnsAsync(expenses);

		return this;
    }

    public ExpensesReadOnlyRepositoryBuilder GetById(User user, Expense? expense)
    {
        if (expense is not null)
            _repository.Setup(repository => repository.GetById(user, expense.Id)).ReturnsAsync(expense);

        return this;
    }

    public ExpensesReadOnlyRepositoryBuilder FilterByMonth(User user, List<Expense> expenses)
    {
        _repository.Setup(repository => repository.FilterByMonth(user, It.IsAny<DateTime>())).ReturnsAsync(expenses);

        return this;
    }

    public IExpenseReadOnlyRepository Build() => _repository.Object;
}
