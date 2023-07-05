using Empresa_Productos.Models;
using Microsoft.EntityFrameworkCore;

namespace Empresa_Productos.Services;
public class UserService : IUserService
{
  Context context;
  public UserService(Context dbContext)
  {
    context = dbContext;
  }

  public async Task<IEnumerable<User>> Get()
  {
    return await Task.FromResult(context.Users);
  }

  public async Task Save(User user)
  {
    await context.AddAsync(user);
    await context.SaveChangesAsync();
  }
  public async Task Update(User user, string id)
  {
    var actualUser = context.Users.Find(id);
    if (actualUser != null)
    {
      actualUser.Name = user.Name ?? actualUser.Name;
      actualUser.UserName = user.UserName ?? actualUser.UserName;
      actualUser.Password = user.Password ?? actualUser.Password;
      actualUser.Role = user.Role;
      await context.SaveChangesAsync();
    }
    else
    {
      throw new InvalidOperationException("User Not Found.");
    }
  }
  public async Task Delete(string id)
  {
    var actualUser = context.Users.Find(id);
    if (actualUser != null)
    {
      context.Remove(actualUser);
      await context.SaveChangesAsync();
    }
    else
    {
      throw new InvalidOperationException("User Not Found.");
    }

  }
}

public interface IUserService
{
  Task<IEnumerable<User>> Get();
  Task Save(User user);
  Task Update(User user, string id);
  Task Delete(string id);
}