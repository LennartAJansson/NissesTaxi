namespace Api.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Api.Domain.Abstract;

using Dapper;

using Model;

using MySql.Data.MySqlClient;

public class QueryService(string connectionString) : IQueryService
{
  public async Task<Person?> GetPerson(Guid id)
  {
    var sql = $"select * from people where Id = {id}";
    using var connection = new MySqlConnection(connectionString);
    connection.Open();
    Person? person = (await connection.QueryAsync<Person>(sql)).FirstOrDefault();

    return person;
  }

  public async Task<IEnumerable<Person>> GetPeople()
  {
    var sql = $"select * from people";
    using var connection = new MySqlConnection(connectionString);
    connection.Open();
    IEnumerable<Person> people = await connection.QueryAsync<Person>(sql);

    return people;
  }
}
