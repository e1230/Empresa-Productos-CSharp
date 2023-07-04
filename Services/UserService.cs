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

  public IEnumerable<User> Get()
  {
    return context.Users;
  }
  public async Task Save(User user)
  {
    await context.AddAsync(user);
    await context.SaveChangesAsync();
  }
  public async Task Update(User user, Guid id)
  {
    var actualUser = context.Users.Find(id);
    if (actualUser != null)
    {
      actualUser.Name = user.Name;
      actualUser.UserName = user.UserName;
      actualUser.Password = user.Password;
      actualUser.Role = user.Role;
      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(Guid id)
  {
    var actualUser = context.Users.Find(id);
    if (actualUser != null)
    {
      context.Remove(actualUser);
      await context.SaveChangesAsync();
    }

  }
}

public interface IUserService
{
  IEnumerable<User> Get();
  Task Save(User user);
  Task Update(User user, Guid id);
  Task Delete(Guid id);
}