using System.Data;

namespace NetQuestions.Application.Database;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}